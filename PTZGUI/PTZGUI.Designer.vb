<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PTZGUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CameraGroupBox = New System.Windows.Forms.GroupBox()
        Me.LensButton = New System.Windows.Forms.Button()
        Me.FocusValueLabel = New System.Windows.Forms.Label()
        Me.FocusHScrollBar = New System.Windows.Forms.HScrollBar()
        Me.ZoomHScrollBar = New System.Windows.Forms.HScrollBar()
        Me.ZHScrollBar = New System.Windows.Forms.HScrollBar()
        Me.ZoomValueLabel = New System.Windows.Forms.Label()
        Me.ZValueLabel = New System.Windows.Forms.Label()
        Me.YValueLabel = New System.Windows.Forms.Label()
        Me.XValueLabel = New System.Windows.Forms.Label()
        Me.CameraCenterButton = New System.Windows.Forms.Button()
        Me.XHScrollBar = New System.Windows.Forms.HScrollBar()
        Me.FocusLabel = New System.Windows.Forms.Label()
        Me.ZoomLabel = New System.Windows.Forms.Label()
        Me.YVScrollBar = New System.Windows.Forms.VScrollBar()
        Me.ZLabel = New System.Windows.Forms.Label()
        Me.YLabel = New System.Windows.Forms.Label()
        Me.XLabel = New System.Windows.Forms.Label()
        Me.LEDGroupBox = New System.Windows.Forms.GroupBox()
        Me.BlueDisplayLabel = New System.Windows.Forms.Label()
        Me.GreenDisplayLabel = New System.Windows.Forms.Label()
        Me.RedDisplayLabel = New System.Windows.Forms.Label()
        Me.BlueTrackBar = New System.Windows.Forms.TrackBar()
        Me.GreenTrackBar = New System.Windows.Forms.TrackBar()
        Me.RedTrackBar = New System.Windows.Forms.TrackBar()
        Me.HexDisplayLabel = New System.Windows.Forms.Label()
        Me.ClearColorButton = New System.Windows.Forms.Button()
        Me.SetColorButton = New System.Windows.Forms.Button()
        Me.BlueTextBox = New System.Windows.Forms.TextBox()
        Me.GreenTextBox = New System.Windows.Forms.TextBox()
        Me.RedTextBox = New System.Windows.Forms.TextBox()
        Me.LEDPictureBox = New System.Windows.Forms.PictureBox()
        Me.BlueLabel = New System.Windows.Forms.Label()
        Me.GreenLabel = New System.Windows.Forms.Label()
        Me.RedLabel = New System.Windows.Forms.Label()
        Me.ExtiButton = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PortComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPortLabel = New System.Windows.Forms.Label()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.CameraGroupBox.SuspendLayout()
        Me.LEDGroupBox.SuspendLayout()
        CType(Me.BlueTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GreenTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RedTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CameraGroupBox
        '
        Me.CameraGroupBox.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.CameraGroupBox.Controls.Add(Me.LensButton)
        Me.CameraGroupBox.Controls.Add(Me.FocusValueLabel)
        Me.CameraGroupBox.Controls.Add(Me.FocusHScrollBar)
        Me.CameraGroupBox.Controls.Add(Me.ZoomHScrollBar)
        Me.CameraGroupBox.Controls.Add(Me.ZHScrollBar)
        Me.CameraGroupBox.Controls.Add(Me.ZoomValueLabel)
        Me.CameraGroupBox.Controls.Add(Me.ZValueLabel)
        Me.CameraGroupBox.Controls.Add(Me.YValueLabel)
        Me.CameraGroupBox.Controls.Add(Me.XValueLabel)
        Me.CameraGroupBox.Controls.Add(Me.CameraCenterButton)
        Me.CameraGroupBox.Controls.Add(Me.XHScrollBar)
        Me.CameraGroupBox.Controls.Add(Me.FocusLabel)
        Me.CameraGroupBox.Controls.Add(Me.ZoomLabel)
        Me.CameraGroupBox.Controls.Add(Me.YVScrollBar)
        Me.CameraGroupBox.Controls.Add(Me.ZLabel)
        Me.CameraGroupBox.Controls.Add(Me.YLabel)
        Me.CameraGroupBox.Controls.Add(Me.XLabel)
        Me.CameraGroupBox.ForeColor = System.Drawing.Color.Black
        Me.CameraGroupBox.Location = New System.Drawing.Point(12, 21)
        Me.CameraGroupBox.Name = "CameraGroupBox"
        Me.CameraGroupBox.Size = New System.Drawing.Size(801, 679)
        Me.CameraGroupBox.TabIndex = 4
        Me.CameraGroupBox.TabStop = False
        Me.CameraGroupBox.Text = "Camera Position "
        '
        'LensButton
        '
        Me.LensButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.LensButton.Location = New System.Drawing.Point(314, 537)
        Me.LensButton.Name = "LensButton"
        Me.LensButton.Size = New System.Drawing.Size(97, 75)
        Me.LensButton.TabIndex = 19
        Me.LensButton.Text = "Clear Lens Settings (L)"
        Me.LensButton.UseVisualStyleBackColor = True
        '
        'FocusValueLabel
        '
        Me.FocusValueLabel.AutoSize = True
        Me.FocusValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.FocusValueLabel.Location = New System.Drawing.Point(753, 480)
        Me.FocusValueLabel.Name = "FocusValueLabel"
        Me.FocusValueLabel.Size = New System.Drawing.Size(24, 20)
        Me.FocusValueLabel.TabIndex = 47
        Me.FocusValueLabel.Text = "---"
        '
        'FocusHScrollBar
        '
        Me.FocusHScrollBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FocusHScrollBar.LargeChange = 1
        Me.FocusHScrollBar.Location = New System.Drawing.Point(437, 467)
        Me.FocusHScrollBar.Margin = New System.Windows.Forms.Padding(10)
        Me.FocusHScrollBar.Maximum = 30
        Me.FocusHScrollBar.Minimum = 8
        Me.FocusHScrollBar.Name = "FocusHScrollBar"
        Me.FocusHScrollBar.Size = New System.Drawing.Size(280, 39)
        Me.FocusHScrollBar.TabIndex = 18
        Me.FocusHScrollBar.TabStop = True
        Me.FocusHScrollBar.Value = 8
        '
        'ZoomHScrollBar
        '
        Me.ZoomHScrollBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ZoomHScrollBar.LargeChange = 1
        Me.ZoomHScrollBar.Location = New System.Drawing.Point(13, 467)
        Me.ZoomHScrollBar.Margin = New System.Windows.Forms.Padding(10)
        Me.ZoomHScrollBar.Maximum = 30
        Me.ZoomHScrollBar.Minimum = 8
        Me.ZoomHScrollBar.Name = "ZoomHScrollBar"
        Me.ZoomHScrollBar.Size = New System.Drawing.Size(280, 39)
        Me.ZoomHScrollBar.TabIndex = 17
        Me.ZoomHScrollBar.TabStop = True
        Me.ZoomHScrollBar.Value = 8
        '
        'ZHScrollBar
        '
        Me.ZHScrollBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ZHScrollBar.LargeChange = 1
        Me.ZHScrollBar.Location = New System.Drawing.Point(21, 191)
        Me.ZHScrollBar.Margin = New System.Windows.Forms.Padding(10)
        Me.ZHScrollBar.Maximum = 30
        Me.ZHScrollBar.Minimum = 8
        Me.ZHScrollBar.Name = "ZHScrollBar"
        Me.ZHScrollBar.Size = New System.Drawing.Size(280, 39)
        Me.ZHScrollBar.TabIndex = 15
        Me.ZHScrollBar.TabStop = True
        Me.ZHScrollBar.Value = 8
        '
        'ZoomValueLabel
        '
        Me.ZoomValueLabel.AutoSize = True
        Me.ZoomValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ZoomValueLabel.Location = New System.Drawing.Point(344, 480)
        Me.ZoomValueLabel.Name = "ZoomValueLabel"
        Me.ZoomValueLabel.Size = New System.Drawing.Size(24, 20)
        Me.ZoomValueLabel.TabIndex = 43
        Me.ZoomValueLabel.Text = "---"
        '
        'ZValueLabel
        '
        Me.ZValueLabel.AutoSize = True
        Me.ZValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ZValueLabel.Location = New System.Drawing.Point(324, 203)
        Me.ZValueLabel.Name = "ZValueLabel"
        Me.ZValueLabel.Size = New System.Drawing.Size(24, 20)
        Me.ZValueLabel.TabIndex = 42
        Me.ZValueLabel.Text = "---"
        '
        'YValueLabel
        '
        Me.YValueLabel.AutoSize = True
        Me.YValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.YValueLabel.Location = New System.Drawing.Point(629, 78)
        Me.YValueLabel.Name = "YValueLabel"
        Me.YValueLabel.Size = New System.Drawing.Size(24, 20)
        Me.YValueLabel.TabIndex = 41
        Me.YValueLabel.Text = "---"
        '
        'XValueLabel
        '
        Me.XValueLabel.AutoSize = True
        Me.XValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.XValueLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.XValueLabel.Location = New System.Drawing.Point(324, 78)
        Me.XValueLabel.Name = "XValueLabel"
        Me.XValueLabel.Size = New System.Drawing.Size(24, 20)
        Me.XValueLabel.TabIndex = 40
        Me.XValueLabel.Text = "---"
        '
        'CameraCenterButton
        '
        Me.CameraCenterButton.Location = New System.Drawing.Point(314, 258)
        Me.CameraCenterButton.Name = "CameraCenterButton"
        Me.CameraCenterButton.Size = New System.Drawing.Size(97, 75)
        Me.CameraCenterButton.TabIndex = 16
        Me.CameraCenterButton.Text = "To Center (&R)"
        Me.CameraCenterButton.UseVisualStyleBackColor = True
        '
        'XHScrollBar
        '
        Me.XHScrollBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.XHScrollBar.LargeChange = 1
        Me.XHScrollBar.Location = New System.Drawing.Point(21, 68)
        Me.XHScrollBar.Margin = New System.Windows.Forms.Padding(10)
        Me.XHScrollBar.Maximum = 30
        Me.XHScrollBar.Minimum = 8
        Me.XHScrollBar.Name = "XHScrollBar"
        Me.XHScrollBar.Size = New System.Drawing.Size(280, 39)
        Me.XHScrollBar.TabIndex = 13
        Me.XHScrollBar.TabStop = True
        Me.XHScrollBar.Value = 8
        '
        'FocusLabel
        '
        Me.FocusLabel.AutoSize = True
        Me.FocusLabel.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FocusLabel.Location = New System.Drawing.Point(569, 417)
        Me.FocusLabel.Name = "FocusLabel"
        Me.FocusLabel.Size = New System.Drawing.Size(83, 31)
        Me.FocusLabel.TabIndex = 11
        Me.FocusLabel.Text = "Focus"
        '
        'ZoomLabel
        '
        Me.ZoomLabel.AutoSize = True
        Me.ZoomLabel.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZoomLabel.Location = New System.Drawing.Point(124, 417)
        Me.ZoomLabel.Name = "ZoomLabel"
        Me.ZoomLabel.Size = New System.Drawing.Size(79, 31)
        Me.ZoomLabel.TabIndex = 10
        Me.ZoomLabel.Text = "Zoom"
        '
        'YVScrollBar
        '
        Me.YVScrollBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.YVScrollBar.LargeChange = 1
        Me.YVScrollBar.Location = New System.Drawing.Point(496, 34)
        Me.YVScrollBar.Maximum = 30
        Me.YVScrollBar.Minimum = 8
        Me.YVScrollBar.Name = "YVScrollBar"
        Me.YVScrollBar.Size = New System.Drawing.Size(40, 271)
        Me.YVScrollBar.TabIndex = 14
        Me.YVScrollBar.TabStop = True
        Me.YVScrollBar.Value = 8
        '
        'ZLabel
        '
        Me.ZLabel.AutoSize = True
        Me.ZLabel.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZLabel.Location = New System.Drawing.Point(155, 142)
        Me.ZLabel.Name = "ZLabel"
        Me.ZLabel.Size = New System.Drawing.Size(29, 31)
        Me.ZLabel.TabIndex = 9
        Me.ZLabel.Text = "Z"
        '
        'YLabel
        '
        Me.YLabel.AutoSize = True
        Me.YLabel.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YLabel.Location = New System.Drawing.Point(449, 22)
        Me.YLabel.Name = "YLabel"
        Me.YLabel.Size = New System.Drawing.Size(30, 31)
        Me.YLabel.TabIndex = 7
        Me.YLabel.Text = "Y"
        '
        'XLabel
        '
        Me.XLabel.AutoSize = True
        Me.XLabel.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLabel.Location = New System.Drawing.Point(128, 22)
        Me.XLabel.Name = "XLabel"
        Me.XLabel.Size = New System.Drawing.Size(30, 31)
        Me.XLabel.TabIndex = 6
        Me.XLabel.Text = "X"
        '
        'LEDGroupBox
        '
        Me.LEDGroupBox.BackColor = System.Drawing.Color.White
        Me.LEDGroupBox.Controls.Add(Me.BlueDisplayLabel)
        Me.LEDGroupBox.Controls.Add(Me.GreenDisplayLabel)
        Me.LEDGroupBox.Controls.Add(Me.RedDisplayLabel)
        Me.LEDGroupBox.Controls.Add(Me.BlueTrackBar)
        Me.LEDGroupBox.Controls.Add(Me.GreenTrackBar)
        Me.LEDGroupBox.Controls.Add(Me.RedTrackBar)
        Me.LEDGroupBox.Controls.Add(Me.HexDisplayLabel)
        Me.LEDGroupBox.Controls.Add(Me.ClearColorButton)
        Me.LEDGroupBox.Controls.Add(Me.SetColorButton)
        Me.LEDGroupBox.Controls.Add(Me.BlueTextBox)
        Me.LEDGroupBox.Controls.Add(Me.GreenTextBox)
        Me.LEDGroupBox.Controls.Add(Me.RedTextBox)
        Me.LEDGroupBox.Controls.Add(Me.LEDPictureBox)
        Me.LEDGroupBox.Controls.Add(Me.BlueLabel)
        Me.LEDGroupBox.Controls.Add(Me.GreenLabel)
        Me.LEDGroupBox.Controls.Add(Me.RedLabel)
        Me.LEDGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LEDGroupBox.Location = New System.Drawing.Point(830, 55)
        Me.LEDGroupBox.Name = "LEDGroupBox"
        Me.LEDGroupBox.Size = New System.Drawing.Size(576, 496)
        Me.LEDGroupBox.TabIndex = 3
        Me.LEDGroupBox.TabStop = False
        Me.LEDGroupBox.Text = "LED Colour"
        '
        'BlueDisplayLabel
        '
        Me.BlueDisplayLabel.AutoSize = True
        Me.BlueDisplayLabel.BackColor = System.Drawing.Color.Black
        Me.BlueDisplayLabel.ForeColor = System.Drawing.Color.White
        Me.BlueDisplayLabel.Location = New System.Drawing.Point(150, 291)
        Me.BlueDisplayLabel.Name = "BlueDisplayLabel"
        Me.BlueDisplayLabel.Size = New System.Drawing.Size(20, 20)
        Me.BlueDisplayLabel.TabIndex = 43
        Me.BlueDisplayLabel.Text = "B"
        '
        'GreenDisplayLabel
        '
        Me.GreenDisplayLabel.AutoSize = True
        Me.GreenDisplayLabel.BackColor = System.Drawing.Color.Black
        Me.GreenDisplayLabel.ForeColor = System.Drawing.Color.White
        Me.GreenDisplayLabel.Location = New System.Drawing.Point(148, 189)
        Me.GreenDisplayLabel.Name = "GreenDisplayLabel"
        Me.GreenDisplayLabel.Size = New System.Drawing.Size(22, 20)
        Me.GreenDisplayLabel.TabIndex = 42
        Me.GreenDisplayLabel.Text = "G"
        '
        'RedDisplayLabel
        '
        Me.RedDisplayLabel.AutoSize = True
        Me.RedDisplayLabel.BackColor = System.Drawing.Color.Black
        Me.RedDisplayLabel.ForeColor = System.Drawing.Color.White
        Me.RedDisplayLabel.Location = New System.Drawing.Point(149, 90)
        Me.RedDisplayLabel.Name = "RedDisplayLabel"
        Me.RedDisplayLabel.Size = New System.Drawing.Size(21, 20)
        Me.RedDisplayLabel.TabIndex = 41
        Me.RedDisplayLabel.Text = "R"
        '
        'BlueTrackBar
        '
        Me.BlueTrackBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BlueTrackBar.Location = New System.Drawing.Point(189, 266)
        Me.BlueTrackBar.Maximum = 255
        Me.BlueTrackBar.Name = "BlueTrackBar"
        Me.BlueTrackBar.Size = New System.Drawing.Size(195, 69)
        Me.BlueTrackBar.TabIndex = 7
        Me.BlueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'GreenTrackBar
        '
        Me.GreenTrackBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GreenTrackBar.Location = New System.Drawing.Point(189, 169)
        Me.GreenTrackBar.Maximum = 255
        Me.GreenTrackBar.Name = "GreenTrackBar"
        Me.GreenTrackBar.Size = New System.Drawing.Size(195, 69)
        Me.GreenTrackBar.TabIndex = 6
        Me.GreenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'RedTrackBar
        '
        Me.RedTrackBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RedTrackBar.Location = New System.Drawing.Point(189, 70)
        Me.RedTrackBar.Maximum = 255
        Me.RedTrackBar.Name = "RedTrackBar"
        Me.RedTrackBar.Size = New System.Drawing.Size(195, 69)
        Me.RedTrackBar.TabIndex = 5
        Me.RedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'HexDisplayLabel
        '
        Me.HexDisplayLabel.AutoSize = True
        Me.HexDisplayLabel.BackColor = System.Drawing.Color.White
        Me.HexDisplayLabel.Location = New System.Drawing.Point(434, 189)
        Me.HexDisplayLabel.Name = "HexDisplayLabel"
        Me.HexDisplayLabel.Size = New System.Drawing.Size(39, 20)
        Me.HexDisplayLabel.TabIndex = 37
        Me.HexDisplayLabel.Text = "------"
        '
        'ClearColorButton
        '
        Me.ClearColorButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ClearColorButton.Location = New System.Drawing.Point(270, 394)
        Me.ClearColorButton.Name = "ClearColorButton"
        Me.ClearColorButton.Size = New System.Drawing.Size(114, 78)
        Me.ClearColorButton.TabIndex = 12
        Me.ClearColorButton.Text = "Clear Color Settings  (&B)"
        Me.ClearColorButton.UseVisualStyleBackColor = True
        '
        'SetColorButton
        '
        Me.SetColorButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.SetColorButton.Location = New System.Drawing.Point(144, 394)
        Me.SetColorButton.Name = "SetColorButton"
        Me.SetColorButton.Size = New System.Drawing.Size(110, 78)
        Me.SetColorButton.TabIndex = 11
        Me.SetColorButton.Text = "Set Colour  (&C)"
        Me.SetColorButton.UseVisualStyleBackColor = False
        '
        'BlueTextBox
        '
        Me.BlueTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BlueTextBox.Location = New System.Drawing.Point(22, 288)
        Me.BlueTextBox.Name = "BlueTextBox"
        Me.BlueTextBox.Size = New System.Drawing.Size(100, 26)
        Me.BlueTextBox.TabIndex = 10
        '
        'GreenTextBox
        '
        Me.GreenTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GreenTextBox.ForeColor = System.Drawing.Color.Black
        Me.GreenTextBox.Location = New System.Drawing.Point(22, 189)
        Me.GreenTextBox.Name = "GreenTextBox"
        Me.GreenTextBox.Size = New System.Drawing.Size(100, 26)
        Me.GreenTextBox.TabIndex = 9
        '
        'RedTextBox
        '
        Me.RedTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RedTextBox.ForeColor = System.Drawing.Color.Black
        Me.RedTextBox.Location = New System.Drawing.Point(22, 90)
        Me.RedTextBox.Name = "RedTextBox"
        Me.RedTextBox.Size = New System.Drawing.Size(100, 26)
        Me.RedTextBox.TabIndex = 8
        '
        'LEDPictureBox
        '
        Me.LEDPictureBox.BackColor = System.Drawing.SystemColors.Control
        Me.LEDPictureBox.Location = New System.Drawing.Point(391, 55)
        Me.LEDPictureBox.Name = "LEDPictureBox"
        Me.LEDPictureBox.Size = New System.Drawing.Size(158, 111)
        Me.LEDPictureBox.TabIndex = 21
        Me.LEDPictureBox.TabStop = False
        '
        'BlueLabel
        '
        Me.BlueLabel.AutoSize = True
        Me.BlueLabel.BackColor = System.Drawing.Color.White
        Me.BlueLabel.Font = New System.Drawing.Font("Gill Sans MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueLabel.Location = New System.Drawing.Point(123, 234)
        Me.BlueLabel.Name = "BlueLabel"
        Me.BlueLabel.Size = New System.Drawing.Size(58, 34)
        Me.BlueLabel.TabIndex = 20
        Me.BlueLabel.Text = "Blue"
        '
        'GreenLabel
        '
        Me.GreenLabel.AutoSize = True
        Me.GreenLabel.BackColor = System.Drawing.Color.White
        Me.GreenLabel.Font = New System.Drawing.Font("Gill Sans MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreenLabel.Location = New System.Drawing.Point(114, 132)
        Me.GreenLabel.Name = "GreenLabel"
        Me.GreenLabel.Size = New System.Drawing.Size(79, 34)
        Me.GreenLabel.TabIndex = 19
        Me.GreenLabel.Text = "Green"
        '
        'RedLabel
        '
        Me.RedLabel.AutoSize = True
        Me.RedLabel.BackColor = System.Drawing.Color.White
        Me.RedLabel.Font = New System.Drawing.Font("Gill Sans MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedLabel.Location = New System.Drawing.Point(123, 22)
        Me.RedLabel.Name = "RedLabel"
        Me.RedLabel.Size = New System.Drawing.Size(54, 34)
        Me.RedLabel.TabIndex = 18
        Me.RedLabel.Text = "Red"
        '
        'ExtiButton
        '
        Me.ExtiButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExtiButton.ForeColor = System.Drawing.Color.Black
        Me.ExtiButton.Location = New System.Drawing.Point(859, 622)
        Me.ExtiButton.Name = "ExtiButton"
        Me.ExtiButton.Size = New System.Drawing.Size(93, 56)
        Me.ExtiButton.TabIndex = 20
        Me.ExtiButton.Text = "Exit "
        Me.ExtiButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PortComboBox
        '
        Me.PortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PortComboBox.FormattingEnabled = True
        Me.PortComboBox.Location = New System.Drawing.Point(1221, 605)
        Me.PortComboBox.Name = "PortComboBox"
        Me.PortComboBox.Size = New System.Drawing.Size(121, 28)
        Me.PortComboBox.TabIndex = 1
        '
        'SerialPortLabel
        '
        Me.SerialPortLabel.AutoSize = True
        Me.SerialPortLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SerialPortLabel.Location = New System.Drawing.Point(1217, 571)
        Me.SerialPortLabel.Name = "SerialPortLabel"
        Me.SerialPortLabel.Size = New System.Drawing.Size(86, 20)
        Me.SerialPortLabel.TabIndex = 39
        Me.SerialPortLabel.Text = "Serial Port "
        '
        'RefreshButton
        '
        Me.RefreshButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RefreshButton.Location = New System.Drawing.Point(1348, 605)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(84, 39)
        Me.RefreshButton.TabIndex = 2
        Me.RefreshButton.Text = "Refresh"
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'PTZGUI
        '
        Me.AcceptButton = Me.RefreshButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.CancelButton = Me.ExtiButton
        Me.ClientSize = New System.Drawing.Size(1519, 710)
        Me.Controls.Add(Me.RefreshButton)
        Me.Controls.Add(Me.SerialPortLabel)
        Me.Controls.Add(Me.PortComboBox)
        Me.Controls.Add(Me.ExtiButton)
        Me.Controls.Add(Me.LEDGroupBox)
        Me.Controls.Add(Me.CameraGroupBox)
        Me.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Name = "PTZGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PTZ Control"
        Me.CameraGroupBox.ResumeLayout(False)
        Me.CameraGroupBox.PerformLayout()
        Me.LEDGroupBox.ResumeLayout(False)
        Me.LEDGroupBox.PerformLayout()
        CType(Me.BlueTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GreenTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RedTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CameraGroupBox As GroupBox
    Friend WithEvents FocusLabel As Label
    Friend WithEvents ZoomLabel As Label
    Friend WithEvents ZLabel As Label
    Friend WithEvents YLabel As Label
    Friend WithEvents XLabel As Label
    Friend WithEvents LEDGroupBox As GroupBox
    Friend WithEvents ExtiButton As Button
    Friend WithEvents BlueLabel As Label
    Friend WithEvents GreenLabel As Label
    Friend WithEvents RedLabel As Label
    Friend WithEvents LEDPictureBox As PictureBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents YVScrollBar As VScrollBar
    Friend WithEvents BlueTextBox As TextBox
    Friend WithEvents GreenTextBox As TextBox
    Friend WithEvents RedTextBox As TextBox
    Friend WithEvents ClearColorButton As Button
    Friend WithEvents SetColorButton As Button
    Friend WithEvents XHScrollBar As HScrollBar
    Friend WithEvents CameraCenterButton As Button
    Friend WithEvents ZoomValueLabel As Label
    Friend WithEvents ZValueLabel As Label
    Friend WithEvents YValueLabel As Label
    Friend WithEvents XValueLabel As Label
    Friend WithEvents ZHScrollBar As HScrollBar
    Friend WithEvents ZoomHScrollBar As HScrollBar
    Friend WithEvents FocusValueLabel As Label
    Friend WithEvents FocusHScrollBar As HScrollBar
    Friend WithEvents LensButton As Button
    Friend WithEvents HexDisplayLabel As Label
    Friend WithEvents RedTrackBar As TrackBar
    Friend WithEvents GreenTrackBar As TrackBar
    Friend WithEvents BlueTrackBar As TrackBar
    Friend WithEvents RedDisplayLabel As Label
    Friend WithEvents GreenDisplayLabel As Label
    Friend WithEvents BlueDisplayLabel As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PortComboBox As ComboBox
    Friend WithEvents SerialPortLabel As Label
    Friend WithEvents RefreshButton As Button
End Class
