Imports System.IO

Public Class WriteUtil
    Shared fileWriter As StreamWriter

    Public Shared Sub WriteData(DataPath As String, Data As String)
        Try
            fileWriter = New StreamWriter(DataPath)
            fileWriter.Write(Data)
        Catch ex As IOException
            MessageBox.Show("Error Writing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            fileWriter.Close()
        End Try

    End Sub
    Public Shared Sub UpdateData(DataPath As String, Data As String)
        Try
            Dim File As String = DataPath
            fileWriter = New StreamWriter(File)
            fileWriter.Write(Data)
        Catch ex As IOException
            MessageBox.Show("Error Writing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            fileWriter.Close()
        End Try

    End Sub
    Public Shared Function CopyFile(fromPath As String, ByRef toPath As String) As Boolean
        Try
            toPath = toPath & fromPath.Substring(fromPath.LastIndexOf("."))
            FileCopy(fromPath, toPath)
            Return True
        Catch ex As IOException
            MessageBox.Show("Error Copying", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function
End Class
