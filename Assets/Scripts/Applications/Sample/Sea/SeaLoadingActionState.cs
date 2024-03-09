using Cysharp.Threading.Tasks;
using OskaKim.Applications.State;
using OskaKim.Presentations.Sample.Sea;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample.Sea
{
    public class SeaLoadingActionState : StateBase
    {
        private readonly SeaPreloader _seaPreloader;

        [Inject]
        public SeaLoadingActionState(LifetimeScope parentLifetimeScope, SeaPreloader seaPreloader) : base(parentLifetimeScope.Container)
        {
            _seaPreloader = seaPreloader;
        }

        public override void Initialize()
        {
            base.Initialize();
            LoadAsync().Forget();
        }

        private async UniTask LoadAsync()
        {
            await _seaPreloader.LoadPrefabs();
            SetNextStateWithoutReturnInfo<SeaGroupState>();
        }
    }
}
