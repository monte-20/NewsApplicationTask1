Public Class ClsUser
    Inherits BusinessBaseClass

    Private NameProp As String
    Public Property Name() As String
        Get
            Return NameProp
        End Get
        Set(ByVal value As String)
            NameProp = value
        End Set
    End Property

    Private UsernameProp As String
    Public Property Username() As String
        Get
            Return UsernameProp
        End Get
        Set(ByVal value As String)
            UsernameProp = value
        End Set
    End Property

    Private PasswordProp As String
    Public Property Password() As String
        Get
            Return PasswordProp
        End Get
        Set(ByVal value As String)
            PasswordProp = value
        End Set
    End Property

    Public Shared Sub AddUser(user As ClsUser)
        Dim DataPath As String = SharedConstantClass.UserPath & user.getID.ToString & ".txt"
        Dim Data = tofile(user)
        WriteUtil.WriteData(DataPath, Data)

    End Sub

    Public Shared Function tofile(user As ClsUser)
        Dim seperator As String = SharedConstantClass.Seperator
        Dim data As String = user.getID.ToString & seperator &
                    user.getCreationTime & seperator &
                    user.Name & seperator &
                    user.Username & seperator &
                    user.Password
        Return data
    End Function

    Public Shared Function FromFile(file As String) As ClsUser
        Dim data() As String = file.Split(New String() {SharedConstantClass.Seperator}, StringSplitOptions.None)
        Dim obj As New ClsUser
        obj.setID(data(0))
        obj.setCreationTime(data(1))
        obj.Name = data(2)
        obj.Username = data(3)
        obj.Password = data(4)
        Return obj
    End Function
End Class
