using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float PlayerSpeed { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public AttackAction Attack { get; private set; }

    private PlayerControl PlayerControl ;
    private Vector2 inputVector;

    private void Awake()
    {
        PlayerControl = new PlayerControl();
        PlayerControl.Player.Attack.performed += AttackPerformed;
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Debug.Log("Attack" + obj.phase);
            Attack.Attack();
        }
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