Public Class UserForm
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel

    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = SaveBtn
        CancelButton = CancelBtn

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateInfo(NameTextBox.Text) AndAlso
            ValidateInfo(UsernameTextBox.Text) AndAlso
            ValidateInfo(PasswordTextBox.Text) Then
            AddUser()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub AddUser()
        Dim DataPath As String = "G:\Visual Studio\Visual Basic\NewsTask1\Data\Users\"
        Dim Data = NameTextBox.Text & "," &
                    UsernameTextBox.Text & "," &
                    PasswordTextBox.Text
        WriteUtil.WriteData(DataPath, Data)

    End Sub

    Private Function ValidateInfo(text As String) As Boolean
        Return text <> String.Empty
    End Function
End Class