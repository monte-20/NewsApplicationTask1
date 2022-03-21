Imports System.IO

Public Class WriteUtil
    Shared fileWriter As StreamWriter

    Public Shared Sub WriteData(DataPath As String, Data As String)
        Try
            Dim File As String = DataPath & Guid.NewGuid.ToString & ".txt"
            fileWriter = New StreamWriter(File)
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
End Class
