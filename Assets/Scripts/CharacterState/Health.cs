using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MyHealth { get; private set; }

    private bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void Die()
    {
        if (MyHealth <= 0)
        {
            isDead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (MyHealth <= 0)
        {
            MyHealth = 0;
            return;
        }
        MyHealth = MyHealth - damage;
    }
}
