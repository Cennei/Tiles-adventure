using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field:SerializeField] public HealthBar HealthBar { get; private set; }
    [field:SerializeField] public GameObject DamagePopupUI { get; private set; }

    public int myHealth;
    private bool isDead = false;

    private void Awake()
    {
        if (HealthBar == null ) { return; }
        HealthBar.SetMaxHealth(myHealth);
    }
    public bool IsDead()
    {
        return isDead;
    }

    public void Die()
    {
        if (myHealth <= 0)
        {
            isDead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (myHealth <= 0)
        {
            myHealth = 0;
            return;
        }
        DamagePopup(damage);
        myHealth = myHealth - damage;
        if (HealthBar == null) { return; }
        HealthBar.SetHealth(myHealth);
    }

    private void DamagePopup(int damage)
    {
        if (DamagePopupUI == null) { return; }
        GameObject Popup = Instantiate(DamagePopupUI, transform.position, Quaternion.identity);
        //Popup.GetComponentInChildren<TextMesh>().text = damage.ToString();
    }
}
