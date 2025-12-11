using UnityEngine;
using UnityEngine.UI;

namespace Sanicball.UI
{
    public class PopupDisconnected : MonoBehaviour
    {
        public static PopupDisconnected Instance;
        [SerializeField]
        private Text reasonField = null;

        public string Reason { set { reasonField.text = value; } }

        private void Start() {
            Instance = this;
        }
    }
}