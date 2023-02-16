using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeToDestroy : MonoBehaviour
{
    [field: SerializeField] public float LifeTime { get; private set; }

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}
