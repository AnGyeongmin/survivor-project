using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    protected Animator animator;
    public Image HpBar;
    public GameObject hpBar;
    public UnityAction<float, Vector2> hitAction;

    #region
    //죽음 체크
    [SerializeField]
    private bool isDeath;
    public bool IsDeath
    {
        get { return isDeath; }
        set { isDeath = value; }
    }
    //경험치 드랍
    private bool isExp;
    public bool IsExp
    {
        get { return isExp; }
        set { isExp = value; }
    }
    #endregion

    #region
    [Header("invinciable")]
    //무적 시간
    private bool invinciable = false;
    [SerializeField]
    private float invinciableTime = 3;
    private float countdown = 0;
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //무적 카운트 다운
        if (invinciable == true)
        {
            countdown += Time.deltaTime;
            if(countdown > invinciableTime)
            {
                invinciable = false;
            }
        }
    }

    public virtual void TakeDamage(float damage, Vector2 knockback)
    {
        if (isDeath == true)
            return;

        hpBar.SetActive(true);
        //데미지 입기

        hitAction?.Invoke(damage, knockback);
        //무적 시간
        invinciable = true;
        
    }
}
