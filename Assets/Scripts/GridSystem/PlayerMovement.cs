using System;
using ContextInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private Transform character;

    private Grid grid;

    private void Awake() {
        grid = FindObjectOfType<Grid>();
        PlayerInput.Rotate += Rotate;
    }

    private void Rotate(Direction dir) {
        character.localEulerAngles += dir == Direction.Left ?
                                      new Vector3(0, 90, 0) :
                                      new Vector3(0, -90, 0);
    }

    private void Update() {

        //Collider[] cols = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity);
        //foreach (Collider c in cols) Debug.Log(c.name);
        Vector3 moveTo = new Vector3(-PlayerInput.Vertical, 0, PlayerInput.Horizontal);
        transform.Translate(moveTo * Time.deltaTime * speed);
    }
}