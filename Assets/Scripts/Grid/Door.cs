using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Door : MonoBehaviour {
    [SerializeField] private Animator fader;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject arrow;

    private Furniture[] requiredFurnitures;
    private List<string> requiredFurnitureNames = new List<string>();
    private bool isComplete = false;
    private FurniturePlacement placement;
    private GameObject weapon;

    public static List<string> currentFurnitures = new List<string>();

    private void Awake() {
        requiredFurnitures = FindObjectOfType<RequiredFurnitures>().GetRequiredFurnitures();
        weapon = player.transform.GetChild(0).GetChild(0).gameObject;
        placement = player.GetComponent<FurniturePlacement>();
        for (int i = 0; i < requiredFurnitures.Length; i++) {
            requiredFurnitureNames.Add(requiredFurnitures[i].customName);
        }
        currentFurnitures.Clear();
    }

    private void Update() {
        if (CompareLists(requiredFurnitureNames, currentFurnitures)) {
            isComplete = true;
            weapon.SetActive(false);
            arrow.SetActive(true);
            placement.enabled = false;
        }
    }

    private bool CompareLists<T>(List<T> aListA, List<T> aListB) {
        if (aListA == null || aListB == null)
            return false;
        if (aListA.Count == 0)
            return true;

        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++) {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count)) {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++) {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count)) {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
