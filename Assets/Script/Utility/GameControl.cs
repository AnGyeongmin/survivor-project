using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public GameObject UpgradeUI;

    public float damage;
    public float coolTime;
    public float duration;
    public float projectile;
    public float attackRange;
    public float bulletSpeed;

    public void Update()
    {
        SaveState();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void SaveState()
    {
        damage = PlayerPrefs.GetFloat("Damage");
        coolTime = PlayerPrefs.GetFloat("CoolTime");
        duration = PlayerPrefs.GetFloat("Duration" );
        projectile = PlayerPrefs.GetFloat("Projectile");
        attackRange = PlayerPrefs.GetFloat("AttackRange");
        bulletSpeed = PlayerPrefs.GetFloat("BulletSpeed");
    }
}
