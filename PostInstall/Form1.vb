Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Application Loading

        'Manually add the executables to the program (code below), read them from a file or search in a directory
        Dim p1 As New ProgramExe("teste1", "-s", "Programa Teste1")
        Dim p2 As New ProgramExe("teste2", "-s", "Programa Teste2")
        CheckedListBox1.Items.Add(p1)
        CheckedListBox1.Items.Add(p2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Run executables
        For Each i In CheckedListBox1.CheckedItems
            Dim item As ProgramExe = CType(i, ProgramExe)
            'MsgBox(item.exe & vbNewLine & item.args)
            'run prog
            'Dim psi As New ProcessStartInfo(item.exe, item.args)
            Dim psi As ProcessStartInfo = item.toProcessStartInfo()
            Dim p As New Process() With {
                .StartInfo = psi
            }
            p.Start()
            p.WaitForExit()
        Next
    End Sub

    ''' <summary>
    ''' Handles 'Selecionar tudo' button click
    ''' Marks as checked every item in the checkedlistbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Check everything
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, True)
        Next
    End Sub
End Class
