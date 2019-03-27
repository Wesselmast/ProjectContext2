using UnityEngine;

public class MusicDestroyer : MonoBehaviour {
    private void Awake() {
        try { MusicPlayer.ResetMusic(); }
        catch { }
    }
}
