using OskaKim.Applications.State;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample
{
    public class StartState : StateBase
    {
        [Inject]
        public StartState(LifetimeScope parentLifetimeScope) : base(parentLifetimeScope.Container)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
        }

        public override void Initialize()
        {
            UnityEngine.Debug.Log("Start State Initialize");
            base.Initialize();

            SetNextState<MainState>();
        }
    }
}
