using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

    [SerializeField] private int amtOfTimeInSeconds;

    private float elapsed = 0;

    private void Update() {
        if (elapsed > amtOfTimeInSeconds) {
            if(SceneManager.GetActiveScene().name == "Level 4.1") SceneManager.LoadScene("Ending");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else elapsed += Time.deltaTime;
    }
}
