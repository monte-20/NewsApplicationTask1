Public Class frmMainWindow
    Private mainWindow As clsMainWindow
    Private items As List(Of ListViewItem)
    Private photo As Image

    Private Sub ArticilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticilToolStripMenuItem.Click
        Dim articleDialog As New frmNews()
        If articleDialog.ShowDialog() <> DialogResult.Cancel Then
            showItems()
        End If

    End Sub

    Private Sub ImageArticleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageArticleToolStripMenuItem.Click
        Dim imageArticleDialog As New frmPhotos()
        If imageArticleDialog.ShowDialog() <> DialogResult.Cancel Then
            showItems()
        End If
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim userDialog As New frmUser()
        userDialog.ShowDialog()
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
        mainWindow = New clsMainWindow
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        ItemList.Items.Clear()
        showItems()
    End Sub

    Private Sub ShowItems()
        ItemList.Items.Clear()
        items = mainWindow.getItems

        For Each item As ListViewItem In items
            ItemList.Items.Add(item)
        Next
    End Sub

    Private Sub ItemList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemList.SelectedIndexChanged
        Dim item As ListViewItem = ItemList.FocusedItem
        If item.Index > -1 Then
            TitleTextBox.Text = item.Text
            CreationDateTextBox.Text = item.SubItems(1).Text
            BodyTextBox.Text = item.SubItems(5).Text
            CheckLayout(item.SubItems(4).Text)
        End If

    End Sub

    Private Sub CheckLayout(text As String)
        If IO.File.Exists(text) Then
            SwitchLayout()
            Try
                Dim imageFileStream As New IO.FileStream(text, IO.FileMode.Open, IO.FileAccess.Read)
                Dim readInImage As Image = Image.FromStream(imageFileStream)
                ImageBox.Image = readInImage
                imageFileStream.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            CategoryTextBox.Text = text
        End If
    End Sub

    Private Sub ItemList_DoubleClick(sender As Object, e As MouseEventArgs) Handles ItemList.MouseDoubleClick, ItemList.MouseUp
        If e.Button = MouseButtons.Right Or
            e.Clicks = 2 Then
            Dim item As ListViewItem = ItemList.FocusedItem
            If mainWindow.updateItem(item) <> DialogResult.Cancel Then
                ShowItems()
            End If
        End If
    End Sub

    Private Sub ItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemList.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim item As ListViewItem = ItemList.FocusedItem
            ItemList.Items.Remove(item)
            mainWindow.deleteItem(item)
            e.Handled = True
        End If
    End Sub


End Class
