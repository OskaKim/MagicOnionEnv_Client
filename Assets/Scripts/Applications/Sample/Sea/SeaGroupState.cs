using OskaKim.Applications.State;
using OskaKim.Applications.State.Runner;
using OskaKim.GameData.Sample.Sea.Ship;
using OskaKim.Logics.Sample.Sea;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample.Sea
{
    public class SeaGroupState : GroupStateBase
    {
        private StateRunner _myShipStateRunner = null;

        [Inject]
        public SeaGroupState(LifetimeScope parentLifetimeScope)
            : base(parentLifetimeScope.Container)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            var resolver = lifetimeScope.Container;
            var stateRunnerCreator = resolver.Resolve<StateRunnerCreator>();
            var myShipActionState = resolver.Resolve<Ship.MyShipActionState>();
            _myShipStateRunner = stateRunnerCreator.Create(myShipActionState);
            _compositeDisposable.Add(_myShipStateRunner);
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update()
        {
            base.Update();
            _myShipStateRunner.Update();
        }

        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<Ship.MyShipActionState>(Lifetime.Transient);
            builder.Register<MyShipLogic>(Lifetime.Singleton);
            builder.Register<ShipStatusDataRepository>(Lifetime.Singleton);
        }
    }
}
