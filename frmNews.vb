
Public Class frmNews
    Public Enum Category
        General
        Sports
        Health
        Politics
    End Enum


    Private news As ClsNews
    Private shared categoryData As List(Of Category) = [Enum].GetValues(GetType(Category)).Cast(Of Category)().ToList()
    Public Shared ReadOnly Property Categories() As List(Of Category)
        Get
            Return categoryData
        End Get

    End Property
    Sub New()
        InitializeComponent()
        CategoryCombo.DataSource = categoryData
        news = New ClsNews

    End Sub

    Public Sub New(news As ClsNews)
        InitializeComponent()
        Dim categoryData As List(Of Category) = [Enum].GetValues(GetType(Category)).Cast(Of Category)().ToList()
        CategoryCombo.DataSource = categoryData
        Me.news = news
        TitleTextBox.Text = news.Title
        DescriptionTextBox.Text = news.Description
        CategoryCombo.SelectedItem = news.Category
        BodyTextBox.Text = news.Body
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click

        If ValidateForm() Then
            SaveFormData
            ClsNews.AddNews(news)
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub SaveFormData()
        news.Title = TitleTextBox.Text
        news.Description = DescriptionTextBox.Text
        news.Category = CategoryCombo.Text
        news.Body = BodyTextBox.Text

    End Sub

    Private Function ValidateForm() As Boolean
        Return ValidateInfo(BodyTextBox.Text) AndAlso
           ValidateInfo(DescriptionTextBox.Text) AndAlso
           ValidateInfo(TitleTextBox.Text)
    End Function

    Private Function ValidateInfo(data As String) As Boolean

        Return data <> String.Empty

    End Function
End Class