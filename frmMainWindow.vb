Public Class frmMainWindow
    Private mainWindow As clsMainWindow
    Private Sub ArticilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticilToolStripMenuItem.Click
        Dim articleDialog As New frmNews()
        articleDialog.ShowDialog()

    End Sub

    Private Sub ImageArticleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageArticleToolStripMenuItem.Click
        Dim imageArticleDialog As New frmPhotos()
        imageArticleDialog.ShowDialog()
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
        Dim items As List(Of ListViewItem) = mainWindow.getItems
        showItems(items)
    End Sub

    Private Sub showItems(items As List(Of ListViewItem))
        For Each item As ListViewItem In items
            ItemList.Items.Add(item)
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
            'ImageBox.ImageLocation = text
            'ImageBox.Load()
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
                Dim imageArticleDialog As New frmPhotos()
                result = imageArticleDialog.ShowDialog()
            Else

            End If
            If result <> DialogResult.Cancel Then

            End If

        End If
    End Sub

    Private Sub ItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemList.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim item As ListViewItem = ItemList.FocusedItem
            MsgBox(item.SubItems(3).Text)
            ImageBox.CancelAsync()
            ItemList.Items.Remove(item)
            mainWindow.deleteItem(item)
            e.Handled = True
        End If
    End Sub
End Class
