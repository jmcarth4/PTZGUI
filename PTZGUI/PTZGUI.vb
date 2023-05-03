'PRZ Camera Project
'PRZ Camera and LED Ring Control GUI
'3/27/2023 
'Jessica McArthur

' Program gathers input from user about wanted camera position and LED color
' Then it converts inputs into byte array and sends the array over
' serial communication to the master board.

Option Strict On
Option Explicit On

Public Class PTZGUI
    Dim portA As String
    Dim selectionSave As String
    Dim sendData As Boolean = False
    Dim redVariable, greenVariable, blueVariable As Integer
    Dim isRedValid, isGreenValid, isBlueValid As Boolean

    'Starts program to default setting.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Calls sub that clears combo box of items and loads all ports with a serial connection into the combobox.
        LoadPorts()
        'Calls sub that sets LED indicator is off and all color inputs to 0 or emptied. 
        ResetColor()
        'Calls sub that set camera position scrollbars to center position.
        FormerCameraPosition()
    End Sub

    'Clears port combobox of past items and loads all current ports with serial communication to port combobox. 
    Sub LoadPorts()
        'Clears port combobox and add blank line. 
        PortComboBox.Items.Clear()
        PortComboBox.Items.Add("")
        'Adds active serial ports to the port combo box. 
        For Each sp As String In My.Computer.Ports.SerialPortNames
            PortComboBox.Items.Add(sp)
        Next
    End Sub

    'Code for selecting serial port adapted from Ryan Wildblood PTZ Camera Project (2019)
    Private Sub PortComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PortComboBox.SelectedIndexChanged

        If PortComboBox.Text = "" Then
            'Closes serial port from changing inputs.
            SerialPort1.Close()
        Else
            If portA <> PortComboBox.Text Then
                'Saves port that was selected if not equal to previously saved port.
                portA = PortComboBox.Text

                Try
                    SerialPort1.Close()
                    SerialPort1.PortName = portA
                    SerialPort1.BaudRate = 9600                    '9600 baud rate
                    SerialPort1.DataBits = 8                       '8 data bits
                    SerialPort1.StopBits = IO.Ports.StopBits.One   '1 stop bit
                    SerialPort1.Parity = IO.Ports.Parity.None      'no Parity
                    SerialPort1.Open()
                    Timer1.Enabled = True

                    'Saves selected port name.
                    selectionSave = PortComboBox.Text
                    'Allows program to send data.
                    sendData = True

                Catch ex As Exception
                    'Displays message box, if invalid port is selected.
                    ErrorMessage("Error - Select another port")
                    'Disables ability to send data. 
                    sendData = False
                    'Sends error message to message function.
                    If ErrorMessage() <> "" Then
                        MsgBox(ErrorMessage())
                        ErrorMessage(, True)
                    End If
                    'Selects next active port in Port Combobox. 
                    PortComboBox.Text = selectionSave
                End Try
            End If
        End If
    End Sub

    'Populates byte array and writes serial data at set interval.
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim arrSendByte(9) As Byte

        'Timer disabled when trying to send data
        Timer1.Enabled = False
        'Enble program to send data.
        sendData = True

        'Converts and populates byte array with users inputs.
        arrSendByte(0) = CByte(Hex(36))
        arrSendByte(1) = CByte(RedTrackBar.Value)
        arrSendByte(2) = CByte(GreenTrackBar.Value)
        arrSendByte(3) = CByte(BlueTrackBar.Value)
        arrSendByte(4) = CByte(XHScrollBar.Value)
        arrSendByte(5) = CByte(YVScrollBar.Value)
        arrSendByte(6) = CByte(ZHScrollBar.Value)
        arrSendByte(7) = CByte(ZoomHScrollBar.Value)
        arrSendByte(8) = CByte(FocusHScrollBar.Value)

        ' Verifies if port is available to send data.
        Try
            'Writes serial data to port.
            SerialPort1.Write(arrSendByte, 0, 9)
            'Timer enabled
            Timer1.Enabled = True
        Catch ex As Exception
            'Displays error message of disconnected port
            ErrorMessage("Error - Port is disconnected")
            SerialPort1.Close()
            If ErrorMessage() <> "" Then
                MsgBox(ErrorMessage())
                ErrorMessage(, True)
            End If
            'Deselects the disconnected port in the combobox.
            PortComboBox.Text = ""
        End Try

        'Disables programs ablity to send data. 
        sendData = False
    End Sub

    'Button - updates connected serial ports.
    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        'Calls function that loads current ports to port combo box. 
        LoadPorts()
    End Sub




    'Sets color of LED indicator. Color can be set by tracker bars or by user inputing numbers.


    'Sets color LED display by changing track bars values. 

    'Changes red value of color with red track bar
    Private Sub RedTrackBar_Scroll(sender As Object, e As EventArgs) Handles RedTrackBar.Scroll
        'Sets the color of the LED indicator picture box.
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        'Displays slider color in label and as back color of the label.
        RedDisplayLabel.Text = CStr(RedTrackBar.Value)
        RedDisplayLabel.BackColor = Color.FromArgb(RedTrackBar.Value, 0, 0)
        'Updates user input textbox for red.
        RedTextBox.Text = CStr(RedTrackBar.Value)
        'Calls function to display hex value of LED indicator picture box, when LED color is set by trackers.
        DisplayHexTracker()
    End Sub

    ' Changes green value of color with green track bar.
    Private Sub GreenTrackBar_Scroll(sender As Object, e As EventArgs) Handles GreenTrackBar.Scroll
        'Sets the color of the LED indicator picture box.
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        'Displays slider color in label and as back color of the label.
        GreenDisplayLabel.Text = CStr(GreenTrackBar.Value)
        GreenDisplayLabel.BackColor = Color.FromArgb(0, GreenTrackBar.Value, 0)
        'Updates user input textbox for green.
        GreenTextBox.Text = CStr(GreenTrackBar.Value)
        'Calls function to display hex value of LED indicator picture box, when LED color is set by trackers.
        DisplayHexTracker()
    End Sub

    'Changes blue value of color with blue track bar.
    Private Sub BlueTrackBar_Scroll(sender As Object, e As EventArgs) Handles BlueTrackBar.Scroll
        'Sets the color of the LED indicator picture box.
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        'Displays slider color in label and as back color of the label.
        BlueDisplayLabel.Text = CStr(BlueTrackBar.Value)
        BlueDisplayLabel.BackColor = Color.FromArgb(0, 0, BlueTrackBar.Value)
        'Updates user input textbox for blue.
        BlueTextBox.Text = CStr(BlueTrackBar.Value)
        'Calls function to display hex value of LED indicator picture box, when LED color is set by trackers.
        DisplayHexTracker()
    End Sub

    'Display Hex value of color when color inputs set by the trackers.
    Sub DisplayHexTracker()
        Dim redHEX, greenHex, blueHex As String
        Dim numberCharatersR, numberCharatersG, numberCharactersB As Integer
        Dim redDisplay, greenDisplay, blueDisplay As String

        'Convert color input to hex numbers.
        'Displayed as strings
        redHEX = Hex(RedTrackBar.Value)
        greenHex = Hex(GreenTrackBar.Value)
        blueHex = Hex(BlueTrackBar.Value)

        'Counts the number of characters in string of each color's hex value.
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


    'Sets color by user integer inputs for Red, Green and Blue. 

    'Validates color number value inputs.
    'Input for each color must be a integer between 0- 255
    Function ColorInputValid() As Boolean

        'Validates Red input
        Try
            'Converts red textbox input to interger
            redVariable = CInt(RedTextBox.Text)
            'Disables red textbox input.
            isRedValid = False
            ' Validates if input is a interger between 0 and 255
            If redVariable < 0 Or redVariable > 255 Then
                isRedValid = False
                ErrorMessage("Red Input must be between 0 -255")
                RedTextBox.Clear()
                RedTextBox.Focus()
            Else
                'Enables red input to be used in further subs.
                isRedValid = True
            End If
        Catch
            'Removes all non integer values and sends error message to user.
            RedTextBox.Focus()
            isRedValid = False
            ErrorMessage("Red input is not valid" & vbNewLine & " - Input must be a number")
            RedTextBox.Clear()
        End Try

        'Validates Green input
        Try
            'Converts green textbox input to interger
            greenVariable = CInt(GreenTextBox.Text)
            'Disables green textbox input.
            isGreenValid = False
            ' Validates if input is a interger between 0 and 255
            If greenVariable < 0 Or greenVariable > 255 Then
                isGreenValid = False
                ErrorMessage("Green Input must be between 0-255")
                GreenTextBox.Clear()
                GreenTextBox.Focus()
            Else
                'Enables green input to be used in further subs.
                isGreenValid = True
            End If
        Catch
            'Removes all non integer values and sends error message to user.
            GreenTextBox.Focus()
            isGreenValid = False
            ErrorMessage("Green input is not valid" & vbNewLine & " - Input must be a number")
            GreenTextBox.Clear()
        End Try

        'Validates Blue input
        Try
            'Converts blue textbox input to interger
            blueVariable = CInt(BlueTextBox.Text)
            'Disables blue textbox input.
            isBlueValid = False
            ' Validates if input is a interger between 0 and 255
            If blueVariable < 0 Or blueVariable > 255 Then
                isBlueValid = False
                ErrorMessage("Blue Input must be between 0-255")
                BlueTextBox.Clear()
                BlueTextBox.Focus()
            Else
                'Enables blue input to be used in further subs.
                isBlueValid = True
            End If
        Catch
            'Removes all non integer values and sends error message to user.
            BlueTextBox.Focus()
            isBlueValid = False
            ErrorMessage("Blue input is not valid" & vbNewLine & " - Input must be a number")
            BlueTextBox.Clear()
        End Try

        'Sends messages to error message function
        If ErrorMessage() <> "" Then
            MsgBox(ErrorMessage())
            ErrorMessage(, True)
        End If

        'Returns boolean values when color inputs are valid
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
                'Display error message if present
                If newMessage <> "" Then
                    _message &= newMessage & vbCrLf
                End If
            Case Else
                'Clear message
                _message = ""
        End Select
        Return _message
    End Function

    'Sets color of picture box (LED indicator) from user inputs in textboxes.
    Sub SetColor()

        If isRedValid = True And isGreenValid = True And isBlueValid = True Then
            'Textbox inputs are converted to integer form.
            redVariable = CInt(RedTextBox.Text)
            greenVariable = CInt(GreenTextBox.Text)
            blueVariable = CInt(BlueTextBox.Text)

            'Displays the set color of LED in picture box.
            LEDPictureBox.BackColor = Color.FromArgb(redVariable, greenVariable, blueVariable)

            'Updates tracker bars and labels for each color when valid input is put into color textbox. 
            RedTrackBar.Value = CInt(RedTextBox.Text)
            RedDisplayLabel.Text = CStr(RedTrackBar.Value)
            RedDisplayLabel.BackColor = Color.FromArgb(RedTrackBar.Value, 0, 0)

            GreenTrackBar.Value = CInt(GreenTextBox.Text)
            GreenDisplayLabel.Text = CStr(GreenTrackBar.Value)
            GreenDisplayLabel.BackColor = Color.FromArgb(0, GreenTrackBar.Value, 0)

            BlueTrackBar.Value = CInt(BlueTextBox.Text)
            BlueDisplayLabel.Text = CStr(BlueTrackBar.Value)
            BlueDisplayLabel.BackColor = Color.FromArgb(0, 0, BlueTrackBar.Value)

            'Calls function to display integer color settings in hex, color LED color is set by trackers.
            DisplayHex()
        End If
    End Sub

    'Displays integer value of set color as two digit Hex number.
    'For colorset by clicking "Change Color" button.
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

        'Displays value of setcolor in hex as string. 
        'Hex value displayed as 6 digit number.
        HexDisplayLabel.Text = redDisplay & " - " & greenDisplay & " - " & blueDisplay
    End Sub

    'Button - Sets selected color from user input
    Private Sub SetColorButton_Click(sender As Object, e As EventArgs) Handles SetColorButton.Click
        'Calls function that validates color input.
        ColorInputValid()
        'Calls sub that set LED indicator color. 
        SetColor()
    End Sub

    'Button - Resets color section set to default setting (LED off) 
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearColorButton.Click
        'Calls sub that resets all color settings.
        ResetColor()
    End Sub


    'Resets function to default (off/ black, text boxes clear and trackers at 0).
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
        'Sets hex display label to "off"
        HexDisplayLabel.Text = "LED OFF"
    End Sub




    ' Buttons that control camera's position on X,Y,Z axis and lens settings of zoom and focus

    'Scrollbar to adjust x position of camera (position of camera across room).
    Private Sub XHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles XHScrollBar.Scroll
        'Displays value of scrollbar in label.
        XValueLabel.Text = CStr(XHScrollBar.Value)
    End Sub

    'Scrollbar to adjust Y position of camera (lens).
    Private Sub YVScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles YVScrollBar.Scroll
        'Displays value of scrollbar in label.
        YValueLabel.Text = CStr(YVScrollBar.Value)
    End Sub

    'Scrollbar to adjust Z positon of camera (lens).
    Private Sub ZHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles ZHScrollBar.Scroll
        'Displays value of scrollbar in label.
        ZValueLabel.Text = CStr(ZHScrollBar.Value)
    End Sub

    'Scrollbar to adjust zoom of lens.
    Private Sub ZoomHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles ZoomHScrollBar.Scroll
        'Displays value of scrollbar in label.
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
    End Sub

    ' Scrollbar to adjust focus of lens. 
    Private Sub FocusHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles FocusHScrollBar.Scroll
        'Displays value of scrollbar in label.
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub

    'Button- Returns camera to center of room. 
    Private Sub CameraHomeButton_Click(sender As Object, e As EventArgs) Handles CameraCenterButton.Click
        'Resets camera to center position
        XHScrollBar.Value = 19
        YVScrollBar.Value = 19
        ZHScrollBar.Value = 19
        'Sets labels to value of scrollbars.
        XValueLabel.Text = CStr(XHScrollBar.Value)
        YValueLabel.Text = CStr(YVScrollBar.Value)
        ZValueLabel.Text = CStr(ZHScrollBar.Value)

    End Sub

    'Button- Sets lens position to off or default.
    Private Sub LensButton_Click(sender As Object, e As EventArgs) Handles LensButton.Click
        'Lens position to default
        ZoomHScrollBar.Value = 19
        FocusHScrollBar.Value = 19
        'Sets labels to value of scrollbars 
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub

    'Sets Camera control scroll bars to center of scroll bars.
    Sub FormerCameraPosition()
        'Camera values set to center of scrollbar. 
        XHScrollBar.Value = 19
        YVScrollBar.Value = 19
        ZHScrollBar.Value = 19
        'Labels sets to value of scrollbars.
        XValueLabel.Text = CStr(XHScrollBar.Value)
        YValueLabel.Text = CStr(YVScrollBar.Value)
        ZValueLabel.Text = CStr(ZHScrollBar.Value)
        'Lens position to default
        ZoomHScrollBar.Value = 19
        FocusHScrollBar.Value = 19
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub


    'Button - Closes the program
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExtiButton.Click
        Me.Close()
    End Sub

End Class
