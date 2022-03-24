Public Class clsMainWindow
    Dim newsData As New List(Of String)
    Dim photosData As New List(Of String)
    Dim newslist As New List(Of ClsNews)
    Dim photoslist As New List(Of ClsPhotos)
    Dim listViewItems As New List(Of ListViewItem)



    Public Sub getFilesData()
        newsData = ReadUtil.ReadDirectory("G:\Visual Studio\Visual Basic\NewsTask1\Data\News\")
        photosData = ReadUtil.ReadDirectory("G:\Visual Studio\Visual Basic\NewsTask1\Data\Photos\")
    End Sub


    Private Sub addNewsToList()
        For Each item In newsData
            Dim obj As ClsNews = ClsNews.FromFile(item)
            Dim record As New ListViewItem(obj.Title)
            record.SubItems.Add(obj.getCreationTime)
            record.SubItems.Add(obj.Description)
            record.SubItems.Add(obj.getID.ToString)
            record.SubItems.Add(obj.Category)
            record.SubItems.Add(obj.Body)
            newslist.Add(obj)
            listViewItems.Add(record)
        Next
    End Sub

    Private Sub addPhotosToList()
        For Each item In photosData
            Dim obj As ClsPhotos = ClsPhotos.FromFile(item)
            Dim record As New ListViewItem(obj.Title)
            record.SubItems.Add(obj.getCreationTime)
            record.SubItems.Add(obj.Description)
            record.SubItems.Add(obj.getID.ToString)
            record.SubItems.Add(obj.Photo)
            record.SubItems.Add(obj.Body)
            photoslist.Add(obj)
            listViewItems.Add(record)
        Next

    End Sub

    Public Function getItems() As List(Of ListViewItem)
        getFilesData()
        addNewsToList()
        addPhotosToList()
        Return listViewItems
    End Function

    Public Sub deleteItem(item As ListViewItem)
        If listViewItems.Contains(item) Then
            If IO.File.Exists(SharedConstantClass.PhotosPath & item.SubItems(3).Text & ".txt") Then
                IO.File.Delete(item.SubItems(4).Text)
                IO.File.Delete(SharedConstantClass.PhotosPath & item.SubItems(3).Text & ".txt")
            Else
                IO.File.Delete(SharedConstantClass.NewsPath & item.SubItems(3).Text & ".txt")
            End If
        End If
    End Sub
End Class
