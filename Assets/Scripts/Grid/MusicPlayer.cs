using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {
    private static MusicPlayer instance = null;
    private static AudioSource ac;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        ac = GetComponent<AudioSource>();
    }

    public static void SwitchTracks(AudioClip clip) {
        if (ac.clip != clip) {
            ac.clip = clip;
            ac.Play();
        }
    }
}