Public Class ProgramExe

    Public ReadOnly Property Exe As String
    Public ReadOnly Property Args As String
    Public ReadOnly Property DisplayName As String

    ''' <summary>
    ''' Creates a new program executable object containing a exe path, possible arguments to be used at launch and a display name.
    ''' </summary>
    ''' <param name="exe">EXE Path</param>
    ''' <param name="args">EXE Arguments</param>
    ''' <param name="DisplayName">Name to shown in the CheckedListBox. Defaults to the exe name if none is provided.</param>
    Public Sub New(ByVal exe As String, ByVal args As String, Optional ByVal DisplayName As String = "")
        Me.Exe = exe
        Me.Args = args
        Me.DisplayName = IIf(DisplayName = "", IO.Path.GetFileName(exe), DisplayName)
    End Sub

    ''' <summary>
    ''' Returns a new ProcessStartInto object for the EXE
    ''' </summary>
    ''' <returns>new ProcessStartInfo with exe and args</returns>
    Public Function ToProcessStartInfo() As ProcessStartInfo
        Return New ProcessStartInfo(Exe, Args)
    End Function

    Public Overrides Function ToString() As String
        Return DisplayName
    End Function
End Class
