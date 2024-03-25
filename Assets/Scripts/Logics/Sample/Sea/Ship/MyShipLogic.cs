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

        // 이동거리 계산
        public float CalcDeltaDistance()
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

            _shipStatusDataRepository.CurrentlySpeed = Mathf.Clamp(_shipStatusDataRepository.CurrentlySpeed, -_shipStatusDataRepository.MaxSpeed, _shipStatusDataRepository.MaxSpeed);
            return _shipStatusDataRepository.CurrentlySpeed * Time.deltaTime;
        }

        public float CalcDeltaRotateAmount()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                _shipStatusDataRepository.CurrentlyRotateSpeed += horizontalInput * _shipStatusDataRepository.RotateEnginePower;
            }
            else
            {
                _shipStatusDataRepository.CurrentlyRotateSpeed = 0;
            }

            _shipStatusDataRepository.CurrentlyRotateSpeed = Mathf.Clamp(_shipStatusDataRepository.CurrentlyRotateSpeed, -_shipStatusDataRepository.MaxRotateSpeed, _shipStatusDataRepository.MaxRotateSpeed);
            return _shipStatusDataRepository.CurrentlyRotateSpeed * Time.deltaTime;
        }

        // 저항치를 적용
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
