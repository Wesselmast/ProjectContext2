using System;
using UnityEngine;

namespace ContextInput {
    public class PlayerInput : MonoBehaviour {
        public static float Horizontal { get; private set; }
        public static float Vertical { get; private set; }
        public static Vector3 MouseRotation { get; private set; }
        public static event Action OnJump = delegate { };
        public static event Action OnShoot = delegate { };

        private void Update() {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            MouseRotation = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if (Input.GetKeyDown(KeyCode.Space)) OnJump();
            if (Input.GetKeyDown(KeyCode.Mouse0)) OnShoot();
        }
    }
}
