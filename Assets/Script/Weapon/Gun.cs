using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;

    private float count;

    private int GunsLevel = 1;
    public int gunsLevel
    {
        get { return GunsLevel; }
        set { GunsLevel = value; }
    }
    public int MaxGunLevel = 8;

    private bool HasGun = false;
    public bool hasGun
    {
        get { return HasGun; }
        set { HasGun = value; }
    }

    [SerializeField]
    private float countdown = 0;
    [SerializeField]
    private float fireTime = 1;

    //무기 레벨(스위치 케이스)
    private void Update()
    {

        switch(gunsLevel)
            {
            case 1:
                Fire(0f, 80f, 10f, 1);
                break;
            case 2:
                Fire(0.1f, 80f, 10f, 1);
                break;
            case 3:
                Fire(0.2f, 88f, 10f, 1);
                break;
            case 4:
                Fire(0.2f, 88f, 11f, 1);
                break;
            case 5:
                Fire(0.2f, 88f, 11f, 1);
                break;
            case 6:
                Fire(0.4f, 96.8f, 11f, 1);
                break;
            case 7:
                Fire(0.4f, 96.8f, 12.1f, 1);
                break;
            case 8:
                Fire(0.7f, 96.8f, 12.1f, 1);
                break;
            }
    }

    //발사
    void Fire(float coolTime, float damage, float speed, float bulletcount)
    {
        //총알 스크립트 가져오기
        Bullet bullet = Bullet.transform.GetComponent<Bullet>();
        //총알 공격력
        bullet.attackDamage = damage;
        //총알 스피드
        bullet.bulletSpeed = speed * GameManager.Instance.player.BulletSpeed;
        //쿨타임
        fireTime = 1 - coolTime * GameManager.Instance.player.CoolTime;
        //총알 수
        count = bulletcount + GameManager.Instance.player.Projectile;
        //발사 딜레이
        countdown += Time.deltaTime;
        if (fireTime < countdown)
        {
            StartCoroutine(BulletPrefab());
            countdown = 0;
        }
    }

    //총알 생성
    IEnumerator BulletPrefab()
    {
        for(int i = 0; i < count; i++)
        {
            GameObject bp = Instantiate(Bullet, transform.position, Quaternion.identity);
            bp.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
