using UnityEngine;

namespace Sanicball
{
    public class Rotate : EntityBehaviour
    {
        public Vector3 angle;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        public override void OnUpdate()
        {
            transform.Rotate(angle * Time.deltaTime * 10);
        }
    }
}