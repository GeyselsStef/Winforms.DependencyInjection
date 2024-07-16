Imports DDDSoft.Windows.Winforms.Extensions
Imports DDDSoft.Windows.Winforms.Navigation

Public Class Form1

    Private ReadOnly _formNavigator As IFormNavigator

    Public Sub New(formNavigator As IFormNavigator)
        _formNavigator = formNavigator

        InitializeComponent()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        _formNavigator.ShowDialog(Of TestForm)()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim result As DialogResult = _formNavigator.ShowDialog(Of DialogForm)()

    End Sub

End Class
