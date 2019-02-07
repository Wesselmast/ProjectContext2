using System;
using ContextInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform character;
    [SerializeField] private WingDetection self, gun;

    private Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        PlayerInput.Rotate += Rotate;
    }

    private void Rotate(Direction dir)
    {
        if (dir == Direction.Left && (self.LocalLeft && gun.LocalLeft))
        {
            character.eulerAngles -= Vector3.up * 90;
        }
        else if (dir == Direction.Right && (self.LocalRight && gun.LocalRight))
        {
            character.eulerAngles += Vector3.up * 90;
        }
    }
    private void Update()
    {
        if (gun.Forward && self.Forward && PlayerInput.Horizontal < 0) transform.position += Vector3.forward;
        if (gun.Back && self.Back && PlayerInput.Horizontal > 0) transform.position += Vector3.back;
        if (gun.Left && self.Left && PlayerInput.Vertical < 0) transform.position += Vector3.left;
        if (gun.Right && self.Right && PlayerInput.Vertical > 0) transform.position += Vector3.right;
    }
}