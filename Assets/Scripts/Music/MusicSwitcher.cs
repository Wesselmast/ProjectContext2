using UnityEngine;

public class MusicSwitcher : MonoBehaviour {
    [SerializeField] private AudioClip clip;

    private void Start() {
        MusicPlayer.SwitchTracks(clip);
    }
}
