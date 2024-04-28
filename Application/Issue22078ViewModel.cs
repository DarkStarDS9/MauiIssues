using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiIssues;

public class Issue22078ViewModel() : INotifyPropertyChanged
{
    private bool _shouldCauseBindingError;
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private object _iAmNull = null!;
    private object _iAmNotNull = new object();
    
    public bool ShouldCauseBindingError
    {
        get => _shouldCauseBindingError;
        set
        {
            SetField(ref _shouldCauseBindingError, value);
            OnPropertyChanged(nameof(ObjectType));
        }
    }

    public string ObjectType => (ShouldCauseBindingError ? _iAmNull : _iAmNotNull).GetType().Name;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}