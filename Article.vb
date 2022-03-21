
Public Class Article
    Enum Category
        General
        Sports
        Health
        Politics
    End Enum

    Private filePath As String
    Private data As String



    Public Sub New(filePath As String, data As String)
        InitializeComponent()
        Me.filePath = filePath
        Me.data = data
        Dim categoryData As List(Of Category) = [Enum].GetValues(GetType(Category)).Cast(Of Category)().ToList()
        CategoryCombo.DataSource = categoryData
        Dim items() As String = data.Split(",")
        TitleTextBox.Text = items(0)
        DescriptionTextBox.Text = items(1)
        CategoryCombo.SelectedItem = items(2)
        BodyTextBox.Text = items(3)
    End Sub

    Public Sub New()
        InitializeComponent()
        Dim categoryData As List(Of Category) = [Enum].GetValues(GetType(Category)).Cast(Of Category)().ToList()
        CategoryCombo.DataSource = categoryData
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Function ValidateInfo(data As String) As Boolean

        Return data <> String.Empty

    End Function

    Private Sub AddArticle()
        Dim DataPath As String = "G:\Visual Studio\Visual Basic\NewsTask1\Data\News\"
        Dim Data As String = TitleTextBox.Text & "," &
                         DescriptionTextBox.Text & "," &
                         CategoryCombo.SelectedItem.ToString & "," &
                         BodyTextBox.Text
        If filePath <> String.Empty Then
            WriteUtil.UpdateData(filePath, Data)
        Else
            WriteUtil.WriteData(DataPath, Data)

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ValidateInfo(BodyTextBox.Text) AndAlso
           ValidateInfo(DescriptionTextBox.Text) AndAlso
           ValidateInfo(TitleTextBox.Text) Then
            AddArticle()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class