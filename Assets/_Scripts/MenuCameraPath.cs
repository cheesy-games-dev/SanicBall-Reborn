using UnityEngine;

namespace Sanicball
{
    public class MenuCameraPath : MonoBehaviour
    {
        public Transform startPoint;
        public Transform endPoint;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(startPoint.position, endPoint.position);
            Gizmos.DrawSphere(startPoint.position, 0.05f);
        }
    }
}
