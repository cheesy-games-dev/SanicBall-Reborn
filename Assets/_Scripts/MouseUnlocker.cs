using UnityEngine;

namespace Sanicball
{
    public class MouseUnlocker : EntityBehaviour
    {
        private void Start()
        {
            if (FindObjectsOfType<MouseUnlocker>().Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
