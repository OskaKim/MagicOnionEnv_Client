using OskaKim.Definitions.Sample;
using UnityEngine;

namespace OskaKim.Logics.Sample
{
    public class DirectionLogic
    {
        public static DirectionType CalcDirection(Vector3 targetPosition, Vector3 currentPosition)
        {
            Vector3 direction = targetPosition - currentPosition;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    return DirectionType.Right;
                }
                else
                {
                    return DirectionType.Left;
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    return DirectionType.Up;
                }
                else
                {
                    return DirectionType.Down;
                }
            }
        }

        public static Vector3 ConvertToVector(DirectionType directionType)
        {
            switch (directionType)
            {
                case DirectionType.Left:
                    return Vector3.left;
                case DirectionType.Right:
                    return Vector3.right;
                case DirectionType.Up:
                    return Vector3.up;
                case DirectionType.Down:
                    return Vector3.down;
            }
            return Vector3.zero;
        }
    }
}
