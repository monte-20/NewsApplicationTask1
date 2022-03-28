Public Class clsMainWindow
    Dim newsData As New List(Of String)
    Dim photosData As New List(Of String)
    Dim newslist As New List(Of ListViewItem)
    Dim photoslist As New List(Of ListViewItem)
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
            newslist.Add(record)
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
            photoslist.Add(record)
            listViewItems.Add(record)
        Next

    End Sub

    Public Function getItems() As List(Of ListViewItem)
        listViewItems.Clear()
        getFilesData()
        addNewsToList()
        addPhotosToList()
        Return listViewItems
    End Function

    Public Sub deleteItem(item As ListViewItem)
        If photoslist.Contains(item) Then

            IO.File.Delete(SharedConstantClass.PhotosPath & item.SubItems(3).Text & ".txt")
            IO.File.Delete(item.SubItems(4).Text)

        Else
            IO.File.Delete(SharedConstantClass.NewsPath & item.SubItems(3).Text & ".txt")
        End If

    End Sub

    Friend Function updateItem(item As ListViewItem) As DialogResult
        Dim result As DialogResult
        If photoslist.Contains(item) Then

            result = New frmPhotos(itemToPhoto(item)).ShowDialog
        Else

            result = New frmNews(itemToNews(item)).ShowDialog
        End If
        If result <> DialogResult.Cancel Then
            getFilesData()
        End If
        Return result
    End Function

    Private Function itemToNews(item As ListViewItem) As ClsNews
        Dim obj As New ClsNews
        obj.Title = item.SubItems(0).Text
        obj.setCreationTime(item.SubItems(1).Text)
        obj.Description = item.SubItems(2).Text
        obj.setID(item.SubItems(3).Text)
        obj.Category = item.SubItems(4).Text
        obj.Body = item.SubItems(5).Text
        Return obj
    End Function

    Private Function itemToPhoto(item As ListViewItem) As ClsPhotos
        Dim obj As New ClsPhotos
        obj.Title = item.SubItems(0).Text
        obj.setCreationTime(item.SubItems(1).Text)
        obj.Description = item.SubItems(2).Text
        obj.setID(item.SubItems(3).Text)
        obj.Photo = item.SubItems(4).Text
        obj.Body = item.SubItems(5).Text
        Return obj
    End Function
End Class
