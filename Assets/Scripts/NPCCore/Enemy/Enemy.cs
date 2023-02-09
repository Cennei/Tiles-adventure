using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : NPC
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public Transform Target { get; private set; }
    [field: SerializeField] public Transform SpawnPoint { get; private set; }
    [field: SerializeField] public int SpawnArea { get; private set; }

    private float distanceToSpawn;
    private void Start()
    {
        NewPointPos(Target);
    }
    private void FixedUpdate()
    {
        distanceToSpawn = Vector2.Distance(transform.position,SpawnPoint.position);
        if (distanceToSpawn > SpawnArea)
        {
            Move(SpawnPoint.position, Speed * Time.deltaTime);
        }
        else
        {
            Move(Target.position, Speed * Time.deltaTime);
        }
        if (transform.position == Target.position)
        {
            NewPointPos(Target);
        }
    }

    private void NewPointPos(Transform target)
    {
        Vector3 position = new Vector3();
        if (SpawnPoint.position.x > 0)
        {
            position.x = Random.Range(-SpawnArea / 1.5f, SpawnArea / 1.5f) + Mathf.Abs(SpawnPoint.position.x);
        }
        else
        {
            position.x = Random.Range(-SpawnArea / 1.5f, SpawnArea / 1.5f) - Mathf.Abs(SpawnPoint.position.x); 
        }
        if (SpawnPoint.position.y > 0)
        {
            position.y = Random.Range(-SpawnArea / 1.5f, SpawnArea / 1.5f) + Mathf.Abs(SpawnPoint.position.y);
        }
        else
        {
            position.y = Random.Range(-SpawnArea / 1.5f, SpawnArea / 1.5f) - Mathf.Abs(SpawnPoint.position.y);
        }    
            target.position = position;
        //Нужно для правильного вычисления позиции точки внутри области SpawnArea.
        //Деление SpawnArea даёт значение внутри круга независимо от полученного значения.
        //Сложение\вычитание позиции SpawnPoint для вычисления позиций внутри круга независимо от его местоположения.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(SpawnPoint.position, SpawnArea); // SpawnArea Range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Target.position, 1);
    }
}
