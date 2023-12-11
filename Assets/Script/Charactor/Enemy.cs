using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    private Rigidbody2D rb;
    private SpriteRenderer rand;
    private EnemyAttack attack;

    private GameObject target;

    [SerializeField]
    private float MaxHealth = 100;
    [SerializeField]
    private float RealHealth;

    [SerializeField]
    private float moveSpeed = 0.5f;

    [SerializeField]
    private Vector2 dir;

    private int random;



    // Update is called once per frame
    private void FixedUpdate()
    {
        HpBar.fillAmount = RealHealth / MaxHealth;

        if (IsDeath)
        {
            StartCoroutine(Die());
            IsExp = false;
            return;
        }
            OnMove();
    }

    public bool IsLockVelocity
    {
        get { return animator.GetBool("IsLockVelocity"); }
        private set
        {
            animator.SetBool("IsLockVelocity", value);
        }
    }

    void OnMove()
    {
        if (IsDeath)
            return;

        if (IsLockVelocity == false) 
        {
            dir = target.transform.position - transform.position;
            rb.velocity = (dir.normalized * moveSpeed);
            LookPlayer();
        }
    }

    void LookPlayer()
    {
        if (IsDeath)
            return;

        if(dir.x < 0)
        {
            rand.flipX = true;
        }
        else
        {
            rand.flipX= false;
        }
    }

    IEnumerator Die()
    {
        animator.SetBool("IsDeath", true);

        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        IsDeath = false;
        animator.SetBool("IsDeath", false);
    }
    public void OnHit(float damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, knockback.y);
    }

    public override void TakeDamage(float damage, Vector2 knockback)
    {
        base.TakeDamage(damage, knockback);
        RealHealth -= damage * GameManager.instance.player.AttackDamage;

        animator.SetTrigger("HitTrigger");

        IsLockVelocity = true;

        if (RealHealth <= 0)
        {
            IsDeath = true;
            hpBar.SetActive(false);
            IsExp = true;
        }
    }

    public void State()
    {
        if (GameManager.instance.timer.stageLevel > 0)
        {
            MaxHealth = MaxHealth * GameManager.instance.timer.stageLevel;
            moveSpeed = moveSpeed * GameManager.instance.timer.stageLevel * 0.2f;
            attack.attackDamage = attack.attackDamage * GameManager.instance.timer.stageLevel * 0.5f;
        }
    }

    public virtual void OnEnable()
    {
        dir = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        hitAction += OnHit;
        rand = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player");
        attack = GetComponent<EnemyAttack>();
        RealHealth = MaxHealth;
    }

    public void OnDisable()
    {
        int DropRand = Random.Range(1, 11);
        if (IsDeath && DropRand > 5)
        {
            random = Random.Range(1, 200);
            GameManager.instance.spawner.pool[random].transform.position = transform.position;
            GameManager.instance.spawner.pool[random].SetActive(true);
        }
    }
}
