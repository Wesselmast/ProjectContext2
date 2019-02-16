using System;
using UnityEngine;

namespace ContextInput {

    public enum Direction {
        Left, Right, Forward, Back
    }

    public class PlayerInput : MonoBehaviour {
        public static event Action<Direction> Rotate = delegate { };
        public static event Action<Direction> Move = delegate { };
        //public static event Action Reset = delegate { };
        public static event Action Remove = delegate { };
        public static bool Place { get; private set; }
        public static Vector3 MousePosition { get { return Input.mousePosition; } }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) Rotate(Direction.Left);
            else if (Input.GetKeyDown(KeyCode.E)) Rotate(Direction.Right);
            else if (Input.GetKeyDown(KeyCode.A)) Move(Direction.Left);
            else if (Input.GetKeyDown(KeyCode.D)) Move(Direction.Right);
            else if (Input.GetKeyDown(KeyCode.W)) Move(Direction.Forward);
            else if (Input.GetKeyDown(KeyCode.S)) Move(Direction.Back);
            else if (Input.GetKeyDown(KeyCode.R)) Remove();
            //else if (Input.GetKeyDown(KeyCode.Delete)) Reset();
            else Place = Input.GetKeyDown(KeyCode.Space);
        }   
    }
}