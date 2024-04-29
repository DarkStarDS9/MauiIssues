using MauiIssues;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml.Diagnostics;
using Moq;

namespace UnitTests;

public class Issue22078Tests
{
    [Fact]
    public void SetBindingContext()
    {
        // Setup MAUI App
        var mauiAppBuilder = MauiApp.CreateBuilder();
        mauiAppBuilder.Services.AddSingleton<ILogger<BindingDiagnostics>>(BindingDiagnosticsLogger.Instance);
        var mauiApp = mauiAppBuilder.Build();
        
        DependencyService.RegisterSingleton(Mock.Of<ISystemResourcesProvider>(m => m.GetSystemResources() == MockSystemResources.Instance));
        var test = DependencyService.Get<ISystemResourcesProvider>().GetSystemResources();
        
        var app = new App { Handler = new MockApplicationHandler() };
        app.Handler.SetMauiContext(new MockContext(mauiApp.Services));
        Application.Current = app;
        DispatcherProvider.SetCurrent(new MockDispatcherProvider());
        
        // Arrange
        var vm = new Issue22078ViewModel();
        _ = new Issue22078
        {
            BindingContext = vm
        };

        // Act
        vm.ShouldCauseBindingError = true;

        // Assert
        Assert.True(BindingDiagnosticsLogger.Instance.Messages.Count > 0,
            $"If a binding throws an exception, I kinda expect diagnostic logging :)");
    }
}