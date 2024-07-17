Imports WinformsTestAppNet48Vb.WinformsTestAppNet48Vb.Services

Public Class TestForm

    Private ReadOnly _exampleService As IExampleService

    Public Sub New(exampleService As IExampleService)
        Me._exampleService = exampleService

        InitializeComponent()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        _exampleService.DoSomething()

    End Sub

End Class