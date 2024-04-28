using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Xaml.Diagnostics;

namespace MauiIssues;

public class BindingDiagnosticsLogger : ILogger<BindingDiagnostics>
{
    public static readonly BindingDiagnosticsLogger Instance = new();
    public ObservableCollection<string> Messages { get; } = new();
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        => Messages.Add(formatter(state, exception));

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
}