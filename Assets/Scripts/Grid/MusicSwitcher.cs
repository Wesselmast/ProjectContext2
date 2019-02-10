using UnityEngine;

public class MusicSwitcher : MonoBehaviour {
    [SerializeField] private AudioClip clip;

    private void Awake() {
        MusicPlayer.SwitchTracks(clip);
    }
}
