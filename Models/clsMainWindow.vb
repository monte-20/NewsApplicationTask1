﻿Public Class clsMainWindow
    Private newsData As List(Of ClsNews)
    Private photosData As List(Of ClsPhotos)
    Private newslist As List(Of ListViewItem)
    Private photoslist As List(Of ListViewItem)
    Private listViewItems As List(Of ListViewItem)

    Sub New()
        newsData = New List(Of ClsNews)
        photosData = New List(Of ClsPhotos)
        newslist = New List(Of ListViewItem)
        photoslist = New List(Of ListViewItem)
        listViewItems = New List(Of ListViewItem)
    End Sub

    Public Sub getFilesData()
        newsData = ClsNews.ReadAll()
        photosData = ClsPhotos.ReadAll()
    End Sub


    Private Sub addNewsToList()
        For Each item In newsData
            Dim record As New ListViewItem(item.Title)
            record.SubItems.Add(item.CreationTime)
            record.SubItems.Add(item.Description)
            record.SubItems.Add(item.ID.ToString)
            record.SubItems.Add(item.Category.ToString)
            record.SubItems.Add(item.Body)
            newslist.Add(record)
            listViewItems.Add(record)
        Next
    End Sub

    Private Sub addPhotosToList()
        For Each item In photosData
            Dim record As New ListViewItem(item.Title)
            record.SubItems.Add(item.CreationTime)
            record.SubItems.Add(item.Description)
            record.SubItems.Add(item.ID.ToString)
            record.SubItems.Add(item.Photo)
            record.SubItems.Add(item.Body)
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
        Dim id As Guid
        Guid.TryParse(item.SubItems(3).Text, id)
        If photoslist.Contains(item) Then
            ClsPhotos.Delete(id)
        Else
            ClsNews.Delete(id)
        End If

    End Sub


    Friend Function updateItem(item As ListViewItem) As DialogResult
        Dim result As DialogResult
        If photoslist.Contains(item) Then

            result = New frmPhotos(itemToPhoto(item)).ShowDialog
        Else

            result = New frmNews(itemToNews(item)).ShowDialog
        End If
        RefreshData(result)
        Return result
    End Function

    Private Sub RefreshData(result As DialogResult)
        If result <> DialogResult.Cancel Then
            newsData.Clear()
            photosData.Clear()
            getFilesData()
        End If
    End Sub
    Public Function itemIsPhoto(item As ListViewItem) As Boolean
        Return photoslist.Contains(item)
    End Function

    Private Function itemToNews(item As ListViewItem) As ClsNews
        Dim obj As New ClsNews
        obj.Title = item.SubItems(0).Text
        Date.TryParse(item.SubItems(1).Text, obj.CreationTime)
        obj.Description = item.SubItems(2).Text
        Guid.TryParse(item.SubItems(3).Text, obj.ID)
        Dim cat = DirectCast([Enum].Parse(GetType(frmNews.Category), item.SubItems(4).Text), frmNews.Category)
        obj.Category = cat
        obj.Body = item.SubItems(5).Text
        Return obj
    End Function

    Private Function itemToPhoto(item As ListViewItem) As ClsPhotos
        Dim obj As New ClsPhotos
        obj.Title = item.SubItems(0).Text
        Date.TryParse(item.SubItems(1).Text, obj.CreationTime)
        obj.Description = item.SubItems(2).Text
        Guid.TryParse(item.SubItems(3).Text, obj.ID)
        obj.Photo = item.SubItems(4).Text
        obj.Body = item.SubItems(5).Text
        Return obj
    End Function
End Class
