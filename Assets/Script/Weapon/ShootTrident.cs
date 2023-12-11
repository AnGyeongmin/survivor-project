using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrident : Attack
{
    public PlayerController thePlayer;
    private Rigidbody2D rb;
    private float turnSpeed = -150;
    public float tridentSpeed;
    private Vector2 lastVelocity;

    private float RandX;
    private float RandY;
    private Vector2 RandVec;

    private Vector2 shoot;

    private void Awake()
    {
        thePlayer = GameObject.Find("Player").transform.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RandX = Random.Range(-1, 1);
        RandY = Random.Range(-1, 1);
        RandVec = new Vector2 (RandX, RandY);
        ShootingTrient();
    }

    private void Update()
    {
        rb.velocity = shoot.normalized * tridentSpeed;
        lastVelocity = rb.velocity;
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    void ShootingTrient()
    {
        if (thePlayer.inputMove == Vector2.zero)
        {
            shoot = RandVec;
        }
        else
        {
            shoot = new Vector2(thePlayer.inputMove.x, thePlayer.inputMove.y);
        }

        transform.rotation = Quaternion.FromToRotation(Vector3.up, shoot);
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
