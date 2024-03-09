using System;
using VContainer;

namespace OskaKim.Presentations.Sample.Sea.Ship
{
    public class MyShipViewController : IDisposable
    {
        private readonly ShipResourceProvider _resourceProvider;
        private MyShipView _view;

        [Inject]
        public MyShipViewController(ShipResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
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
        }
    }
}
