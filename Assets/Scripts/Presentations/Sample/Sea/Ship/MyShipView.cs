using UnityEngine;

namespace OskaKim.Presentations.Sample.Sea.Ship
{
    public class MyShipView : MonoBehaviour
    {
        public void Translate(Vector3 translation)
        {
            transform.Translate(translation);
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
