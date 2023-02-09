using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float PlayerSpeed { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    private PlayerControl PlayerControl ;
    private Vector2 inputVector;

    private void Awake()
    {
        PlayerControl = new PlayerControl();
    }
    private void OnEnable()
    {
        PlayerControl.Enable();
    }
    private void OnDisable()
    {
        PlayerControl.Disable();
    }

    private void Update()
    {
        inputVector = PlayerControl.Player.Move.ReadValue<Vector2>();
        Animator.SetFloat("Horizontal", inputVector.x);
        Animator.SetFloat("Vertical", inputVector.y);
        Animator.SetFloat("Speed", inputVector.sqrMagnitude);
    }

    void FixedUpdate()
    {
        transform.Translate(PlayerSpeed * Time.deltaTime * inputVector);
    }
}