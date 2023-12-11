using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExp : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed = 5f;
    private float GetExpZone = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerController player = collision.transform.GetComponent<PlayerController>();

        Vector3 PlayerPos = GameManager.instance.player.transform.position;
        Vector3 ExpPos = transform.position;

        Vector3 dir = PlayerPos - ExpPos;

        float distance = Vector3.Distance(PlayerPos, ExpPos);

        if(distance <= GetExpZone)
        {
            rb.velocity = dir.normalized * moveSpeed;
        }

        if (distance <= 0.5f)
        {
            player.TakeExp(10);
            this.gameObject.SetActive(false);
        }
    }
}
