Public Class ClsPhotos
    Inherits NewsBaseClass

    Sub New()

    End Sub

    Private PhotoProp As String
    Public Property Photo() As String
        Get
            Return PhotoProp
        End Get
        Set(value As String)
            PhotoProp = value
        End Set
    End Property

    Public Function BrowsePhoto() As String
        Dim result As DialogResult
        Using fileChooser As New OpenFileDialog
            result = fileChooser.ShowDialog
            Photo = fileChooser.FileName
        End Using
        Return Photo
    End Function

    Public Shared Sub AddPhoto(PhotoObj As ClsPhotos)
        Dim DataPath As String = SharedConstantClass.PhotosPath & PhotoObj.getID.ToString & ".txt"
        Dim photoPath As String = SharedConstantClass.PhotosPath & PhotoObj.getID.ToString
        If WriteUtil.CopyFile(PhotoObj.Photo, photoPath) Then
            PhotoObj.Photo = photoPath
        End If
        Dim Data As String = tofile(PhotoObj)
        WriteUtil.WriteData(DataPath, Data)
    End Sub

    Public Shared Function tofile(PhotoObj As ClsPhotos)
        Dim seperator As String = SharedConstantClass.Seperator
        Dim data As String = PhotoObj.getID.ToString & seperator &
                        PhotoObj.getCreationTime & seperator &
                         PhotoObj.Title & seperator &
                         PhotoObj.Description & seperator &
                         PhotoObj.Body & seperator &
                         PhotoObj.Photo
        Return data
    End Function

    Public Shared Function FromFile(file As String) As ClsPhotos
        Dim data() As String = file.Split(New String() {SharedConstantClass.Seperator}, StringSplitOptions.None)
        Dim obj As New ClsPhotos
        obj.setID(data(0))
        obj.setCreationTime(data(1))
        obj.Title = data(2)
        obj.Description = data(3)
        obj.Body = data(4)
        obj.Photo = data(5)
        Return obj
    End Function
End Class
