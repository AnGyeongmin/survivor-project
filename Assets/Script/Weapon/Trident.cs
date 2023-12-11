using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident : Attack
{
    public GameObject Tridents;

    private float countdown = 0f;
    private float fireTime = 5f;
    private float count;

    private bool HasTrident = false;
    public bool hasTrident
    {
        get { return HasTrident; }
        set { HasTrident = value; }
    }

    private int TridentLevel;
    public int tridentLevel
    {
        get { return TridentLevel; }
        set { TridentLevel = value; }
    }

    public int MaxTridentLevel = 8;

    private void Update()
    {
        switch (TridentLevel)
        {
            case 1:
                Debug.Log(1);
                Fire(100, 20, 2);
                break;
            case 2:
                Fire(120, 20, 2);
                break;
            case 3:
                Fire(120, 20, 3);
                break;
            case 4:
                Fire(150, 20, 4);
                break;
            case 5:
                Fire(150, 30, 4);
                break;
            case 6:
                Fire(150, 30, 4);
                break;
            case 7:
                Fire(200, 30, 5);
                break;
            case 8:
                Fire(200, 35, 5);
                break;
        }
    }

    void Fire(float damage, float speed, float tridentCount)
    {
        //창의 스크립트 가져오기
        ShootTrident trident = Tridents.GetComponent<ShootTrident>();
        //공격력
        trident.attackDamage = damage * GameManager.instance.player.AttackDamage;
        trident.tridentSpeed = speed * GameManager.instance.player.BulletSpeed;
        count = tridentCount + GameManager.instance.player.Projectile;
        countdown += Time.deltaTime;
        if (fireTime < countdown)
        {
            StartCoroutine(FireTrident());
            countdown = 0;
        }
    }

    IEnumerator FireTrident()
    {
        for(int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject bullet = Instantiate(Tridents, transform.position, Quaternion.identity);
            bullet.transform.parent = transform;
        }
    }
}
