<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cbDI1 = New System.Windows.Forms.CheckBox()
        Me.cbDI2 = New System.Windows.Forms.CheckBox()
        Me.cbDI3 = New System.Windows.Forms.CheckBox()
        Me.cbDI4 = New System.Windows.Forms.CheckBox()
        Me.cbTimer1_En = New System.Windows.Forms.CheckBox()
        Me.btnServoON = New System.Windows.Forms.Button()
        Me.btnServoOFF = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDO1 = New System.Windows.Forms.CheckBox()
        Me.cbDO2 = New System.Windows.Forms.CheckBox()
        Me.cbDO3 = New System.Windows.Forms.CheckBox()
        Me.cbDO4 = New System.Windows.Forms.CheckBox()
        Me.cbDO5 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbALM = New System.Windows.Forms.CheckBox()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.cbDI5 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReadPos = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbPOS1 = New System.Windows.Forms.Label()
        Me.tbPUL2 = New System.Windows.Forms.TextBox()
        Me.tbPUL1 = New System.Windows.Forms.TextBox()
        Me.tbREV2 = New System.Windows.Forms.TextBox()
        Me.tbREV1 = New System.Windows.Forms.TextBox()
        Me.cbLSN = New System.Windows.Forms.CheckBox()
        Me.cbLSP = New System.Windows.Forms.CheckBox()
        Me.cbDI8 = New System.Windows.Forms.CheckBox()
        Me.cbDI7 = New System.Windows.Forms.CheckBox()
        Me.cbDI6 = New System.Windows.Forms.CheckBox()
        Me.tbTargetPos1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSubmitPos1 = New System.Windows.Forms.Button()
        Me.btnSubmitPos2 = New System.Windows.Forms.Button()
        Me.tbTargetPos2 = New System.Windows.Forms.TextBox()
        Me.btnCTRG1 = New System.Windows.Forms.Button()
        Me.btnCTRG2 = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDiscon = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbTimeInterval = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnJogCCW = New System.Windows.Forms.Button()
        Me.btnJogCW = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial Unicode MS", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(56, 6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(240, 72)
        Me.TextBox2.TabIndex = 11
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Encoder"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'cbDI1
        '
        Me.cbDI1.AutoSize = True
        Me.cbDI1.Location = New System.Drawing.Point(9, 131)
        Me.cbDI1.Name = "cbDI1"
        Me.cbDI1.Size = New System.Drawing.Size(99, 17)
        Me.cbDI1.TabIndex = 16
        Me.cbDI1.Text = "Servo ON (DI1)"
        Me.cbDI1.UseVisualStyleBackColor = True
        '
        'cbDI2
        '
        Me.cbDI2.AutoSize = True
        Me.cbDI2.Location = New System.Drawing.Point(9, 154)
        Me.cbDI2.Name = "cbDI2"
        Me.cbDI2.Size = New System.Drawing.Size(54, 17)
        Me.cbDI2.TabIndex = 16
        Me.cbDI2.Text = "POS1"
        Me.cbDI2.UseVisualStyleBackColor = True
        '
        'cbDI3
        '
        Me.cbDI3.AutoSize = True
        Me.cbDI3.Location = New System.Drawing.Point(9, 177)
        Me.cbDI3.Name = "cbDI3"
        Me.cbDI3.Size = New System.Drawing.Size(56, 17)
        Me.cbDI3.TabIndex = 16
        Me.cbDI3.Text = "CTRG"
        Me.cbDI3.UseVisualStyleBackColor = True
        '
        'cbDI4
        '
        Me.cbDI4.AutoSize = True
        Me.cbDI4.Location = New System.Drawing.Point(9, 200)
        Me.cbDI4.Name = "cbDI4"
        Me.cbDI4.Size = New System.Drawing.Size(58, 17)
        Me.cbDI4.TabIndex = 16
        Me.cbDI4.Text = "SHOM"
        Me.cbDI4.UseVisualStyleBackColor = True
        '
        'cbTimer1_En
        '
        Me.cbTimer1_En.AutoSize = True
        Me.cbTimer1_En.Location = New System.Drawing.Point(25, 98)
        Me.cbTimer1_En.Name = "cbTimer1_En"
        Me.cbTimer1_En.Size = New System.Drawing.Size(89, 17)
        Me.cbTimer1_En.TabIndex = 17
        Me.cbTimer1_En.Text = "Start to Read"
        Me.cbTimer1_En.UseVisualStyleBackColor = True
        '
        'btnServoON
        '
        Me.btnServoON.Location = New System.Drawing.Point(23, 121)
        Me.btnServoON.Name = "btnServoON"
        Me.btnServoON.Size = New System.Drawing.Size(83, 52)
        Me.btnServoON.TabIndex = 18
        Me.btnServoON.Text = "Servo ON"
        Me.btnServoON.UseVisualStyleBackColor = True
        '
        'btnServoOFF
        '
        Me.btnServoOFF.Location = New System.Drawing.Point(112, 121)
        Me.btnServoOFF.Name = "btnServoOFF"
        Me.btnServoOFF.Size = New System.Drawing.Size(150, 52)
        Me.btnServoOFF.TabIndex = 18
        Me.btnServoOFF.Text = "Servo OFF"
        Me.btnServoOFF.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "DI status"
        '
        'cbDO1
        '
        Me.cbDO1.AutoSize = True
        Me.cbDO1.Location = New System.Drawing.Point(138, 131)
        Me.cbDO1.Name = "cbDO1"
        Me.cbDO1.Size = New System.Drawing.Size(48, 17)
        Me.cbDO1.TabIndex = 20
        Me.cbDO1.Text = "DO1"
        Me.cbDO1.UseVisualStyleBackColor = True
        '
        'cbDO2
        '
        Me.cbDO2.AutoSize = True
        Me.cbDO2.Location = New System.Drawing.Point(138, 154)
        Me.cbDO2.Name = "cbDO2"
        Me.cbDO2.Size = New System.Drawing.Size(48, 17)
        Me.cbDO2.TabIndex = 20
        Me.cbDO2.Text = "DO2"
        Me.cbDO2.UseVisualStyleBackColor = True
        '
        'cbDO3
        '
        Me.cbDO3.AutoSize = True
        Me.cbDO3.Location = New System.Drawing.Point(138, 177)
        Me.cbDO3.Name = "cbDO3"
        Me.cbDO3.Size = New System.Drawing.Size(48, 17)
        Me.cbDO3.TabIndex = 20
        Me.cbDO3.Text = "DO3"
        Me.cbDO3.UseVisualStyleBackColor = True
        '
        'cbDO4
        '
        Me.cbDO4.AutoSize = True
        Me.cbDO4.Location = New System.Drawing.Point(138, 200)
        Me.cbDO4.Name = "cbDO4"
        Me.cbDO4.Size = New System.Drawing.Size(48, 17)
        Me.cbDO4.TabIndex = 20
        Me.cbDO4.Text = "DO4"
        Me.cbDO4.UseVisualStyleBackColor = True
        '
        'cbDO5
        '
        Me.cbDO5.AutoSize = True
        Me.cbDO5.Location = New System.Drawing.Point(138, 223)
        Me.cbDO5.Name = "cbDO5"
        Me.cbDO5.Size = New System.Drawing.Size(48, 17)
        Me.cbDO5.TabIndex = 20
        Me.cbDO5.Text = "DO5"
        Me.cbDO5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "DO status"
        '
        'cbALM
        '
        Me.cbALM.AutoSize = True
        Me.cbALM.Location = New System.Drawing.Point(138, 246)
        Me.cbALM.Name = "cbALM"
        Me.cbALM.Size = New System.Drawing.Size(48, 17)
        Me.cbALM.TabIndex = 20
        Me.cbALM.Text = "ALM"
        Me.cbALM.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(158, 91)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(83, 52)
        Me.btnHome.TabIndex = 21
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'cbDI5
        '
        Me.cbDI5.AutoSize = True
        Me.cbDI5.Location = New System.Drawing.Point(9, 223)
        Me.cbDI5.Name = "cbDI5"
        Me.cbDI5.Size = New System.Drawing.Size(91, 17)
        Me.cbDI5.TabIndex = 16
        Me.cbDI5.Text = "ST1-JOG-CW"
        Me.cbDI5.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReadPos)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lbPOS1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tbPUL2)
        Me.Panel1.Controls.Add(Me.tbPUL1)
        Me.Panel1.Controls.Add(Me.tbREV2)
        Me.Panel1.Controls.Add(Me.tbREV1)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.cbALM)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbDO5)
        Me.Panel1.Controls.Add(Me.cbDI1)
        Me.Panel1.Controls.Add(Me.cbDO4)
        Me.Panel1.Controls.Add(Me.cbDI2)
        Me.Panel1.Controls.Add(Me.cbDO3)
        Me.Panel1.Controls.Add(Me.cbDI3)
        Me.Panel1.Controls.Add(Me.cbDO2)
        Me.Panel1.Controls.Add(Me.cbDI4)
        Me.Panel1.Controls.Add(Me.cbDO1)
        Me.Panel1.Controls.Add(Me.cbLSN)
        Me.Panel1.Controls.Add(Me.cbLSP)
        Me.Panel1.Controls.Add(Me.cbDI8)
        Me.Panel1.Controls.Add(Me.cbDI7)
        Me.Panel1.Controls.Add(Me.cbDI6)
        Me.Panel1.Controls.Add(Me.cbDI5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(293, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(299, 424)
        Me.Panel1.TabIndex = 22
        '
        'btnReadPos
        '
        Me.btnReadPos.Location = New System.Drawing.Point(242, 300)
        Me.btnReadPos.Name = "btnReadPos"
        Me.btnReadPos.Size = New System.Drawing.Size(51, 23)
        Me.btnReadPos.TabIndex = 22
        Me.btnReadPos.Text = "Read"
        Me.btnReadPos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(102, 335)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "POS2"
        '
        'lbPOS1
        '
        Me.lbPOS1.AutoSize = True
        Me.lbPOS1.Location = New System.Drawing.Point(102, 308)
        Me.lbPOS1.Name = "lbPOS1"
        Me.lbPOS1.Size = New System.Drawing.Size(35, 13)
        Me.lbPOS1.TabIndex = 21
        Me.lbPOS1.Text = "POS1"
        '
        'tbPUL2
        '
        Me.tbPUL2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPUL2.Location = New System.Drawing.Point(192, 327)
        Me.tbPUL2.Name = "tbPUL2"
        Me.tbPUL2.ReadOnly = True
        Me.tbPUL2.Size = New System.Drawing.Size(43, 26)
        Me.tbPUL2.TabIndex = 11
        Me.tbPUL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPUL1
        '
        Me.tbPUL1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPUL1.Location = New System.Drawing.Point(192, 300)
        Me.tbPUL1.Name = "tbPUL1"
        Me.tbPUL1.ReadOnly = True
        Me.tbPUL1.Size = New System.Drawing.Size(43, 26)
        Me.tbPUL1.TabIndex = 11
        Me.tbPUL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbREV2
        '
        Me.tbREV2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbREV2.Location = New System.Drawing.Point(143, 327)
        Me.tbREV2.Name = "tbREV2"
        Me.tbREV2.ReadOnly = True
        Me.tbREV2.Size = New System.Drawing.Size(43, 26)
        Me.tbREV2.TabIndex = 11
        Me.tbREV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbREV1
        '
        Me.tbREV1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbREV1.Location = New System.Drawing.Point(143, 300)
        Me.tbREV1.Name = "tbREV1"
        Me.tbREV1.ReadOnly = True
        Me.tbREV1.Size = New System.Drawing.Size(43, 26)
        Me.tbREV1.TabIndex = 11
        Me.tbREV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbLSN
        '
        Me.cbLSN.AutoSize = True
        Me.cbLSN.Location = New System.Drawing.Point(9, 334)
        Me.cbLSN.Name = "cbLSN"
        Me.cbLSN.Size = New System.Drawing.Size(87, 17)
        Me.cbLSN.TabIndex = 16
        Me.cbLSN.Text = "OT-Negative"
        Me.cbLSN.UseVisualStyleBackColor = True
        '
        'cbLSP
        '
        Me.cbLSP.AutoSize = True
        Me.cbLSP.Location = New System.Drawing.Point(9, 311)
        Me.cbLSP.Name = "cbLSP"
        Me.cbLSP.Size = New System.Drawing.Size(81, 17)
        Me.cbLSP.TabIndex = 16
        Me.cbLSP.Text = "OT-Positive"
        Me.cbLSP.UseVisualStyleBackColor = True
        '
        'cbDI8
        '
        Me.cbDI8.AutoSize = True
        Me.cbDI8.Location = New System.Drawing.Point(9, 288)
        Me.cbDI8.Name = "cbDI8"
        Me.cbDI8.Size = New System.Drawing.Size(47, 17)
        Me.cbDI8.TabIndex = 16
        Me.cbDI8.Text = "LOP"
        Me.cbDI8.UseVisualStyleBackColor = True
        '
        'cbDI7
        '
        Me.cbDI7.AutoSize = True
        Me.cbDI7.Location = New System.Drawing.Point(9, 267)
        Me.cbDI7.Name = "cbDI7"
        Me.cbDI7.Size = New System.Drawing.Size(95, 17)
        Me.cbDI7.TabIndex = 16
        Me.cbDI7.Text = "SP1-InnerSPD"
        Me.cbDI7.UseVisualStyleBackColor = True
        '
        'cbDI6
        '
        Me.cbDI6.AutoSize = True
        Me.cbDI6.Location = New System.Drawing.Point(9, 246)
        Me.cbDI6.Name = "cbDI6"
        Me.cbDI6.Size = New System.Drawing.Size(91, 17)
        Me.cbDI6.TabIndex = 16
        Me.cbDI6.Text = "ST1-JOG-CW"
        Me.cbDI6.UseVisualStyleBackColor = True
        '
        'tbTargetPos1
        '
        Me.tbTargetPos1.Location = New System.Drawing.Point(2, 32)
        Me.tbTargetPos1.MaxLength = 8
        Me.tbTargetPos1.Name = "tbTargetPos1"
        Me.tbTargetPos1.Size = New System.Drawing.Size(76, 20)
        Me.tbTargetPos1.TabIndex = 23
        Me.tbTargetPos1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Target Position"
        '
        'btnSubmitPos1
        '
        Me.btnSubmitPos1.Location = New System.Drawing.Point(90, 29)
        Me.btnSubmitPos1.Name = "btnSubmitPos1"
        Me.btnSubmitPos1.Size = New System.Drawing.Size(96, 23)
        Me.btnSubmitPos1.TabIndex = 25
        Me.btnSubmitPos1.Text = "Submit to POS1"
        Me.btnSubmitPos1.UseVisualStyleBackColor = True
        '
        'btnSubmitPos2
        '
        Me.btnSubmitPos2.Location = New System.Drawing.Point(90, 58)
        Me.btnSubmitPos2.Name = "btnSubmitPos2"
        Me.btnSubmitPos2.Size = New System.Drawing.Size(96, 23)
        Me.btnSubmitPos2.TabIndex = 25
        Me.btnSubmitPos2.Text = "Submit to POS2"
        Me.btnSubmitPos2.UseVisualStyleBackColor = True
        '
        'tbTargetPos2
        '
        Me.tbTargetPos2.Location = New System.Drawing.Point(2, 60)
        Me.tbTargetPos2.MaxLength = 8
        Me.tbTargetPos2.Name = "tbTargetPos2"
        Me.tbTargetPos2.Size = New System.Drawing.Size(76, 20)
        Me.tbTargetPos2.TabIndex = 23
        Me.tbTargetPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCTRG1
        '
        Me.btnCTRG1.Location = New System.Drawing.Point(192, 29)
        Me.btnCTRG1.Name = "btnCTRG1"
        Me.btnCTRG1.Size = New System.Drawing.Size(49, 23)
        Me.btnCTRG1.TabIndex = 25
        Me.btnCTRG1.Text = "Go!"
        Me.btnCTRG1.UseVisualStyleBackColor = True
        '
        'btnCTRG2
        '
        Me.btnCTRG2.Location = New System.Drawing.Point(192, 58)
        Me.btnCTRG2.Name = "btnCTRG2"
        Me.btnCTRG2.Size = New System.Drawing.Size(49, 23)
        Me.btnCTRG2.TabIndex = 25
        Me.btnCTRG2.Text = "Go!"
        Me.btnCTRG2.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(24, 64)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(82, 23)
        Me.btnConnect.TabIndex = 26
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnDiscon
        '
        Me.btnDiscon.Location = New System.Drawing.Point(112, 64)
        Me.btnDiscon.Name = "btnDiscon"
        Me.btnDiscon.Size = New System.Drawing.Size(150, 23)
        Me.btnDiscon.TabIndex = 26
        Me.btnDiscon.Text = "Disconnect"
        Me.btnDiscon.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(120, 36)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(64, 17)
        Me.ListBox1.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Select Serial Port"
        '
        'tbTimeInterval
        '
        Me.tbTimeInterval.Location = New System.Drawing.Point(456, 11)
        Me.tbTimeInterval.MaxLength = 4
        Me.tbTimeInterval.Name = "tbTimeInterval"
        Me.tbTimeInterval.Size = New System.Drawing.Size(37, 20)
        Me.tbTimeInterval.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(362, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Time interval (ms)"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(-1, 0)
        Me.ProgressBar1.Maximum = 1000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(605, 10)
        Me.ProgressBar1.TabIndex = 29
        '
        'Timer2
        '
        Me.Timer2.Interval = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(22, 179)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(255, 234)
        Me.TabControl1.TabIndex = 30
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.btnSubmitPos1)
        Me.TabPage1.Controls.Add(Me.btnSubmitPos2)
        Me.TabPage1.Controls.Add(Me.btnCTRG2)
        Me.TabPage1.Controls.Add(Me.btnCTRG1)
        Me.TabPage1.Controls.Add(Me.tbTargetPos2)
        Me.TabPage1.Controls.Add(Me.tbTargetPos1)
        Me.TabPage1.Controls.Add(Me.btnHome)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(247, 208)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pr Mode"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnJogCCW)
        Me.TabPage2.Controls.Add(Me.btnJogCW)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(247, 208)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SPD Mode"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnJogCCW
        '
        Me.btnJogCCW.Location = New System.Drawing.Point(128, 13)
        Me.btnJogCCW.Name = "btnJogCCW"
        Me.btnJogCCW.Size = New System.Drawing.Size(108, 52)
        Me.btnJogCCW.TabIndex = 18
        Me.btnJogCCW.Text = "Jog CCW"
        Me.btnJogCCW.UseVisualStyleBackColor = True
        '
        'btnJogCW
        '
        Me.btnJogCW.Location = New System.Drawing.Point(6, 13)
        Me.btnJogCW.Name = "btnJogCW"
        Me.btnJogCW.Size = New System.Drawing.Size(108, 52)
        Me.btnJogCW.TabIndex = 18
        Me.btnJogCW.Text = "Jog CW"
        Me.btnJogCW.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 473)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnDiscon)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.tbTimeInterval)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnServoOFF)
        Me.Controls.Add(Me.btnServoON)
        Me.Controls.Add(Me.cbTimer1_En)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cbDI1 As CheckBox
    Friend WithEvents cbDI2 As CheckBox
    Friend WithEvents cbDI3 As CheckBox
    Friend WithEvents cbDI4 As CheckBox
    Friend WithEvents cbTimer1_En As CheckBox
    Friend WithEvents btnServoON As Button
    Friend WithEvents btnServoOFF As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cbDO1 As CheckBox
    Friend WithEvents cbDO2 As CheckBox
    Friend WithEvents cbDO3 As CheckBox
    Friend WithEvents cbDO4 As CheckBox
    Friend WithEvents cbDO5 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbALM As CheckBox
    Friend WithEvents btnHome As Button
    Friend WithEvents cbDI5 As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cbLSN As CheckBox
    Friend WithEvents cbLSP As CheckBox
    Friend WithEvents tbTargetPos1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSubmitPos1 As Button
    Friend WithEvents btnSubmitPos2 As Button
    Friend WithEvents tbTargetPos2 As TextBox
    Friend WithEvents btnCTRG1 As Button
    Friend WithEvents btnCTRG2 As Button
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnDiscon As Button
    Friend WithEvents lbPOS1 As Label
    Friend WithEvents tbPUL2 As TextBox
    Friend WithEvents tbPUL1 As TextBox
    Friend WithEvents tbREV2 As TextBox
    Friend WithEvents tbREV1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnReadPos As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbTimeInterval As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer2 As Timer
    Friend WithEvents cbDI7 As CheckBox
    Friend WithEvents cbDI6 As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnJogCCW As Button
    Friend WithEvents btnJogCW As Button
    Friend WithEvents cbDI8 As CheckBox
End Class
