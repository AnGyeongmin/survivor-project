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
    //���� üũ
    [SerializeField]
    private bool isDeath;
    public bool IsDeath
    {
        get { return isDeath; }
        set { isDeath = value; }
    }
    //����ġ ���
    private bool isExp;
    public bool IsExp
    {
        get { return isExp; }
        set { isExp = value; }
    }
    #endregion

    #region
    [Header("invinciable")]
    //���� �ð�
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
        //���� ī��Ʈ �ٿ�
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
        //������ �Ա�

        hitAction?.Invoke(damage, knockback);
        //���� �ð�
        invinciable = true;
        
    }
}
