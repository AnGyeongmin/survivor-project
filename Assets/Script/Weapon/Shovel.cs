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

    //초기화
    void Awake()
    {
        list = new List<GameObject>();
        destroyTime = enable + 10 + GameManager.Instance.player.Duration;
        count = 2 + GameManager.Instance.player.Projectile;
    }


    //무기 레벨(스위치 케이스문)
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

    //쿨타임 및 지속시간
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

    //삽 생성
    void GetShovel(float damage, float Range)
    {
        for (int index = 0; index < count; index++)
        {
            //삽 크기
            Range = GameManager.Instance.player.AttackRange;
            //삽 생성
            bullet = Instantiate(shovel, transform.position, Quaternion.identity);
            //삽의 크기
            bullet.transform.localScale = Vector3.one * Range;
            //생성한 삽 리스트에 추가
            list.Add(bullet);
            //삽에 어택스크립트 추가
            bullet.AddComponent<Attack>();
            //어택 스크립트 가져오기
            Attack attack = bullet.GetComponent<Attack>();
            //삽 공격력
            attack.attackDamage = damage * GameManager.Instance.player.AttackDamage;
            //생성한 삽을 자식으로 가져오기
            bullet.transform.parent = transform;
            //삽을 플레이어 중심으로 360/count 위치에 두기
            Vector3 rotVec = Vector3.forward * 360 / count;
            //삽의 위치 지정
            bullet.transform.Translate(bullet.transform.up * 1.5f, Space.World);
            //삽의 회전
            transform.Rotate(rotVec);
        }
    }
}
