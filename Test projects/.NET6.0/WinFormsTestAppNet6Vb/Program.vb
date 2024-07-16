﻿Imports System.Threading
Imports DDDSoft.Windows.Winforms.Abstraction
Imports DDDSoft.Windows.Winforms.Extensions
Imports DDDSoft.Windows.Winforms.Hosting
Imports DDDSoft.Windows.Winforms.Navigation
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports WinFormsTestAppNet6Vb.WinformsTestAppNet6Vb.Services

Public Module Program

    <STAThread>
    Public Sub Main(args As String())

        ' To customize application configuration such as set high DPI settings Or default font,
        ' see https://aka.ms/applicationconfiguration.
        ' ApplicationConfiguration.Initialize()
        ' -> this does not work in Vb.Net, so we have to do it manually

        Dim hostBuilder As New WinformsHostApplicationBuilder(args)

        hostBuilder.ApplicationConfiguration.SetEnableVisualStyles()
        hostBuilder.ApplicationConfiguration.SetCompatibleTextRenderingDefault(False)
        hostBuilder.ApplicationConfiguration.AddThreadExceptions(AddressOf HandleThreadException)
        hostBuilder.ApplicationConfiguration.AddUnhandledException(AddressOf HandleUnhandledException)

        hostBuilder.Configuration.AddJsonFile("appsettings.json", optional:=True, reloadOnChange:=True)
        hostBuilder.Configuration.AddEnvironmentVariables()

        hostBuilder.FormNavigator.AddMainForm(Of Form1)()
        hostBuilder.FormNavigator.Configure(Sub(config)
                                                config.DefaultFormConfiguration.WindowState = FormWindowState.Maximized
                                                config.AddForms({GetType(Form1).Assembly}, Nothing)
                                                config.AddForm(Of DialogForm)(New FormConfiguration() With {.IsDialog = True, .WindowState = FormWindowState.Normal})
                                            End Sub)

        hostBuilder.Services.AddTransient(Of IExampleService, ExampleService)()

        Dim host As IWinformsHost = hostBuilder.Build()

        ' For hosted services
        host.StartAsync().Wait()

        host.Run(Of Form1)()

        host.Services.GetRequiredService(Of IHostApplicationLifetime)().StopApplication()
        host.WaitForShutdownAsync().Wait()

    End Sub

    Private Sub HandleThreadException(sender As Object, e As ThreadExceptionEventArgs)

    End Sub

    Private Sub HandleUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)

    End Sub

End Module
