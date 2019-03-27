using UnityEngine;

public class MusicDestroyer : MonoBehaviour {
    private void Awake() {
        MusicPlayer.ResetMusic();
    }
}
