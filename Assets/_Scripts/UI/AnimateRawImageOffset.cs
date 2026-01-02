using UnityEngine;
using UnityEngine.UI;

namespace Sanicball.UI
{
    [RequireComponent(typeof(RawImage))]
    public class AnimateRawImageOffset : EntityBehaviour
    {
        public Vector2 speed;
        private Vector2 offset;

        private RawImage img;

        private void Start()
        {
            img = GetComponent<RawImage>();
        }

        public override void OnUpdate()
        {
            offset += new Vector2(speed.x * Time.deltaTime, speed.y * Time.deltaTime);
            if (offset.x >= 1)
            {
                offset += new Vector2(-1, 0);
            }
            if (offset.y >= 1)
            {
                offset += new Vector2(0, -1);
            }
            img.uvRect = new Rect(offset.x, offset.y, img.uvRect.width, img.uvRect.height);
        }
    }
}