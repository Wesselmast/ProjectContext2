using System;
using UnityEngine;

namespace ContextInput {

    public enum Direction {
        Left, Right
    }

    public class PlayerInput : MonoBehaviour {

        public static event Action OnLeftClick = delegate { };
        public static event Action OnRightClick = delegate { };
        public static float Horizontal { get; private set; }
        public static float Vertical { get; private set; }
        public static event Action<Direction> Rotate = delegate { };
        public static Vector3 MousePosition { get; private set; }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) OnLeftClick();
            if (Input.GetKeyDown(KeyCode.Mouse1)) OnRightClick();
            if (Input.GetKeyDown(KeyCode.Q)) Rotate(Direction.Left);
            if (Input.GetKeyDown(KeyCode.E)) Rotate(Direction.Right);
            Horizontal = Input.GetAxis("Horizontal");
            Vertical =  Input.GetAxis("Vertical");
            MousePosition = Input.mousePosition;
        }
    }
}
