Public Class MainWindow
    Dim newsData As New ArrayList
    Dim photosData As New ArrayList
    Private Sub ArticilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticilToolStripMenuItem.Click
        Dim articleDialog As New Article()
        articleDialog.ShowDialog()

    End Sub

    Private Sub ImageArticleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageArticleToolStripMenuItem.Click
        Dim imageArticleDialog As New ImageArticle()
        imageArticleDialog.ShowDialog()
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim userDialog As New UserForm()
        Dim result As DialogResult
        result = userDialog.ShowDialog()
    End Sub

    Private Sub SwitchLayout()
        If CategoryPanel.Visible Then
            TabControl.TabPages.Add(ImageTab)
            CategoryPanel.Visible = False
        Else
            TabControl.TabPages.Remove(ImageTab)
            CategoryPanel.Visible = True
        End If

    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl.TabPages.Remove(ImageTab)
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        ItemList.Items.Clear()
        getFilesData()
        MsgBox("Data recieved")
        addNewsToListView()
        addImagesToListView()

    End Sub

    Private Sub getFilesData()
        newsData = ReadUtil.readDirectory("G:\Visual Studio\Visual Basic\NewsTask1\Data\News\")
        photosData = ReadUtil.readDirectory("G:\Visual Studio\Visual Basic\NewsTask1\Data\Photos\")
    End Sub

    Private Sub addNewsToListView()
        For Each item In newsData
            Dim record As New ListViewItem(CStr(item(2).Split(",")(0)))
            record.SubItems.Add(item(1).ToString)
            record.SubItems.Add(item(2).Split(",")(1))
            record.SubItems.Add(item(0).ToString)
            record.SubItems.Add(item(2).Split(",")(2))
            record.SubItems.Add(item(2).Split(",")(3))

            ItemList.Items.Add(record)
        Next

    End Sub

    Private Sub addImagesToListView()
        For Each item In photosData
            Dim record As New ListViewItem(CStr(item(2).Split(",")(0)))
            record.SubItems.Add(item(1).ToString)
            record.SubItems.Add(item(2).Split(",")(1))
            record.SubItems.Add(item(0).ToString)
            record.SubItems.Add(item(2).Split(",")(2))
            record.SubItems.Add(item(2).Split(",")(3))
            ItemList.Items.Add(record)
        Next

    End Sub

    Private Sub ItemList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemList.SelectedIndexChanged
        Dim item As ListViewItem = ItemList.FocusedItem
        TitleTextBox.Text = item.Text
        CreationDateTextBox.Text = item.SubItems(1).Text
        BodyTextBox.Text = item.SubItems(5).Text
        CheckLayout(item.SubItems(4).Text)


    End Sub

    Private Sub CheckLayout(text As String)
        If IO.File.Exists(text) Then
            SwitchLayout()
            ImageBox.Image = New Bitmap(text)
        Else
            CategoryTextBox.Text = text
        End If
    End Sub

    Private Sub ItemList_DoubleClick(sender As Object, e As MouseEventArgs) Handles ItemList.MouseDoubleClick, ItemList.MouseUp
        If e.Button = MouseButtons.Right Or
            e.Clicks = 2 Then
            Dim item As ListViewItem = ItemList.FocusedItem
            Dim filename As String = item.SubItems(3).Text
            Dim data = item.SubItems(0).Text & "," & item.SubItems(2).Text & "," & item.SubItems(4).Text & "," & item.SubItems(5).Text
            Dim result As DialogResult
            MsgBox(data)
            If IO.File.Exists(item.SubItems(4).Text) Then
                Dim imageArticleDialog As New ImageArticle(filename, data)
                result = imageArticleDialog.ShowDialog()
            Else
                Dim articleDialog As New Article(filename, data)

                result = articleDialog.ShowDialog()
            End If
            If result <> DialogResult.Cancel Then
                ItemList.Items.Clear()
                getFilesData()
                addNewsToListView()
                addImagesToListView()
            End If

        End If
    End Sub

    Private Sub ItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemList.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim item As ListViewItem = ItemList.FocusedItem
            MsgBox(item.SubItems(3).Text)
            ItemList.Items.Remove(item)
            IO.File.Delete(item.SubItems(3).Text)
            e.Handled = True
        End If
    End Sub
End Class
