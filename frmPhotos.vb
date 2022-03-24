Public Class frmPhotos
    Dim PhotoObj As ClsPhotos
    Public Sub New()
        InitializeComponent()
        PhotoObj = New ClsPhotos
    End Sub

    Public Sub New(obj As ClsPhotos)
        InitializeComponent()
        PhotoObj = obj
    End Sub


    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        Dim FileName As String = PhotoObj.BrowsePhoto
        PathTextBox.Text = FileName
        ImageBox.ImageLocation = FileName
        ImageBox.Load()
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateForm() Then
            SaveFormData()
            ClsPhotos.AddPhoto(PhotoObj)
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ValidateForm() As Boolean
        Return ValidateInfo(PathTextBox.Text) AndAlso
                    ValidateInfo(BodyTextBox.Text) AndAlso
                   ValidateInfo(DescriptionTextBox.Text) AndAlso
                   ValidateInfo(TitleTextBox.Text)
    End Function

    Private Sub SaveFormData()
        PhotoObj.Title = TitleTextBox.Text
        PhotoObj.Description = DescriptionTextBox.Text
        PhotoObj.Body = BodyTextBox.Text
    End Sub

    Private Function ValidateInfo(text As String) As Boolean
        Return text <> String.Empty
    End Function
End Class