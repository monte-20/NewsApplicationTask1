Public Class ImageArticle
    Dim items() As String = Nothing
    Private filePath As String = String.Empty
    Private data As String

    Public Sub New()
        InitializeComponent()

    End Sub

    Public Sub New(filePath As String, data As String)
        InitializeComponent()
        Me.filePath = filePath
        Me.data = data
        items = data.Split(",")
        TitleTextBox.Text = items(0)
        DescriptionTextBox.Text = items(1)
        PathTextBox.Text = items(2)
        BodyTextBox.Text = items(3)
    End Sub


    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        Dim filename As String
        Dim result As DialogResult
        Using fileChooser As New OpenFileDialog
            result = fileChooser.ShowDialog
            filename = fileChooser.FileName
        End Using
        If result <> DialogResult.Cancel Then
            PathTextBox.Text = filename
            ImageBox.Image = New Bitmap(filename)
        End If
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateInfo(PathTextBox.Text) AndAlso
            ValidateInfo(BodyTextBox.Text) AndAlso
           ValidateInfo(DescriptionTextBox.Text) AndAlso
           ValidateInfo(TitleTextBox.Text) Then
            AddImage()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AddImage()
        Dim DataPath As String = "G:\Visual Studio\Visual Basic\NewsTask1\Data\Photos\"
        Dim Data As String = TitleTextBox.Text & "," &
                         DescriptionTextBox.Text & "," &
                         PathTextBox.Text & "," &
                         BodyTextBox.Text
        If filePath <> String.Empty Then
            WriteUtil.UpdateData(filePath, Data)
        Else
            WriteUtil.WriteData(DataPath, Data)

        End If
    End Sub

    Private Function ValidateInfo(text As String) As Boolean
        Return text <> String.Empty
    End Function
End Class