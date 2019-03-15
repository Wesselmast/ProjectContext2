using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

    [SerializeField] private int amtOfTimeInSeconds;

    private float elapsed = 0;

    void Update() {
        if (elapsed > amtOfTimeInSeconds) {
            SceneManager.LoadScene("Ending");
        }
        else elapsed += Time.deltaTime;
    }
}
