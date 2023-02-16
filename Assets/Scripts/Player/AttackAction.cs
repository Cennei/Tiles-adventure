using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    [field: SerializeField] public Animator animator { get; private set; }

    [field: SerializeField] public int attackDamage { get; private set; }
    [field: SerializeField] public float attackRange { get; private set; }
    [field: SerializeField] public float attackRate { get; private set; }

    private float nextAttackTime = 0f;
    private PlayerControl PlayerControl;
    public Transform attackPoint;

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
        Vector2 pos;
        pos.x = transform.position.x + PlayerControl.Player.Move.ReadValue<Vector2>().x/2;
        pos.y = transform.position.y + PlayerControl.Player.Move.ReadValue<Vector2>().y/2;
        attackPoint.position = pos;
    }

    public void Attack()
    {
        if (!CanAttack(attackRate, nextAttackTime)) return;
        nextAttackTime = Time.time + 1f / attackRate;

        //animator.SetTrigger("Attack");
        GiveDamage();

    }

    private void GiveDamage()
    {
        Collider2D[] hitedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D target in hitedEnemies)
        {
            if (target.GetComponent<Health>() == null || target.tag == this.tag) continue;
            target.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    private bool CanAttack(float attackRate, float nextAttackTime)
    {
        if (Time.time >= nextAttackTime)
        {
            return true;
        }
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
