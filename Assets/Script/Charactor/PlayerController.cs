using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Damageable
{
    private SpriteRenderer rend;
    public GameObject WeaponUI;
    WeaponUI weapon;
    public GameObject GameOverUI;
    [SerializeField]
    private float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Vector2 inputMove;
    private Vector3 rbFlip;
     
    #region
    [Header ("Exp")]
    [SerializeField]
    public int PlayerExp = 0;
    [SerializeField]
    public float PlayerMaxExp;
    [SerializeField]
    public float PlayerLevel = 1;
    #endregion

    #region
    [Header ("State")]
    //최대 체력
    [SerializeField]
    private float maxHealth = 100f;
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    //실제 체력
    [SerializeField]
    private float realHealth = 0;
    public float RealHealth
    {
        get { return realHealth; }
        set { realHealth = value; }
    }
    //공격력
    [SerializeField]
    private float attackDamage = 0;
    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }
    //쿨타임
    [SerializeField]
    private float coolTime = 0;
    public float CoolTime
    {
        get { return coolTime; }
        set { coolTime = value; }
    }
    //지속시간
    [SerializeField]
    private float duration = 0;
    public float Duration
    {
        get { return duration; }
        set { duration = value; }
    }
    //투사체 수
    [SerializeField]
    private float projectile = 0;
    public float Projectile
    {
        get { return projectile; }
        set { projectile = value; }
    }
    //공격 범위
    [SerializeField]
    private float attackRange = 0;
    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
    //투사체 속도
    [SerializeField]
    private float bulletSpeed = 0;
    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set { bulletSpeed = value; }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        inputMove = Vector2.zero;
        rbFlip = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        weapon = WeaponUI.GetComponent<WeaponUI>();

        realHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        HpBar.fillAmount = realHealth / maxHealth;

        if (IsDeath == true)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("IsDeath", true);
            GameOverUI.SetActive(true);
            return;
        }
        else
        {
            rb.velocity = new Vector2(inputMove.x * moveSpeed, inputMove.y * moveSpeed);
            Flip();
            LoadState();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
        if(inputMove != Vector2.zero)
        {
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
    }

    void Flip()
    {
        if (inputMove.x == 1)
        {
            rend.flipX = false;
        }
        else if (inputMove.x == -1)
        {
            rend.flipX = true;
        }
    }

    public void TakeExp(int exp)
    {
        PlayerExp += exp;
        if (PlayerExp >= PlayerMaxExp)
        {
            PlayerLevel += 1;
            PlayerExp = 0;
            LevelUP();
        }
    }
    public void LevelUP()
    {
        PlayerMaxExp = PlayerMaxExp * 1.2f;
        WeaponUI.SetActive(true);
    }

    public override void TakeDamage(float damage, Vector2 knockback)
    {
        base.TakeDamage(damage, knockback);
        realHealth -= damage;

        if (realHealth <= 0)
        {
            IsDeath = true;
            hpBar.SetActive(false);
            IsExp = true;
        }
    }

    public void TakeHeal(float healAmount)
    {
        if (IsDeath == true)
            return;


        float maxHeal = maxHealth - realHealth;
        float realHeal = (maxHeal < healAmount) ? maxHeal : healAmount;

        if (realHeal == 0)
            return;

        realHealth += realHeal;

        HpBar.fillAmount = realHealth / maxHealth;
    }
    
    public void LoadState()
    {
        attackDamage = GameControl.instance.damage;
        coolTime = GameControl.instance.coolTime;
        duration = GameControl.instance.duration;
        projectile = GameControl.instance.projectile;
        attackRange = GameControl.instance.attackRange;
        bulletSpeed = GameControl.instance.bulletSpeed;
    }
    
}
