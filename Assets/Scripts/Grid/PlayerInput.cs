using System;
using UnityEngine;

namespace ContextInput {

    public enum Direction {
        Left, Right
    }

    public class PlayerInput : MonoBehaviour {
        public static float Horizontal { get; private set; }
        public static float Vertical { get; private set; }
        public static event Action<Direction> Rotate = delegate { };
        public static event Action Reset = delegate { };
        public static Vector3 MousePosition { get; private set; }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.R)) Reset();
            if (Input.GetKeyDown(KeyCode.Q)) Rotate(Direction.Left);
            if (Input.GetKeyDown(KeyCode.E)) Rotate(Direction.Right);
            if (Input.GetKeyDown(KeyCode.A)) Horizontal = -1;
            else if (Input.GetKeyDown(KeyCode.D)) Horizontal = 1;
            else Horizontal = 0;
            if (Input.GetKeyDown(KeyCode.W)) Vertical = 1;
            else if (Input.GetKeyDown(KeyCode.S)) Vertical = -1;
            else Vertical = 0;
            MousePosition = Input.mousePosition;
        }
    }
}