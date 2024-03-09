using OskaKim.Applications.GameScene;
using OskaKim.Applications.Sample;
using OskaKim.Applications.State.Runner;
using OskaKim.Presentations.Sample;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications
{
    public class SampleGameScene : MonoBehaviour, IGameScene
    {
        [SerializeField] private Canvas mainCanvas;

        private readonly CompositeDisposable _compositeDisposable = new();
        private StateRunner _stateRunner = null;

        public void Initialize(LifetimeScope parentLifetimeScope)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            var stateRunnerCreator = lifetimeScope.Container.Resolve<StateRunnerCreator>();
            var startState = lifetimeScope.Container.Resolve<RootGroupState>();
            _stateRunner = stateRunnerCreator.Create(startState);
            _compositeDisposable.Add(_stateRunner);

            var canvasViewHolder = lifetimeScope.Container.Resolve<Presentations.CanvasViewHolder>();
            canvasViewHolder.SetMainCanvas(mainCanvas);
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<RootGroupState>(Lifetime.Transient);
            builder.Register<Presentations.CanvasViewHolder>(Lifetime.Singleton);
            builder.RegisterInstance(mainCanvas);
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
