using OskaKim.GameData.Sample.Sea.Ship;
using UnityEngine;
using VContainer;

namespace OskaKim.Logics.Sample.Sea
{
    public class MyShipLogic
    {
        private readonly ShipStatusDataRepository _shipStatusDataRepository;
        [Inject]
        public MyShipLogic(ShipStatusDataRepository shipStatusDataRepository)
        {
            _shipStatusDataRepository = shipStatusDataRepository;
        }

        public float MoveShip()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _shipStatusDataRepository.CurrentlySpeed += _shipStatusDataRepository.ForwardEnginePower;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _shipStatusDataRepository.CurrentlySpeed -= _shipStatusDataRepository.BackEnginePower;
            }
            else
            {
                _shipStatusDataRepository.CurrentlySpeed = ApplyResistance(_shipStatusDataRepository.CurrentlySpeed, _shipStatusDataRepository.Resistance);
            }

            return _shipStatusDataRepository.CurrentlySpeed * Time.deltaTime;
        }

        private float ApplyResistance(float speed, float resistance)
        {
            if (Mathf.Abs(speed) <= resistance)
            {
                return 0f;
            }

            if (speed > 0)
            {
                return Mathf.Max(0f, speed - resistance);
            }

            return Mathf.Min(0f, speed + resistance);
        }
    }
}
