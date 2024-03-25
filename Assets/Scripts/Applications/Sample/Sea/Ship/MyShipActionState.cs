using Cysharp.Threading.Tasks;
using OskaKim.Applications.State;
using OskaKim.Presentations.Sample.Sea.Ship;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample.Sea.Ship
{
    public class MyShipActionState : StateBase
    {
        private readonly MyShipViewController _myShipViewController;
        private readonly ShipHubController _shipHubController;

        [Inject]
        public MyShipActionState(LifetimeScope parentLifetimeScope, ShipHubController shipHubController)
            : base(parentLifetimeScope.Container)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            var resolver = lifetimeScope.Container;
            _myShipViewController = resolver.Resolve<MyShipViewController>();
            _shipHubController = shipHubController;
        }

        public override void Initialize()
        {
            base.Initialize();
            _myShipViewController.Initialize();
        }

        public override void Update()
        {
            base.Update();
            _myShipViewController.Update();

            // 해전화면 종료
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Q))
            {
                _shipHubController.LeaveAsync().Forget();
            }
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<ShipResourceProvider>(Lifetime.Singleton);
            builder.Register<MyShipViewController>(Lifetime.Singleton);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
