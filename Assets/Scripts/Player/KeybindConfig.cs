using UnityEngine;

[CreateAssetMenu(fileName = "New Keybinds", menuName = "Custom/Keybinds")]
public class KeybindConfig : ScriptableObject {
    [SerializeField] private KeyCode rotateLeft;
    public KeyCode RotateLeft { get { return rotateLeft; } }
    [SerializeField] private KeyCode rotateRight;
    public KeyCode RotateRight { get { return rotateRight; } }
    [SerializeField] private KeyCode moveForwards;
    public KeyCode MoveForward { get { return moveForwards; } }
    [SerializeField] private KeyCode moveBack;
    public KeyCode MoveBack { get { return moveBack; } }
    [SerializeField] private KeyCode moveLeft;
    public KeyCode MoveLeft { get { return moveLeft; } }
    [SerializeField] private KeyCode moveRight;
    public KeyCode MoveRight { get { return moveRight; } }
    [SerializeField] private KeyCode quitGame;
    public KeyCode QuitGame { get { return quitGame; } }
    [SerializeField] private KeyCode removeObject;
    public KeyCode RemoveObject { get { return removeObject; } }
    [SerializeField] private KeyCode placeObject;
    public KeyCode PlaceObject { get { return placeObject; } }
    [SerializeField] private KeyCode debugSkipLevel;
    public KeyCode DebugSkipLevel { get { return debugSkipLevel; } }
    [SerializeField] private KeyCode debugLastLevel;
    public KeyCode DebugLastLevel { get { return debugLastLevel; } }
}
