using System;
using UnityEngine;

namespace ContextInput {

    public enum Direction {
        Left, Right, Forward, Back
    }

    public class PlayerInput : MonoBehaviour {
        [SerializeField] private KeybindConfig keybinds;

        public static Vector3 MousePosition { get { return Input.mousePosition; } }
        public static event Action<Direction> Rotate = delegate { };
        public static event Action<Direction> Move = delegate { };
        public static event Action Quit = delegate { };
        public static event Action Remove = delegate { };
        public static bool Place { get; private set; }

        private void Update() {
            if (Input.GetKeyDown(keybinds.RotateLeft)) Rotate(Direction.Left);
            else if (Input.GetKeyDown(keybinds.RotateRight)) Rotate(Direction.Right);
            else if (Input.GetKeyDown(keybinds.MoveLeft)) Move(Direction.Left);
            else if (Input.GetKeyDown(keybinds.MoveRight)) Move(Direction.Right);
            else if (Input.GetKeyDown(keybinds.MoveForward)) Move(Direction.Forward);
            else if (Input.GetKeyDown(keybinds.MoveBack)) Move(Direction.Back);
            else if (Input.GetKeyDown(keybinds.QuitGame)) Quit();
            else if (Input.GetKeyDown(keybinds.RemoveObject)) Remove();
            else Place = Input.GetKeyDown(keybinds.PlaceObject);
        }
    }
}