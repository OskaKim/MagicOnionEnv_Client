using VContainer;

namespace OskaKim.Presentations.Sample.Sea.Ship
{
    public class ShipResourceProvider
    {
        private readonly SeaPreloader _seaPreloader;

        [Inject]
        public ShipResourceProvider(SeaPreloader seaPreloader)
        {
            _seaPreloader = seaPreloader;
        }

        public MyShipView CreateMyShip()
        {
            var myShip = UnityEngine.Object.Instantiate(_seaPreloader.MyShipPrefab);
            myShip.TryGetComponent<MyShipView>(out var myShipView);
            return myShipView;
        }

        public void DestroyMyShip(MyShipView view)
        {
            UnityEngine.Object.Destroy(view.gameObject);
        }
    }
}
