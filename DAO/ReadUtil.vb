Imports System.IO

Public Class ReadUtil
    Shared reader As StreamReader

    Shared Function readDirectory(DirectoryPath As String) As ArrayList
        Dim dir As New DirectoryInfo(DirectoryPath)
        Dim files() As FileInfo = dir.GetFiles
        Dim fi As FileInfo
        Dim data As New ArrayList
        For Each fi In files
            Try
                reader = New StreamReader(fi.FullName)
                data.Add({fi.FullName, fi.CreationTime, reader.ReadToEnd})
                reader.Close()
            Catch ex As IOException
                MessageBox.Show("Error Reading", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Next
        Return data
    End Function
End Class
