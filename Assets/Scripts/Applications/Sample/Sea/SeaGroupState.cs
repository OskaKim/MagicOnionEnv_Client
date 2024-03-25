using Cysharp.Threading.Tasks;
using OskaKim.Applications.Sample.Sea.Ship;
using OskaKim.Applications.State;
using OskaKim.Applications.State.Runner;
using OskaKim.GameData.Sample.Sea.Ship;
using OskaKim.Logics.Sample.Sea;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample.Sea
{
    public class SeaGroupState : GroupStateBase
    {
        private readonly StateRunnerCreator _stateRunnerCreator;
        private readonly ShipHubController _shipHubController;
        private readonly ShipHubReceiver _shipHubReceiver;
        private readonly IObjectResolver _resolver;
        private StateRunner _myShipStateRunner = null;

        [Inject]
        public SeaGroupState(LifetimeScope parentLifetimeScope)
            : base(parentLifetimeScope.Container)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            _resolver = lifetimeScope.Container;
            _stateRunnerCreator = _resolver.Resolve<StateRunnerCreator>();
            _shipHubController = _resolver.Resolve<ShipHubController>();
            _shipHubReceiver = _resolver.Resolve<ShipHubReceiver>();
        }

        public override void Initialize()
        {
            base.Initialize();
            _shipHubReceiver.OnJoinAsObservable.Subscribe(OnPlayerLogin).AddTo(_compositeDisposable);
            _shipHubReceiver.OnLeaveAsObservable.Subscribe(OnPlayerLeave).AddTo(_compositeDisposable);
            InitializeAsync().Forget();
        }
        private async UniTask InitializeAsync()
        {
            await _shipHubController.JoinAsync("MyShip", _shipHubReceiver);
        }

        private void OnPlayerLogin(string name)
        {
            UnityEngine.Debug.Log($"Player Login : {name}");

            var myShipActionState = _resolver.Resolve<MyShipActionState>();
            _myShipStateRunner = _stateRunnerCreator.Create(myShipActionState);
            _compositeDisposable.Add(_myShipStateRunner);
        }

        private void OnPlayerLeave(string name)
        {
            UnityEngine.Debug.Log($"Player Leave : {name}");
            SetNextStateWithoutReturnInfo<SeaFinishActionState>();
        }

        public override void Update()
        {
            base.Update();

            if (_myShipStateRunner is not null)
            {
                _myShipStateRunner.Update();
            }
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<MyShipActionState>(Lifetime.Transient);
            builder.Register<MyShipLogic>(Lifetime.Singleton);
            builder.Register<ShipStatusDataRepository>(Lifetime.Singleton);
            builder.Register<ShipHubController>(Lifetime.Singleton);
            builder.Register<ShipHubReceiver>(Lifetime.Singleton);
        }
    }
}
