using Microsoft.Maui.Handlers;

namespace UnitTests;

public class MockApplicationHandler() : ElementHandler<IApplication, object>(Mapper)
{
    private static readonly IPropertyMapper<IApplication, MockApplicationHandler> Mapper = new PropertyMapper<IApplication, MockApplicationHandler>(ElementMapper);

    protected override object CreatePlatformElement() => new();
} 