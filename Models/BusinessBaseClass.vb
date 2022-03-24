Public MustInherit Class BusinessBaseClass

    Private FileID As Guid
    Private CreationTime As Date

    Protected Sub setID(id As String)
        Guid.TryParse(id, FileID)
    End Sub

    Public Function getID() As Guid
        Return FileID
    End Function
    Protected Sub setCreationTime(time As Date)
        CreationTime = time
    End Sub

    Public Function getCreationTime() As Date
        Return CreationTime
    End Function

    Sub New()
        FileID = Guid.NewGuid
        CreationTime = Date.Now
    End Sub
End Class
