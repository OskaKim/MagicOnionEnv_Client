using OskaKim.Applications.State;
using OskaKim.Presentations.Sample.Sea.Ship;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample.Sea.Ship
{
    public class MyShipActionState : StateBase
    {
        private readonly MyShipViewController _myShipViewController;

        [Inject]
        public MyShipActionState(LifetimeScope parentLifetimeScope)
            : base(parentLifetimeScope.Container)
        {
            var lifetimeScope = parentLifetimeScope.CreateChild(RegisterBuildInfo);
            _compositeDisposable.Add(lifetimeScope);

            var resolver = lifetimeScope.Container;
            _myShipViewController = resolver.Resolve<MyShipViewController>();
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
        }


        private void RegisterBuildInfo(IContainerBuilder builder)
        {
            builder.Register<ShipResourceProvider>(Lifetime.Singleton);
            builder.Register<MyShipViewController>(Lifetime.Singleton);
        }
    }
}
