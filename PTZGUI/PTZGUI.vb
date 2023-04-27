'PRZ Camera Project
'PRZ and LED Ring controller
'3/27/2023 
'Jessica McArthur


'TODO not crash when take out COMM port
'TODO delet controls decatiation from program



' Program to gathers input from user and sent to the camera mount and LED to move camera as user wants. 

Option Strict On
Option Explicit On

Public Class PTZGUI
    Dim portA As String
    Dim selectionSave As String
    Dim sendData As Boolean = False
    ' Dim controlsActive As Boolean = False

    Dim redVariable, greenVariable, blueVariable As Integer
    Dim isRedValid, isGreenValid, isBlueValid As Boolean

    'Starts program to default setting.
    'Clears combo box of of items and loads all ports with a serial port into the combobox.
    'LED is off and camera is connected to last positon (center position).
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        LoadPorts()
        'PortComboBox.Items.Clear()
        'PortComboBox.Items.Add("")
        'For Each sp As String In My.Computer.Ports.SerialPortNames
        '    PortComboBox.Items.Add(sp)
        'Next
        ResetColor()
        FormerCameraPosition()

    End Sub

    'Code for selecting serial port adapted from Ryan Wildblood PTZ camera project (2019)
    Private Sub PortComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PortComboBox.SelectedIndexChanged
        If PortComboBox.Text = "" Then
            'Closes serial port from changing inputs.
            SerialPort1.Close()
            'controlsActive = False
        Else
            If portA <> PortComboBox.Text Then
                'Saves port that was selected if not equal to previously saved port.
                portA = PortComboBox.Text

                Try
                    SerialPort1.Close()
                    SerialPort1.PortName = portA
                    SerialPort1.BaudRate = 9600  '9600 baud rate
                    SerialPort1.DataBits = 8      '8 data bits
                    SerialPort1.StopBits = IO.Ports.StopBits.One   '1 stop bit
                    SerialPort1.Parity = IO.Ports.Parity.None       'no Parity
                    SerialPort1.Open()
                    Timer1.Enabled = True

                    'Saves selected port name.

                    selectionSave = PortComboBox.Text
                    sendData = True
                    'controlsActive = True

                Catch ex As Exception

                    'Displays message box, if error occurs.
                    MessageBox.Show("Error- Select another port")
                    'htfj
                    sendData = False
                    'hhfgj
                    PortComboBox.Text = selectionSave

                End Try
            End If
        End If
    End Sub
    'hkjlklgjfjhf
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim arrSendByte(9) As Byte
        Timer1.Enabled = False

        sendData = True


        arrSendByte(0) = CByte(Hex(36))
            arrSendByte(1) = CByte(RedTrackBar.Value)
            arrSendByte(2) = CByte(GreenTrackBar.Value)
            arrSendByte(3) = CByte(BlueTrackBar.Value)
            arrSendByte(4) = CByte(XHScrollBar.Value)
            arrSendByte(5) = CByte(YVScrollBar.Value)
            arrSendByte(6) = CByte(ZHScrollBar.Value)
            arrSendByte(7) = CByte(ZoomHScrollBar.Value)
        arrSendByte(8) = CByte(FocusHScrollBar.Value)

        Try
            SerialPort1.Write(arrSendByte, 0, 9)
            Timer1.Enabled = True
            'sendData = False
        Catch ex As Exception

            MessageBox.Show("Error-Serial port is disconnected")
            'sendData = False
            SerialPort1.Close()
            PortComboBox.Text = ""
        End Try


        sendData = False
    End Sub
    'Clears port combobox of past items and  loads all current ports with serial ports to combobox. 
    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        LoadPorts()
        'PortComboBox.Items.Clear()

        'PortComboBox.Items.Add("")
        'For Each sp As String In My.Computer.Ports.SerialPortNames
        '    PortComboBox.Items.Add(sp)
        'Next
    End Sub

    Sub LoadPorts()
        PortComboBox.Items.Clear()

        PortComboBox.Items.Add("")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            PortComboBox.Items.Add(sp)
        Next
    End Sub



    'Validates color number value inputs. Input for each color must be a integer between 0- 255
    Function ColorInputValid() As Boolean

        '*uses in several different subs.....
        'Dim isRedValid As Boolean
        'Dim isGreenValid As Boolean
        'Dim isBlueValid As Boolean

        'Validates Red input
        Try
            redVariable = CInt(RedTextBox.Text)
            isRedValid = False
            If redVariable < 0 Or redVariable > 255 Then
                isRedValid = False
                ErrorMessage("Red Input must be between 0 -255")
                RedTextBox.Clear()
                RedTextBox.Focus()
            Else
                isRedValid = True
            End If
        Catch
            RedTextBox.Focus()
            isRedValid = False
            ErrorMessage("Red input is not valid")
            RedTextBox.Clear()
        End Try
        'Validates Green input
        Try
            greenVariable = CInt(GreenTextBox.Text)
            isGreenValid = False
            If greenVariable < 0 Or greenVariable > 255 Then
                isGreenValid = False
                ErrorMessage("Green Input must be between 0-255")
                GreenTextBox.Clear()
                GreenTextBox.Focus()
            Else
                isGreenValid = True
            End If
        Catch
            GreenTextBox.Focus()
            isGreenValid = False
            ErrorMessage("Green input is not valid")
            GreenTextBox.Clear()
        End Try
        'Validates Blue input
        Try
            blueVariable = CInt(BlueTextBox.Text)
            isBlueValid = False
            If blueVariable < 0 Or blueVariable > 255 Then
                isBlueValid = False
                ErrorMessage("Blue Input must be between 0-255")
                BlueTextBox.Clear()
                BlueTextBox.Focus()
            Else
                isBlueValid = True
            End If
        Catch
            BlueTextBox.Focus()
            isBlueValid = False
            ErrorMessage("Blue input is must be number")
            BlueTextBox.Clear()
        End Try
        'Sets up error message ?????????
        If ErrorMessage() <> "" Then
            MsgBox(ErrorMessage())
            ErrorMessage(, True)
        End If

        Return isRedValid
        Return isGreenValid
        Return isBlueValid
    End Function

    'Function to sent all error messages to one message
    Private Function ErrorMessage(Optional newMessage As String = "",
               Optional clear As Boolean = False) As String
        Static _message As String

        Select Case clear
            Case False
                If newMessage <> "" Then
                    _message &= newMessage & vbCrLf
                End If
            Case Else
                _message = ""
        End Select
        Return _message
    End Function

    'Sets color of picture box
    Sub SetColor()

        If isRedValid = True And isGreenValid = True And isBlueValid = True Then

            redVariable = CInt(RedTextBox.Text)
            greenVariable = CInt(GreenTextBox.Text)
            blueVariable = CInt(BlueTextBox.Text)

            'Displays the set color off LED in picture box or text box.
            LEDPictureBox.BackColor = Color.FromArgb(redVariable, greenVariable, blueVariable)

            'Updates tracker bars for each color when valid input is put into color textbox. 
            RedTrackBar.Value = CInt(RedTextBox.Text)
            RedDisplayLabel.Text = CStr(RedTrackBar.Value)
            RedDisplayLabel.BackColor = Color.FromArgb(RedTrackBar.Value, 0, 0)

            GreenTrackBar.Value = CInt(GreenTextBox.Text)
            GreenDisplayLabel.Text = CStr(GreenTrackBar.Value)
            GreenDisplayLabel.BackColor = Color.FromArgb(0, GreenTrackBar.Value, 0)

            BlueTrackBar.Value = CInt(BlueTextBox.Text)
            BlueDisplayLabel.Text = CStr(BlueTrackBar.Value)
            BlueDisplayLabel.BackColor = Color.FromArgb(0, 0, BlueTrackBar.Value)

            'Calls function to display integer color settings in Hex (Hex value output is string)
            DisplayHex()

        End If
    End Sub

    'Sets color LED display by changing track bars values. 
    'Changes red value of color with green track bar
    Private Sub RedTrackBar_Scroll(sender As Object, e As EventArgs) Handles RedTrackBar.Scroll
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        RedDisplayLabel.Text = CStr(RedTrackBar.Value)
        RedDisplayLabel.BackColor = Color.FromArgb(RedTrackBar.Value, 0, 0)
        RedTextBox.Text = CStr(RedTrackBar.Value)
        DisplayHexTracker()
    End Sub
    ' Changes green value of color with green track bar.
    Private Sub GreenTrackBar_Scroll(sender As Object, e As EventArgs) Handles GreenTrackBar.Scroll
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        GreenDisplayLabel.Text = CStr(GreenTrackBar.Value)
        GreenDisplayLabel.BackColor = Color.FromArgb(0, GreenTrackBar.Value, 0)
        GreenTextBox.Text = CStr(GreenTrackBar.Value)
        DisplayHexTracker()
    End Sub
    'Changes blue value of color with blue track bar.
    Private Sub BlueTrackBar_Scroll(sender As Object, e As EventArgs) Handles BlueTrackBar.Scroll
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        BlueDisplayLabel.Text = CStr(BlueTrackBar.Value)
        BlueDisplayLabel.BackColor = Color.FromArgb(0, 0, BlueTrackBar.Value)
        BlueTextBox.Text = CStr(BlueTrackBar.Value)
        DisplayHexTracker()
    End Sub


    'Displays integer value of set color as two digit Hex number.  Hex outputs are strings in vb.
    'For colorset by clicking "change color" button.
    Sub DisplayHex()

        Dim redHex, greenHex, blueHex As String
        Dim numberCharatersR, numberCharatersG, numberCharactersB As Integer
        Dim redDisplay, greenDisplay, blueDisplay As String

        'Converts integer color input to hex numbers.
        'Output is a string (setting  of vb)
        redHex = Hex(redVariable)
        greenHex = Hex(greenVariable)
        blueHex = Hex(blueVariable)

        'Count the number of characters in string of each color's hex value.
        numberCharatersR = Len(redHex)
        numberCharatersG = Len(greenHex)
        numberCharactersB = Len(blueHex)


        'Sets display of Hex string to two digits at all times for each color.
        If numberCharatersR < 2 Then
            redDisplay = "0" & redHex
        Else
            redDisplay = redHex
        End If

        If numberCharatersG < 2 Then
            greenDisplay = "0" & greenHex
        Else
            greenDisplay = greenHex
        End If

        If numberCharactersB < 2 Then
            blueDisplay = "0" & blueHex
        Else
            blueDisplay = blueHex
        End If

        'Displays value of setcolor in hex as string.  Hex value displayed as  6 digit number 
        HexDisplayLabel.Text = redDisplay & " - " & greenDisplay & " - " & blueDisplay
    End Sub

    'Display Hex value of color when color inputs set by the trackers.
    'Displayed as string. 
    Sub DisplayHexTracker()
        Dim redHEX, greenHex, blueHex As String
        Dim numberCharatersR, numberCharatersG, numberCharactersB As Integer
        Dim redDisplay, greenDisplay, blueDisplay As String

        'Convert color input to hex numbers.
        'Displayed as strings
        redHEX = Hex(RedTrackBar.Value)
        greenHex = Hex(GreenTrackBar.Value)
        blueHex = Hex(BlueTrackBar.Value)

        'Count the number of characters in string of each color's hex value.
        numberCharatersR = Len(redHEX)
        numberCharatersG = Len(greenHex)
        numberCharactersB = Len(blueHex)

        'Set display of Hex color values to 2 digit display for each color.
        If numberCharatersR < 2 Then
            redDisplay = "0" & redHEX
        Else
            redDisplay = redHEX

        End If

        If numberCharatersG < 2 Then
            greenDisplay = "0" & greenHex
        Else
            greenDisplay = greenHex

        End If

        If numberCharactersB < 2 Then
            blueDisplay = "0" & blueHex
        Else
            blueDisplay = blueHex

        End If

        'Displays 6 digit hex number of color.  
        'Displayed as string.
        HexDisplayLabel.Text = redDisplay & " - " & greenDisplay & " - " & blueDisplay
    End Sub
    'Resets function to default (off/ black)
    Sub ResetColor()
        'Clears color input text boxes
        RedTextBox.Clear()
        GreenTextBox.Clear()
        BlueTextBox.Clear()
        'Resets color sliders to 0
        RedTrackBar.Value = 0
        GreenTrackBar.Value = 0
        BlueTrackBar.Value = 0
        'Sets LED display to off/black
        LEDPictureBox.BackColor = Color.FromArgb(0, 0, 0)
        'Resets color display text boxes.
        RedDisplayLabel.Text = "R"
        GreenDisplayLabel.Text = "G"
        BlueDisplayLabel.Text = "B"
        'Sets hex display textbox to "off"
        HexDisplayLabel.Text = "LED OFF"
    End Sub


    'Button - Sets selected color from user input
    Private Sub SetColorButton_Click(sender As Object, e As EventArgs) Handles SetColorButton.Click
        ColorInputValid()
        SetColor()
    End Sub

    'Button - Resets color section set to default setting (LED off). 
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearColorButton.Click
        ResetColor()
    End Sub


    ' Buttons that control camera's position on X,Y,Z axis and lens settings of zoom and focus
    'Scroll bar to adjust x position of camera (position of camera across room).
    Private Sub XHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles XHScrollBar.Scroll
        XValueLabel.Text = CStr(XHScrollBar.Value)
    End Sub
    'Scroll bar to adjust y position of camera (lens).
    Private Sub YVScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles YVScrollBar.Scroll
        YValueLabel.Text = CStr(YVScrollBar.Value)
    End Sub
    'Scroll bar to adjust z positon of camera (lens).
    Private Sub ZHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles ZHScrollBar.Scroll
        ZValueLabel.Text = CStr(ZHScrollBar.Value)
    End Sub
    'Scroll bar to adjust zoom of lens.
    Private Sub ZoomHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles ZoomHScrollBar.Scroll
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
    End Sub
    ' Scroll bar to adjust focus of lens. 
    Private Sub FocusHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles FocusHScrollBar.Scroll
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub


    'Button- Returns camera to center of room. 
    Private Sub CameraHomeButton_Click(sender As Object, e As EventArgs) Handles CameraCenterButton.Click
        'Resets camera to center position
        XHScrollBar.Value = 127
        YVScrollBar.Value = 128
        ZHScrollBar.Value = 127
        XValueLabel.Text = CStr(XHScrollBar.Value)
        YValueLabel.Text = CStr(YVScrollBar.Value)
        ZValueLabel.Text = CStr(ZHScrollBar.Value)

    End Sub

    'Button- Sets lens position to off or default.
    Private Sub LensButton_Click(sender As Object, e As EventArgs) Handles LensButton.Click
        'Lens position to default
        ZoomHScrollBar.Value = 127
        FocusHScrollBar.Value = 127
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub

    'Connects to Camera at its last position
    ' TODO once set to serial communication ..... will connect camera to last setting. 
    Sub FormerCameraPosition()
        'Camera values set to camera's current positon on rail. 
        XHScrollBar.Value = 127
        YVScrollBar.Value = 128
        ZHScrollBar.Value = 127
        XValueLabel.Text = CStr(XHScrollBar.Value)
        YValueLabel.Text = CStr(YVScrollBar.Value)
        ZValueLabel.Text = CStr(ZHScrollBar.Value)
        'Lens position to default
        ZoomHScrollBar.Value = 127
        FocusHScrollBar.Value = 127
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub




    'Button - Closes the program
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExtiButton.Click
        Me.Close()
    End Sub

End Class
