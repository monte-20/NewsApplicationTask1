Public Class ClsNews
    Inherits NewsBaseClass

    Private CategoryProp As String
    Public Property Category() As String
        Get
            Return CategoryProp
        End Get
        Set(value As String)
            CategoryProp = value
        End Set
    End Property

    Public Shared Sub AddNews(news As ClsNews)
        Dim DataPath As String = SharedConstantClass.NewsPath & news.getID.ToString & ".txt"
        Dim Data As String = tofile(news)
        WriteUtil.WriteData(DataPath, Data)
    End Sub

    Public Shared Function tofile(News As ClsNews)
        Dim seperator As String = SharedConstantClass.Seperator
        Dim data As String = News.getID.ToString & seperator &
                        News.getCreationTime & seperator &
                         News.Title & seperator &
                         News.Description & seperator &
                         News.Body & seperator &
                         News.Category
        Return data
    End Function

    Public Shared Function FromFile(file As String) As ClsNews
        Dim data() As String = file.Split(New String() {SharedConstantClass.Seperator}, StringSplitOptions.None)
        Dim obj As New ClsNews
        obj.setID(data(0))
        obj.setCreationTime(data(1))
        obj.Title = data(2)
        obj.Description = data(3)
        obj.Body = data(4)
        obj.Category = data(5)
        Return obj
    End Function
End Class
