'PRZ Camera Project
'PRZ and LED Ring controller
'3/27/2023 
'Jessica McArthur



'TODO clean up-  scrollbars arrow key fixed(?)...and such

'TODO camera function set camera at position on rail.  Use with Serial Data.



' Program to gathers input from user and sent to the camera mount and LED to move camera as user wants. 

Option Strict On
Option Explicit On

Public Class PTZGUI

    Dim redVariable, greenVariable, blueVariable As Integer
    Dim isRedValid, isGreenValid, isBlueValid As Boolean





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

    'Function to sent all error messages in message
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
            LEDTextBox.BackColor = Color.FromArgb(redVariable, greenVariable, blueVariable)
            LEDPictureBox.BackColor = Color.FromArgb(redVariable, greenVariable, blueVariable)

            'Combines color systems 
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

    Private Sub RedTrackBar_Scroll(sender As Object, e As EventArgs) Handles RedTrackBar.Scroll
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        RedDisplayLabel.Text = CStr(RedTrackBar.Value)
        RedDisplayLabel.BackColor = Color.FromArgb(RedTrackBar.Value, 0, 0)
        RedTextBox.Text = CStr(RedTrackBar.Value)
        DisplayHexTracker()
    End Sub

    Private Sub GreenTrackBar_Scroll(sender As Object, e As EventArgs) Handles GreenTrackBar.Scroll
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        GreenDisplayLabel.Text = CStr(GreenTrackBar.Value)
        GreenDisplayLabel.BackColor = Color.FromArgb(0, GreenTrackBar.Value, 0)
        GreenTextBox.Text = CStr(GreenTrackBar.Value)
        DisplayHexTracker()
    End Sub

    Private Sub BlueTrackBar_Scroll(sender As Object, e As EventArgs) Handles BlueTrackBar.Scroll
        LEDPictureBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value)
        BlueDisplayLabel.Text = CStr(BlueTrackBar.Value)
        BlueDisplayLabel.BackColor = Color.FromArgb(0, 0, BlueTrackBar.Value)
        BlueTextBox.Text = CStr(BlueTrackBar.Value)
        DisplayHexTracker()
    End Sub


    'Displays integer value of set color as two digit Hex number.  Hex outputs are strings in vb.
    Sub DisplayHex()

        Dim redHex, greenHex, blueHex As String
        Dim numberCharatersR, numberCharatersG, numberCharactersB As Integer
        Dim redDisplay, greenDisplay, blueDisplay As String

        'Converts integer color input to hex numbers.
        'Output is a string (vb, setting)
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
        IndicatorTextBox.Text = redDisplay & " - " & greenDisplay & " - " & blueDisplay
        HexDisplayLabel.Text = redDisplay & " - " & greenDisplay & " - " & blueDisplay
    End Sub

    'Display Hex value of color when color inputs set by the trackers. Displayed as string. 
    Sub DisplayHexTracker()
        Dim redHEX, greenHex, blueHex As String
        Dim numberCharatersR, numberCharatersG, numberCharactersB As Integer
        Dim redDisplay, greenDisplay, blueDisplay As String

        'Convert color input to hex numbers.
        'displayed as strings
        redHEX = Hex(RedTrackBar.Value)
        greenHex = Hex(GreenTrackBar.Value)
        blueHex = Hex(BlueTrackBar.Value)

        'Count the number of characters in string of each color's hex value.
        numberCharatersR = Len(redHEX)
        numberCharatersG = Len(greenHex)
        numberCharactersB = Len(blueHex)

        'Set display of Hex color values to digit display.
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

        HexDisplayLabel.Text = redDisplay & " - " & greenDisplay & " - " & blueDisplay
    End Sub
    'Resets function to default (off/ black)
    Sub ResetColor()
        'Clears all text boxes
        RedTextBox.Clear()
        GreenTextBox.Clear()
        BlueTextBox.Clear()
        'Displays all color sliders as 0
        RedTrackBar.Value = 0
        GreenTrackBar.Value = 0
        BlueTrackBar.Value = 0
        'Sets LED display to off/black
        LEDTextBox.BackColor = Color.FromArgb(0, 0, 0)
        LEDPictureBox.BackColor = Color.FromArgb(0, 0, 0)
        RedDisplayLabel.Text = "0"
        GreenDisplayLabel.Text = "0"
        BlueDisplayLabel.Text = "B"
        IndicatorTextBox.Text = "LED OFF"
        HexDisplayLabel.Text = "LED OFF"
    End Sub



    ' Buttons for color section

    'user selected color
    Private Sub SetColorButton_Click(sender As Object, e As EventArgs) Handles SetColorButton.Click
        ColorInputValid()
        SetColor()
    End Sub

    'Color section set to default setting (LED off), when program opens. 
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearColorButton.Click
        ResetColor()
    End Sub


    ' Buttons that control camera's position on X,Y,Z axis and lens settings of zoom and focus
    Private Sub XHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles XHScrollBar.Scroll
        XValueLabel.Text = CStr(XHScrollBar.Value)
    End Sub

    Private Sub YVScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles YVScrollBar.Scroll
        YValueLabel.Text = CStr(YVScrollBar.Value)
    End Sub

    Private Sub ZHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles ZHScrollBar.Scroll
        ZValueLabel.Text = CStr(ZHScrollBar.Value)
    End Sub

    Private Sub ZoomHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles ZoomHScrollBar.Scroll
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
    End Sub


    Private Sub FocusHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles FocusHScrollBar.Scroll
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub

    Private Sub CameraHomeButton_Click(sender As Object, e As EventArgs) Handles CameraCenterButton.Click
        'Resets camera to center position
        XHScrollBar.Value = 127
        YVScrollBar.Value = 128
        ZHScrollBar.Value = 127
        XValueLabel.Text = CStr(XHScrollBar.Value)
        YValueLabel.Text = CStr(YVScrollBar.Value)
        ZValueLabel.Text = CStr(ZHScrollBar.Value)

    End Sub
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
        ZValueLabel.Text = CStr(ZoomHScrollBar.Value)
        'Lens position to default
        ZoomHScrollBar.Value = 127
        FocusHScrollBar.Value = 127
        ZoomValueLabel.Text = CStr(ZoomHScrollBar.Value)
        FocusValueLabel.Text = CStr(FocusHScrollBar.Value)
    End Sub










    'Closes the program
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExtiButton.Click
        Me.Close()
    End Sub

    'Starts program to default setting
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetColor()
        FormerCameraPosition()
    End Sub

End Class
