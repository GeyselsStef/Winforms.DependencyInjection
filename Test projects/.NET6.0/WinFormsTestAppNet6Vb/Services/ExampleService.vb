Namespace WinformsTestAppNet6Vb.Services

    Public Interface IExampleService

        Sub DoSomething()

    End Interface

    Public Class ExampleService
        Implements IExampleService

        Public Sub DoSomething() Implements IExampleService.DoSomething

            ' Do something
            MessageBox.Show("Do something")

        End Sub
    End Class

End Namespace
