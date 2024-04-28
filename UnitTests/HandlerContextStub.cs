using Microsoft.Maui.Animations;

namespace UnitTests;

class MockContext : IMauiContext
{
    public MockContext(IServiceProvider services)
    {
        Services = services;
        Handlers = Services.GetRequiredService<IMauiHandlersFactory>();
        AnimationManager = services.GetService<IAnimationManager>() ?? throw new NullReferenceException();
    }

    public IServiceProvider Services { get; }

    public IMauiHandlersFactory Handlers { get; }

    public IAnimationManager AnimationManager { get; }
}
