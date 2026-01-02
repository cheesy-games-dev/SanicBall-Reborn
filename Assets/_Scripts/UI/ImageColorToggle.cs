using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Sanicball.UI
{
    [RequireComponent(typeof(Image))]
    public class ImageColorToggle : EntityBehaviour
    {
        private Image image;

        [SerializeField]
        private Color targetColor;
        [SerializeField]
        private float fadeTime;

        private Color baseColor;
        private float fade;

        public bool On { get; set; }

        private void Start()
        {
            image = GetComponent<Image>();
            baseColor = image.color;
        }

        public override void OnUpdate()
        {
            if (On)
            {
                if (fade < 1)
                {
                    fade += Time.deltaTime / fadeTime;
                    image.color = Color.Lerp(baseColor, targetColor, fade);
                }
            }
            else
            {
                if (fade > 0)
                {
                    fade -= Time.deltaTime / fadeTime;
                    image.color = Color.Lerp(baseColor, targetColor, fade);
                }
            }
        }
    }
}