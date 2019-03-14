using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    private static MusicPlayer instance = null;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void ResetMusic() {
        Destroy(instance.gameObject);
    }
}