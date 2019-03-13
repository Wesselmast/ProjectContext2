using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Door : MonoBehaviour {
    [SerializeField] private GameObject arrow;
    [SerializeField] private LevelSettings level;

    public static List<string> CurrentFurnitures = new List<string>();
    private List<string> requiredFurnitureNames = new List<string>();

    private GameObject player;
    private Animator fader;
    private FurniturePlacement placement;
    private GameObject weapon;
    private bool isComplete = false;

    private void Awake() {
        player = FindObjectOfType<ContextInput.PlayerInput>().gameObject;
        try { fader = GameObject.Find("Fader").GetComponent<Animator>(); }
        catch { }
        weapon = player.transform.GetChild(0).GetChild(0).gameObject;
        placement = player.GetComponent<FurniturePlacement>();
    }

    private void Start() {
        requiredFurnitureNames = level.RequiredFurnitures;
        CurrentFurnitures.Clear();
    }

    private void Update() {
        if (CompareLists(requiredFurnitureNames, CurrentFurnitures) && FindObjectsOfType<RaycastTargeting>().All(r => r.ObjectIsTouching())) {
            isComplete = true;
            weapon.SetActive(false);
            arrow.SetActive(true);
            placement.enabled = false;
        }
    }

    private bool CompareLists<T>(List<T> aListA, List<T> aListB) {
        if (aListA == null || aListB == null) {
            return false;
        }
        if (aListA.Count == 0) {
            return true;
        }

        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        for (int i = 0; i < aListA.Count; i++) {
            if (!lookUp.TryGetValue(aListA[i], out int count)) {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++) {
            if (!lookUp.TryGetValue(aListB[i], out int count)) {
                return false;
            }
            count--;
            if (count <= 0) {
                lookUp.Remove(aListB[i]);
            }
            else {
                lookUp[aListB[i]] = count;
            }
        }
        return lookUp.Count == 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && isComplete) {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else SceneManager.LoadScene(0);
    }
}