using System.Collections;
using Microsoft.Maui.Controls.Internals;

namespace UnitTests;

public class MockSystemResources : Dictionary<string, object>, IResourceDictionary
{
    public static MockSystemResources Instance { get; } = new();
    
    public event EventHandler<ResourcesChangedEventArgs>? ValuesChanged;
}