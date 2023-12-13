using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shovel : Attack
{
    private float turnSpeed = -150;
    public GameObject shovel;
    private GameObject bullet;

    private float countdown = 0;
    public float Countdown
    {
        get { return countdown; }
        set { countdown = value; }
    }
    private float enable = 10;
    private float destroyTime;

    [SerializeField]
    private float Count;
    public float count
    {
        get { return Count; }
        set { Count = value; }
    }

    public List<GameObject> list;

    private int ShovelLevel;
    public int shovelLevel
    {
        get { return ShovelLevel; }
        set { ShovelLevel = value; }
    }
    public int MaxShovelLevel = 8;

    private bool hasShovel = false;
    public bool HasShovel
    {
        get { return hasShovel; }
        set { hasShovel = value; }
    }

    //�ʱ�ȭ
    void Awake()
    {
        list = new List<GameObject>();
        destroyTime = enable + 10 + GameManager.Instance.player.Duration;
        count = 2 + GameManager.Instance.player.Projectile;
    }


    //���� ����(����ġ ���̽���)
    private void OnEnable()
    {

        switch (shovelLevel)
        {
            case 1:
                GetShovel(150, 1.5f);
                break;
            case 2:
                GetShovel(170, 1.5f);
                break;
            case 3:
                GetShovel(190, 1.5f);
                break;
            case 4:
                GetShovel(200, 1.5f);
                break;
            case 5:
                GetShovel(200, 1.5f);
                turnSpeed = -200;
                break;
            case 6:
                GetShovel(200, 1.5f);
                turnSpeed = -200;
                destroyTime = enable + 5;
                break;
            case 7:
                GetShovel(200, 1.5f);
                turnSpeed = -200;
                destroyTime = enable + 5;
                enable += 5;
                break;
            case 8:
                GetShovel(300, 1.5f);
                turnSpeed = -200;
                destroyTime = enable + 5;
                enable += 5;
                break;
        }
    }

    //��Ÿ�� �� ���ӽð�
    private void Update()
    {
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime * GameManager.Instance.player.BulletSpeed);

        if (hasShovel)
        {
            countdown += Time.deltaTime;
            if (countdown < enable)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].SetActive(true);
                }
            }
            else
            {
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].SetActive(false);
                    }
                }
            }
            if(countdown >= destroyTime)
            {
                countdown = 0;
            }
        }
    }

    //�� ����
    void GetShovel(float damage, float Range)
    {
        for (int index = 0; index < count; index++)
        {
            //�� ũ��
            Range = GameManager.Instance.player.AttackRange;
            //�� ����
            bullet = Instantiate(shovel, transform.position, Quaternion.identity);
            //���� ũ��
            bullet.transform.localScale = Vector3.one * Range;
            //������ �� ����Ʈ�� �߰�
            list.Add(bullet);
            //�� ���ý�ũ��Ʈ �߰�
            bullet.AddComponent<Attack>();
            //���� ��ũ��Ʈ ��������
            Attack attack = bullet.GetComponent<Attack>();
            //�� ���ݷ�
            attack.attackDamage = damage * GameManager.Instance.player.AttackDamage;
            //������ ���� �ڽ����� ��������
            bullet.transform.parent = transform;
            //���� �÷��̾� �߽����� 360/count ��ġ�� �α�
            Vector3 rotVec = Vector3.forward * 360 / count;
            //���� ��ġ ����
            bullet.transform.Translate(bullet.transform.up * 1.5f, Space.World);
            //���� ȸ��
            transform.Rotate(rotVec);
        }
    }
}
