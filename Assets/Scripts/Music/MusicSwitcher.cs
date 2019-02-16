using UnityEngine;

public class MusicSwitcher : MonoBehaviour {
    [SerializeField] private AudioClip clip;

    private void Start() {
        try { MusicPlayer.SwitchTracks(clip); }
        catch { }
    }
}
