using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy enemy;

    [SerializeField]
    public float attackDamage = 10f;

    [SerializeField]
    private Vector2 knockback = Vector2.zero;

    private Vector2 directionKnockback;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.transform.GetComponent<PlayerController>();

        Vector2 dir = collision.transform.position - transform.position;

        directionKnockback = knockback * dir.normalized;

        if (player != null)
        {
            if (enemy.IsDeath)
                return;

            player.TakeDamage(attackDamage, directionKnockback);
        }
    }

}
