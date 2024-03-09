using OskaKim.Applications.Sample.Sea;
using OskaKim.Applications.State;
using OskaKim.Applications.State.Runner;
using OskaKim.Presentations.Sample.Sea;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample
{
    public class RootGroupState : GroupStateBase
    {
        private StateRunner _stateRunner = null;

        [Inject]
        public RootGroupState(LifetimeScope parentLifetimeScope) : base(parentLifetimeScope.Container)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            var resolver = lifetimeScope.Container;
            var stateRunnerCreator = resolver.Resolve<StateRunnerCreator>();
            var startState = resolver.Resolve<SeaLoadingActionState>();
            _stateRunner = stateRunnerCreator.Create(startState);
            _compositeDisposable.Add(_stateRunner);
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update()
        {
            base.Update();
            _stateRunner.Update();
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<SeaLoadingActionState>(Lifetime.Transient);
            builder.Register<SeaGroupState>(Lifetime.Transient);
            builder.Register<SeaPreloader>(Lifetime.Singleton);
        }
    }
}
