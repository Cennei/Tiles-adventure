using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public void Move(Vector2 target, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
    }
}
