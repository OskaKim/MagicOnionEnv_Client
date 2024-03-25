using UnityEngine;

namespace OskaKim.Presentations.Sample.Sea.Ship
{
    public class MyShipView : MonoBehaviour
    {
        public void Rotate(float rotationAmount)
        {
            transform.Rotate(Vector3.forward, -rotationAmount);
        }

        public void MoveForward(float deltaSpeed)
        {
            transform.Translate(Vector3.up * deltaSpeed);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
