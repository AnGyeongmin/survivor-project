using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : Attack
{
    private Rigidbody2D rb;

    [SerializeField]
    public float bulletSpeed;

    [SerializeField]
    private Vector2 dir = Vector2.zero;
    public Transform target;

    [SerializeField]
    private int per = 1;

    private void Start()
    {
        bulletSpeed = 10f;
        rb = GetComponent<Rigidbody2D>();
        SurchEnemy();
        LockOnTarget();
    }
    void LockOnTarget()
    {
        
        if (target == null)
        {
            rb.velocity = Vector2.up * bulletSpeed; 
            return;
        }

        dir = target.position - transform.position;
        rb.velocity = (dir.normalized * bulletSpeed);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Destroy(gameObject,3f);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player"))
            return;
        per--;
        if (per < 0)
        {
            Destroy(gameObject);
        }
        target = null;
    }

    void SurchEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 PlayerPos = GameManager.Instance.player.transform.position;
        GameObject nullEnemy = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < enemies.Length - 1; j++)
            {
                float Idistance = Vector2.Distance(PlayerPos, enemies[j + 1].transform.position);
                float Jdistance = Vector2.Distance(PlayerPos, enemies[j].transform.position);
                if (Jdistance > Idistance)
                {
                    nullEnemy = enemies[j];
                    enemies[j] = enemies[j + 1];
                    enemies[j + 1] = nullEnemy;
                }
            }
            target = enemies[0].transform;
        }
    }
}
