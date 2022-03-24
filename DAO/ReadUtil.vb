Imports System.IO

Public Class ReadUtil
    Shared reader As StreamReader

    Shared Function ReadDirectory(DirectoryPath As String) As List(Of String)
        Dim dir As New DirectoryInfo(DirectoryPath)
        Dim files() As FileInfo = dir.GetFiles("*.txt")
        Dim fi As FileInfo
        Dim data As New List(Of String)
        For Each fi In files
            Try
                reader = New StreamReader(fi.FullName)
                data.Add(reader.ReadToEnd())
                reader.Close()
            Catch ex As IOException
                MessageBox.Show("Error Reading", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Next
        Return data
    End Function
End Class
