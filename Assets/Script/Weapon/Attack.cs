using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PlayerController player;

    [SerializeField]
    public float attackDamage = 10f;

    [SerializeField]
    private Vector2 knockback = Vector2.zero;

    private Vector2 directionKnockback;

    private void Start()
    {
        player = GameManager.instance.player;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        Vector2 dir = collision.transform.position - transform.position;

        directionKnockback = knockback * dir.normalized;

        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage, directionKnockback);
        }
    }

}
