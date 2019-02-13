﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour {
    [SerializeField] private KeyCode transitionButton = KeyCode.None;
    [SerializeField] private Animator fader;
    [SerializeField] private string nextLevel;
    private Button button;

    private void Awake() {
        if (nextLevel == string.Empty) nextLevel = SceneManager.GetActiveScene().name;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(Transition()));
    }

    private void Update() {
        if (Input.GetKeyDown(transitionButton)) StartCoroutine(Transition());
    }

    IEnumerator Transition() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(nextLevel);
    }
}