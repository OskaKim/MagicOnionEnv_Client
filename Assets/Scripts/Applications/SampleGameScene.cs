using OskaKim.Applications.GameScene;
using OskaKim.Applications.Sample;
using OskaKim.Applications.State.Runner;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications
{
    public class SampleGameScene : MonoBehaviour, IGameScene
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private StateRunner _stateRunner = null;

        public void Initialize(LifetimeScope parentLifetimeScope)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            var stateRunnerCreator = lifetimeScope.Container.Resolve<StateRunnerCreator>();
            var startState = lifetimeScope.Container.Resolve<StartState>();
            _stateRunner = stateRunnerCreator.Create(startState);
            _compositeDisposable.Add(_stateRunner);
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<StartState>(Lifetime.Transient);
            builder.Register<MainState>(Lifetime.Transient);
        }

        private void Update()
        {
            _stateRunner?.Update();
        }

        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
        }
    }
}
