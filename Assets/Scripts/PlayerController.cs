using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float PlayerSpeed {get; private set;}

    private PlayerControl PlayerControl ; 

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

    void Update()
    {
        Vector2 inputVector = PlayerControl.Player.Move.ReadValue<Vector2>();
        transform.Translate(PlayerSpeed * Time.deltaTime * inputVector);
    }
}