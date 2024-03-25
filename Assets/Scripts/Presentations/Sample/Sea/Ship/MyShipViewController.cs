using System;
using OskaKim.Logics.Sample.Sea;
using VContainer;

namespace OskaKim.Presentations.Sample.Sea.Ship
{
    public class MyShipViewController : IDisposable
    {
        private readonly ShipResourceProvider _resourceProvider;
        private readonly MyShipLogic _myShipLogic;
        private MyShipView _view;

        [Inject]
        public MyShipViewController(ShipResourceProvider resourceProvider, MyShipLogic myShipLogic)
        {
            _resourceProvider = resourceProvider;
            _myShipLogic = myShipLogic;
        }

        public void Initialize()
        {
            _view = _resourceProvider.CreateMyShip();
        }

        public void Dispose()
        {
            _resourceProvider.DestroyMyShip(_view);
        }

        public void Update()
        {
            var rotateAmount = _myShipLogic.CalcDeltaRotateAmount();
            float moveDelta = _myShipLogic.CalcDeltaDistance();

            _view.Rotate(rotateAmount);
            _view.MoveForward(moveDelta);
        }
    }
}
