Imports System
Imports System.Drawing.Printing
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO.Ports
Imports System.Windows.Forms
'State of communication with MODBUS RTU
' 1. Homing (Home search)
' 2. Read Status and Error Code
' 3. Read Encoder Value
' 4. Send Target Position
' 5. Go to Target position
' 6. Save previous encoder value

'MODBUS RTU Frame structure sample
'Data(0) = &H1 'ADR: Communication machine number
'Data(1) = &H3 'CMD: Command code
'Data(2) = &H0 'Start Address (High-Byte)
'Data(3) = &H0 'Start Address (Low-Byte)
'Data(4) = &H0 'Word Length (High-byte)
'Data(5) = &H2 'Word Length (Low-byte)

'To Do List
'1. make a request response when press "Connect" button 3 times to check the survival of the slave device
'2. make a synchronize between send and recieve frame

Public Class Form1
    Private MSComm1 As New SerialPort
    Private comBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate
    Dim CRC_HIGH_BYTE As String
    Dim CRC_LOW_BYTE As String
    Dim count As Byte
    Dim Data(0 To 5) As Byte
    Dim Send_Data(0 To 7) As Byte
    Dim Start_CRC As String
    Const read_reg As Byte = 3 'read register
    Const write_reg As Byte = 6 'write register
    Dim CmdDI As Byte 'For control or force Digital Input
    Dim POSn As Byte = 9 ' POS number value
    Dim POSdig As Byte = 8 'Target Position Max.Digit
    Dim temp(3) As Byte
    Dim wait As Boolean ' true = must wait

    'The data structure to convert values into Bytes and back
    <StructLayout(LayoutKind.Explicit)> Structure HiLoCalc
        ' 1 x Long (8 Bytes) from 0 
        <FieldOffset(0)> Dim Long0 As Long
        ' 1 x double (8 Bytes) from 0 
        <FieldOffset(0)> Dim Double0 As Double
        ' 1 x Integer = 1 x 4 Bytes) from Byte 0 
        <FieldOffset(0)> Dim Int0 As Integer
        <FieldOffset(4)> Dim Int1 As Integer
        ' 2 x Short = 2 x 2 Bytes) from Byte 0 
        <FieldOffset(0)> Dim Short0 As Short
        <FieldOffset(2)> Dim Short1 As Short
        <FieldOffset(4)> Dim Short2 As Short
        <FieldOffset(6)> Dim Short3 As Short
        <FieldOffset(0)> Dim UShort0 As UShort
        <FieldOffset(2)> Dim UShort1 As UShort
        <FieldOffset(4)> Dim UShort2 As UShort
        <FieldOffset(6)> Dim UShort3 As UShort

        ' 4 x Byte = 4 x 1 Byte) from Byte 0 
        <FieldOffset(0)> Dim Byte0 As Byte
        <FieldOffset(1)> Dim Byte1 As Byte
        <FieldOffset(2)> Dim Byte2 As Byte
        <FieldOffset(3)> Dim Byte3 As Byte
        <FieldOffset(4)> Dim Byte4 As Byte
        <FieldOffset(5)> Dim Byte5 As Byte
        <FieldOffset(6)> Dim Byte6 As Byte
        <FieldOffset(7)> Dim Byte7 As Byte

        ' Get LoByte (Byte 0) 
        Function LoByte(ByVal Value As Integer) As Byte
            Int0 = Value
            Return Byte0
        End Function

        ' Get HiByte (Byte 1)
        Function HiByte(ByVal Value As Integer) As Byte
            Int0 = Value
            Return Byte1
        End Function

        ' Get LoWord (Bytes 0-1) 
        Function LoWord(ByVal Value As Integer) As Short
            Int0 = Value
            Return Short0
        End Function

        ' Get HiWord (Bytes 2-3) 
        Function HiWord(ByVal Value As Integer) As Short
            Int0 = Value
            Return Short1
        End Function

        'Now the reverse operation
        ' Create a Short out from 2 Bytes 
        Function MakeShort(ByVal LoByte As Byte, ByVal HiByte As Byte) As Short
            Byte0 = LoByte
            Byte1 = HiByte
            Return Short0
        End Function
        ' try 30/09/10
        Function MakeUShort(ByVal LoByte As Byte, ByVal HiByte As Byte) As UShort
            Byte0 = LoByte
            Byte1 = HiByte
            Return UShort0
        End Function
        ' Create an Integer out from 2 Shorts 
        Function MakeInt32(ByVal LoWord As Short, ByVal HiWord As Short) As Integer
            Short0 = LoWord
            Short1 = HiWord
            Return Int0
        End Function
    End Structure

    'The procedure will deliver 2 Bytes made out from an Short Integer
    Private Sub MakeByteFromShort(ByVal Value As Short, ByRef B0 As Byte, ByRef B1 As Byte)
        Dim CalcB As HiLoCalc

        B0 = CalcB.LoByte(Value)
        B1 = CalcB.HiByte(Value)
    End Sub

    'The procedure will deliver 2 Bytes made out from an Short Integer
    Private Sub MakeByteFromUShort(ByVal Value As UShort, ByRef B0 As Byte, ByRef B1 As Byte)
        Dim CalcB As HiLoCalc

        B0 = CalcB.LoByte(Value)
        B1 = CalcB.HiByte(Value)
    End Sub

    'The procedure will deliver 4 Bytes made out from an Integer
    Private Sub MakeByteFromInteger(ByVal Value As Integer, ByRef B0 As Byte, ByRef B1 As Byte, ByRef B2 As Byte, ByRef B3 As Byte)
        Dim CalcB As HiLoCalc
        Dim Short0 As Short
        Dim Short1 As Short

        Short0 = CalcB.LoWord(Value)
        Short1 = CalcB.HiWord(Value)
        B0 = CalcB.LoByte(Short0)
        B1 = CalcB.HiByte(Short0)
        B2 = CalcB.LoByte(Short1)
        B3 = CalcB.HiByte(Short1)
    End Sub

    'Make an Integer out from 4 Bytes
    Private Function MakeIntegerFromByte(ByRef B0 As Byte, ByRef B1 As Byte, ByRef B2 As Byte, ByRef B3 As Byte) As Integer
        Dim CalcB As HiLoCalc

        CalcB.Byte0 = B0
        CalcB.Byte1 = B1
        CalcB.Byte2 = B2
        CalcB.Byte3 = B3
        Return CalcB.Int0
    End Function

    'The procedure will deliver 8 Bytes made out from Double value
    Private Sub MakeByteFromDouble(ByVal Value As Double, ByRef B0 As Byte, ByRef B1 As Byte, ByRef B2 As Byte, ByRef B3 As Byte, ByRef B4 As Byte, ByRef B5 As Byte, ByRef B6 As Byte, ByRef B7 As Byte)
        Dim CalcB As HiLoCalc
        CalcB.Double0 = Value

        B0 = CalcB.Byte0
        B1 = CalcB.Byte1
        B2 = CalcB.Byte2
        B3 = CalcB.Byte3
        B4 = CalcB.Byte4
        B5 = CalcB.Byte5
        B6 = CalcB.Byte6
        B7 = CalcB.Byte7
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler MSComm1.DataReceived, AddressOf MSComm1_DataReceived
        'GetSerialPortNames()
        'Timer1.Interval 
        'Timer1.Enabled = True
        CommPortSetup()

        btnDiscon.Enabled = False
        btnConnect.Enabled = True
        btnServoON.Enabled = False
        btnServoOFF.Enabled = False

        TabControl1.Enabled = False
        TabControl1.SelectedIndex = 0

        tbTargetPos1.MaxLength = POSdig
        tbTargetPos2.MaxLength = POSdig
        tbTimeInterval.Text = "60"
        count = 255
        ProgressBar1.Value = 0
        CmdDI = 0

    End Sub
    Sub GetSerialPortNames()
        ' Show all available COM ports.
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ListBox1.Items.Add(sp)
        Next
    End Sub
    Private Sub CommPortSetup()
        With MSComm1
            .PortName = "COM4"
            .BaudRate = 57600
            .DataBits = 8
            .Parity = Parity.Odd
            .StopBits = StopBits.One
            .Handshake = Handshake.None
        End With
    End Sub
    Private Sub Form1_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Timer1.Enabled = False
        MSComm1.Close() 'CLOSE COM PORT
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Timer1.Enabled = False
        MSComm1.Close() 'CLOSE COM PORT

    End Sub
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        'CommPortSetup()
        'Debug
        If MSComm1.IsOpen = False Then
            Try
                MSComm1.Open()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If MSComm1.IsOpen = True Then
            cbTimer1_En.Checked = True
            ProgressBar1.Value = 0
            'Button status
            btnConnect.Enabled = False
            btnDiscon.Enabled = True
            btnServoON.Enabled = True
            btnServoOFF.Enabled = True
        End If

    End Sub

    Private Sub btnDiscon_Click(sender As Object, e As EventArgs) Handles btnDiscon.Click
        count = 20
        If count = 0 Then
            Timer1.Enabled = False
            MSComm1.Close() 'CLOSE COM PORT
        End If
        'Button status
        cbTimer1_En.Checked = False
        btnConnect.Enabled = True
        btnDiscon.Enabled = False
        btnServoON.Enabled = False
        btnServoOFF.Enabled = False
    End Sub
    Public Function CRC16(ByVal Data() As Byte, Optional ByVal DataNo% = 0) As String

        Dim CRC16Lo As Byte, CRC16Hi As Byte      'CRC register
        Dim CL As Byte, CH As Byte                'ฆh?ฆก?&HA001
        Dim SaveHi As Byte, SaveLo As Byte
        Dim I As Integer
        Dim Flag As Integer

        CRC16Lo = &HFF
        CRC16Hi = &HFF
        CL = &H1
        CH = &HA0

        If DataNo = 0 Then DataNo = UBound(Data) + 1

        For I = 0 To DataNo - 1
            CRC16Lo = CRC16Lo Xor Data(I) 'จCค@??ีuษOCRC register?ฆๆษฉฮ
            For Flag = 0 To 7
                SaveHi = CRC16Hi
                SaveLo = CRC16Lo
                CRC16Hi = CRC16Hi \ 2            'High right one
                CRC16Lo = CRC16Lo \ 2            'Low right one
                If ((SaveHi And &H1) = &H1) Then 'ฆpชGฐชฆ์ฆr?ณฬฆZค@ฆ์?1
                    CRC16Lo = CRC16Lo Or &H80      '?งCฆ์ฆr?ฅkฒพฆZซeญฑ?1
                End If                           'ง_?ฆ??0
                If ((SaveLo And &H1) = &H1) Then 'ฆpชGLSB?1กA?ษOฆh?ฆก??ฆๆษฉฮ
                    CRC16Hi = CRC16Hi Xor CH
                    CRC16Lo = CRC16Lo Xor CL
                End If
            Next Flag
        Next I

        CRC_LOW_BYTE = CStr(Hex(CRC16Hi))
        CRC_HIGH_BYTE = CStr(Hex(CRC16Lo))

        CRC16 = CRC_LOW_BYTE
    End Function

    Private Sub MSComm1_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        UpdateFormDelegate1 = New UpdateFormDelegate(AddressOf UpdateDisplay)
        Dim n As Integer = MSComm1.BytesToRead
        comBuffer = New Byte(n - 1) {}
        MSComm1.Read(comBuffer, 0, n)

        'For i = 0 To n - 1
        '    Console.WriteLine(comBuffer(i))
        'Next i
        Try
            Me.Invoke(UpdateFormDelegate1)
        Catch

        End Try

    End Sub
    'Convert 4 Hex to sign integer
    Function HexDW(ByVal hbyte() As Byte, ByVal callen As Byte) As Int32
        Dim temp0 As String
        Dim temp1 As String
        Select Case callen
            Case &H04
                temp0 = Hex(hbyte(3)).PadLeft(2, "0") & Hex(hbyte(4)).PadLeft(2, "0")
                temp1 = Hex(hbyte(5)).PadLeft(2, "0") & Hex(hbyte(6)).PadLeft(2, "0")
                If hbyte(3) >= &HD8 Then
                    If temp1 = "0000" Then
                        HexDW = (Convert.ToUInt32(temp0, 16)) - 65536
                    Else
                        HexDW = (Convert.ToUInt32(temp1, 16) - 65536) * 10000 + (Convert.ToUInt32(temp0, 16)) - 65536
                    End If
                Else
                    'calc = CalcB.MakeShort(comBuffer(4), comBuffer(3))
                    HexDW = Convert.ToInt32(temp1, 16) * 10000 + Convert.ToInt32(temp0, 16)
                    'TextBox2.Text = calc.ToString
                End If
                'Case &H10 ' = 8 Decimal
                '    Dim temp(0 To callen - 1) As String
                '    temp(0) = Hex(comBuffer(3)).PadLeft(2, "0") & Hex(comBuffer(4)).PadLeft(2, "0")
                '    temp(1) = Hex(comBuffer(5)).PadLeft(2, "0") & Hex(comBuffer(6)).PadLeft(2, "0")
                '    tbTargetPos1.Text = CStr(Convert.ToInt32(tbREV1.Text, 16) * 10000 + Convert.ToInt32(tbPUL1.Text, 16))
                '    temp(2) = Hex(comBuffer(7)).PadLeft(2, "0") & Hex(comBuffer(8)).PadLeft(2, "0")
                '    temp(3) = Hex(comBuffer(9)).PadLeft(2, "0") & Hex(comBuffer(10)).PadLeft(2, "0")
                '    tbTargetPos2.Text = CStr(Convert.ToInt32(tbREV2.Text, 16) * 10000 + Convert.ToInt32(tbPUL2.Text, 16))
                '    temp(4) = CStr(Hex(comBuffer(11))) & CStr(Hex(comBuffer(12)))
                '    temp(5) = CStr(Hex(comBuffer(13))) & CStr(Hex(comBuffer(14)))
                '    tbTargetPos3.Text = CStr(Convert.ToInt32(tbREV3.Text, 16) * 10000 + Convert.ToInt32(tbPUL3.Text, 16))
                '    temp(6) = CStr(Hex(comBuffer(15))) & CStr(Hex(comBuffer(16)))
                '    temp(7) = CStr(Hex(comBuffer(17))) & CStr(Hex(comBuffer(18)))
                '    tbTargetPos4.Text = CStr(Convert.ToInt32(tbREV4.Text, 16) * 10000 + Convert.ToInt32(tbPUL4.Text, 16))
        End Select
        Return HexDW
    End Function
    Function SetDI(ByVal i As Byte) As Byte
        SetDI = 2 ^ (i - 1)
        Return SetDI
    End Function
    Function RstDI(ByVal i As Byte) As Byte
        RstDI = &H00 Or 2 ^ (i - 1)
        RstDI = Not RstDI
        Return RstDI
    End Function

    Private Sub UpdateDisplay()
        'Dim calc As Short
        'Dim CalcB As HiLoCalc
        'Dim temp0 As String
        'Dim temp1 As String

        If comBuffer.Length > 5 Then
            Select Case comBuffer(1)
                Case &H03
                    Select Case comBuffer(2)
                        Case &H04
                            TextBox2.Text = HexDW(comBuffer, comBuffer(2))

                        Case &H02
                            cbDI1.Checked = comBuffer(4) And 1 'bit 0
                            cbDI2.Checked = comBuffer(4) And 2 'bit 1
                            cbDI3.Checked = comBuffer(4) And 4 'bit 2
                            cbDI4.Checked = comBuffer(4) And 8 'bit 3
                            cbDI5.Checked = comBuffer(4) And 16 'bit 4
                            cbDI6.Checked = comBuffer(4) And 32 'bit 5
                            cbDI7.Checked = comBuffer(4) And 64 'bit 6
                            cbDI8.Checked = comBuffer(4) And 128 'bit 7

                            cbDO1.Checked = comBuffer(3) And 4  'bit 2
                            cbDO2.Checked = comBuffer(3) And 8  'bit 3
                            cbDO3.Checked = comBuffer(3) And 16 'bit 4
                            cbDO4.Checked = comBuffer(3) And 32 'bit 5
                            cbDO5.Checked = comBuffer(3) And 64 'bit 6
                            cbALM.Checked = comBuffer(3) And 128    'bit 7
                        Case &H10
                            tbREV1.Text = Hex(comBuffer(3)).PadLeft(2, "0") & Hex(comBuffer(4)).PadLeft(2, "0")
                            tbPUL1.Text = Hex(comBuffer(5)).PadLeft(2, "0") & Hex(comBuffer(6)).PadLeft(2, "0")
                            tbTargetPos1.Text = CStr(Convert.ToInt32(tbREV1.Text, 16) * 10000 + Convert.ToInt32(tbPUL1.Text, 16))
                            tbREV2.Text = Hex(comBuffer(7)).PadLeft(2, "0") & Hex(comBuffer(8)).PadLeft(2, "0")
                            tbPUL2.Text = Hex(comBuffer(9)).PadLeft(2, "0") & Hex(comBuffer(10)).PadLeft(2, "0")
                            tbTargetPos2.Text = CStr(Convert.ToInt32(tbREV2.Text, 16) * 10000 + Convert.ToInt32(tbPUL2.Text, 16))

                    End Select
            End Select
        Else
            Console.WriteLine("======= Get Data Failed =======")
        End If

        wait = False

        If cbDI1.Checked Then
            btnServoON.BackColor = Color.Green
            btnServoOFF.BackColor = Color.DimGray
            TabControl1.Enabled = True
        Else
            btnServoON.BackColor = Color.DimGray
            btnServoOFF.BackColor = Color.Green
            TabControl1.Enabled = False
        End If

    End Sub

    Private Sub cbTimer1_En_CheckedChanged(sender As Object, e As EventArgs) Handles cbTimer1_En.CheckedChanged
        If cbTimer1_En.Checked Then
            Timer1.Interval = CInt(tbTimeInterval.Text)
            Timer1.Start()
            count = 255
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If cbTimer1_En.Checked And (Not Timer2.Enabled) Then
            Select Case count
                Case 0
                    ' Read Encoder Value
                    Data = {1, read_reg, 0, 0, 0, 2}
                    Console.WriteLine("Read Encoder on " & CStr(TimeOfDay))
                    wait = True
                    count += 1
                Case 1
                    ' Read Digital Input Status
                    Data = {1, read_reg, 2, 3, 0, 1}
                    Console.WriteLine("Read DI on " & CStr(TimeOfDay))
                    wait = True
                    count = 0
                Case 10
                    'Write Control DI by Software
                    Data = {1, write_reg, 3, &H87, 0, 1}
                    count += 1
                Case 11
                    'Write CmdDI-ON
                    Data = {1, write_reg, 2, 1, 0, CmdDI}
                    Console.WriteLine("Cmd DI: " & Hex(CmdDI))
                    count = 0
                Case 20
                    'Write Control DI by Terminal and Servo - OFF
                    Data = {1, write_reg, 3, &H87, 0, 0}
                    count = 0
                Case 100
                    'Write CTRG - OFF
                    Data = {1, write_reg, 2, 1, 0, 1}
                    count = 0
                Case 101
                    'Write CTRG - POSn - ON, 
                    Data = {1, write_reg, 2, 1, 0, CmdDI}
                    Console.WriteLine("Cmd DI: " & Hex(CmdDI))
                    count = 100
                Case 200 'POS1-PULSE Num
                    Data = {1, write_reg, &H3, &H0F, temp(0), temp(1)}
                    count += 1
                Case 201 'POS1-REV Num
                    Data = {1, write_reg, &H3, &H0E, temp(2), temp(3)}
                    count = 0
                Case 210 'POS2-PULSE Num
                    Data = {1, write_reg, &H3, &H11, temp(0), temp(1)}
                    count += 1
                Case 211 'POS2-REV Num
                    Data = {1, write_reg, &H3, &H10, temp(2), temp(3)}
                    count = 0
                Case 255
                    Data = {1, read_reg, &H03, &H0E, 0, 8}
                    wait = True
                    count = 0
            End Select
            'wait = True


            'CRC calculation
            Start_CRC = CRC16(Data)
            SentToComm(Data)
            Timer2.Start()

        Else UpdateDisplay()
        End If
        'Select Case count
        '    Case 1, 11, 20, 100, 201, 211, 221, 231, 255
        '        count = 0
        '    Case Else
        '        count = count
        'End Select
        If ProgressBar1.Value > 999 Then
            ProgressBar1.Value = 0
        End If

    End Sub
    Private Sub SentToComm(ByVal data() As Byte)

        Dim Send_Data(0 To 7) As Byte
        Send_Data(0) = data(0)
        Send_Data(1) = data(1)
        Send_Data(2) = data(2)
        Send_Data(3) = data(3)
        Send_Data(4) = data(4)
        Send_Data(5) = data(5)
        Send_Data(6) = Val("&H" + CRC_HIGH_BYTE)
        Send_Data(7) = Val("&H" + CRC_LOW_BYTE)

        Try
            MSComm1.Write(Send_Data, 0, 8)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnServoOFF_Click(sender As Object, e As EventArgs) Handles btnServoOFF.Click
        'Write SERVO - OFF
        CmdDI = CmdDI And RstDI(1)
        count = 11
        'Console.WriteLine("SERVO OFF")
    End Sub

    Private Sub btnHome_MouseDown(sender As Object, e As MouseEventArgs) Handles btnHome.MouseDown
        'Write SHOM - ON
        CmdDI = CmdDI Or SetDI(4)
        count = 11
        'Console.WriteLine("HOME ON")
    End Sub

    Private Sub btnHome_MouseUp(sender As Object, e As MouseEventArgs) Handles btnHome.MouseUp
        'Write SHOM - ON
        CmdDI = CmdDI And RstDI(4)
        count = 11
        'Console.WriteLine("HOME OFF")
    End Sub

    Private Sub btnServoON_Click(sender As Object, e As EventArgs) Handles btnServoON.Click
        CmdDI = CmdDI Or SetDI(1)
        count = 10
    End Sub

    Private Sub btnCTRG1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCTRG1.MouseDown
        CmdDI = CmdDI And RstDI(2) ' Select POS1 when DI2 = 0
        CmdDI = CmdDI Or SetDI(3) ' send CTRG command
        count = 11
    End Sub

    Private Sub btnCTRG1_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCTRG1.MouseUp
        CmdDI = CmdDI And RstDI(2) ' Select POS1 when DI2 = 0
        CmdDI = CmdDI And RstDI(3) ' send CTRG command
        count = 11
    End Sub

    Private Sub btnCTRG2_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCTRG2.MouseDown
        CmdDI = CmdDI Or SetDI(2) ' Select POS1 when DI2 = 0
        CmdDI = CmdDI Or SetDI(3) ' send CTRG command
        count = 11
    End Sub

    Private Sub btnCTRG2_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCTRG2.MouseUp
        CmdDI = CmdDI Or SetDI(2) ' Select POS1 when DI2 = 0
        CmdDI = CmdDI And RstDI(3) ' send CTRG command
        count = 101
    End Sub

    Private Sub btnReadPos_Click(sender As Object, e As EventArgs) Handles btnReadPos.Click
        count = 255
    End Sub
    Private Sub btnSubmitPos1_Click(sender As Object, e As EventArgs) Handles btnSubmitPos1.Click

        If IsNumeric(tbTargetPos1.Text) Then
            TargetPosAssign(tbTargetPos1.Text)
            count = 200
        End If

    End Sub

    Private Sub btnSubmitPos2_Click(sender As Object, e As EventArgs) Handles btnSubmitPos2.Click
        If IsNumeric(tbTargetPos2.Text) Then
            TargetPosAssign(tbTargetPos2.Text)
            count = 210
        End If
    End Sub

    Private Sub btnJogCW_MouseDown(sender As Object, e As MouseEventArgs) Handles btnJogCW.MouseDown
        CmdDI = CmdDI Or SetDI(5)
        count = 11
    End Sub

    Private Sub btnJogCW_MouseUp(sender As Object, e As MouseEventArgs) Handles btnJogCW.MouseUp
        CmdDI = CmdDI And RstDI(5)
        count = 11
    End Sub

    Private Sub btnJogCCW_MouseDown(sender As Object, e As MouseEventArgs) Handles btnJogCCW.MouseDown
        CmdDI = CmdDI Or SetDI(6)
        count = 11
    End Sub

    Private Sub btnJogCCW_MouseUp(sender As Object, e As MouseEventArgs) Handles btnJogCCW.MouseUp
        CmdDI = CmdDI And RstDI(6)
        count = 11
    End Sub

    Private Sub TargetPosAssign(ByVal SV_POS As String)
        Dim RevNum As Integer
        Dim PulNum As Integer
        Dim Reminder As Integer

        PulNum = CInt(SV_POS)
        If PulNum > 0 Then
            RevNum = PulNum \ 10000
            Reminder = PulNum Mod 10000
        End If

        temp(0) = Reminder >> 8
        temp(1) = Reminder And &H00FF
        temp(2) = RevNum >> 8
        temp(3) = RevNum And &H00FF

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        ProgressBar1.Value += 1
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            CmdDI = CmdDI And RstDI(8)
            CmdDI = CmdDI And RstDI(7)
        Else
            CmdDI = CmdDI Or SetDI(8)
            CmdDI = CmdDI Or SetDI(7)
        End If
        count = 11
    End Sub

End Class

