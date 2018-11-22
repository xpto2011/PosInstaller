Public Class Form1

    Private FileToRead As String = "" 'This needs to be set manually for the ReadEXEFromFile method, otherwise is irrelevant
    Private DirectoryToRead As String = "" 'This needs to be set manually for the ReadFromDirectory method, otherwise is irrelevant

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

    ''' <summary>
    ''' Reads EXEs from a file with the following format EXEPath:args
    ''' </summary>
    Private Sub ReadEXEFromFile()
        Dim fl As String() = IO.File.ReadAllLines(FileToRead)

        For Each l In fl
            Dim s As String() = l.Split(":")
            CheckedListBox1.Items.Add(New ProgramExe(s(0), s(1)))
        Next
    End Sub

    ''' <summary>
    ''' Reads every EXE in the root directory and adds them
    ''' </summary>
    Private Sub ReadFromDirectory()
        For Each d In My.Computer.FileSystem.GetFiles(DirectoryToRead, FileIO.SearchOption.SearchTopLevelOnly, "*.exe")
            CheckedListBox1.Items.Add(New ProgramExe(d, ""))
        Next
    End Sub
End Class
