using OskaKim.Applications.State;
using OskaKim.Applications.State.Runner;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StateRunnerCreator>(Lifetime.Singleton);
            builder.Register<StateStack>(Lifetime.Scoped);
        }
    }
}
