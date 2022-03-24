Public Class SharedConstantClass

    Public Shared Function Seperator() As String

        Return "%%$$##"
    End Function

    Public Shared Function UserPath() As String
        'Application.StartupPath & "\Data\Users\"
        Return "G:\Visual Studio\Visual Basic\NewsTask1\Data\Users\"
    End Function

    Public Shared Function NewsPath() As String
        'Application.StartupPath & "\Data\News\"
        Return "G:\Visual Studio\Visual Basic\NewsTask1\Data\News\"
    End Function

    Public Shared Function PhotosPath() As String
        'Application.StartupPath & "\Data\Photos\"
        Return "G:\Visual Studio\Visual Basic\NewsTask1\Data\Photos\"
    End Function



End Class
