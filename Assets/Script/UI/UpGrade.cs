using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGrade : MonoBehaviour
{
    public SceneFader fader;

    public Button damagebutton;
    public Button cooltimebutton;
    public Button durationbutton;
    public Button projectilebutton;
    public Button attackrangebutton;
    public Button bulletspeedbutton;

    private bool isSave;

    public Image[] damage;
    public Image[] cooltime;
    public Image[] duration;
    public Image[] projectile;
    public Image[] attackRange;
    public Image[] bulletSpeed;

    float UpgradeDamage = 1;
    float UpgradeCoolTime = 0;
    float UpgradeDuration = 1;
    float UpgradeProjectile = 0;
    float UpgradeAttackRange = 1;
    float UpgradeBulletSpeed = 1;

    int maxLevel = 5;

    private int damageLevel;
    private int coolTimeLevel;
    private int durationLevel;
    private int projectileLevel;
    private int attackRangeLevel;
    private int bulletSpeedLevel;

    // Start is called before the first frame update
    void Start()
    {
        fader.InFade(0.1f);
        isSave = PlayerPrefs.HasKey("Damage");
        if (isSave)
        {
            damageLevel = 0;
            coolTimeLevel = 0;
            durationLevel = 0;
            projectileLevel = 0;
            attackRangeLevel = 0;
            bulletSpeedLevel = 0;
        }
        else
        {
            PlayerPrefs.GetFloat("Damage");
            PlayerPrefs.GetFloat("CoolTime");
            PlayerPrefs.GetFloat("Duration");
            PlayerPrefs.GetFloat("Projectile");
            PlayerPrefs.GetFloat("AttackRange");
            PlayerPrefs.GetFloat("BulletSpeed");
        }
    }

    private void Update()
    {
        PlayerState();

        for(int i = 0; i < maxLevel; i++)
        {
            if(i < damageLevel) 
            {
                damage[i].color = Color.black;
            }
            if(i < coolTimeLevel)
            {
                cooltime[i].color = Color.black;
            }
            if(i < durationLevel)
            {
                duration[i].color = Color.black;
            }
            if(i < projectileLevel)
            {
                projectile[i].color = Color.black;
            }
            if (i < attackRangeLevel) 
            {
                attackRange[i].color = Color.black;
            }
            if(i < bulletSpeedLevel)
            {
                bulletSpeed[i].color = Color.black;
            }
        }

        if (damageLevel == maxLevel)
        {
            damagebutton.gameObject.SetActive(false);
        }
        if(coolTimeLevel == maxLevel)
        {
            cooltimebutton.gameObject.SetActive(false);
        }
        if(durationLevel == maxLevel)
        {
            durationbutton.gameObject.SetActive(false);
        }
        if(projectileLevel == maxLevel)
        {
            projectilebutton.gameObject.SetActive(false);
        }
        if(attackRangeLevel == maxLevel)
        {
            attackrangebutton.gameObject.SetActive(false);
        }
        if(bulletSpeedLevel == maxLevel)
        {
            bulletspeedbutton.gameObject.SetActive(false);
        }
    }

    public void Damage()
    {
        damageLevel++;
        for(int i = 0; i < damageLevel; i++)
        {
            switch (damageLevel)
            {
                case 1:
                    UpgradeDamage = 1.1f;
                    break;
                case 2:
                    UpgradeDamage = 1.2f;
                    break;
                case 3:
                    UpgradeDamage = 1.3f;
                    break;
                case 4:
                    UpgradeDamage = 1.4f;
                    break;
                case 5:
                    UpgradeDamage = 1.5f;
                    break;
            }
        }
    }
    public void Cooltime()
    {
        coolTimeLevel++;
        switch (coolTimeLevel)
        {
            case 1:
                UpgradeCoolTime = 1.1f;
                break;
            case 2:
                UpgradeCoolTime = 1.2f;
                break;
            case 3:
                UpgradeCoolTime = 1.3f;
                break;
            case 4:
                UpgradeCoolTime = 1.4f;
                break;
            case 5:
                UpgradeCoolTime = 1.5f;
                break;
        }
    }
    public void Duration()
    {
        durationLevel++;
        switch (durationLevel)
        {
            case 1:
                UpgradeDuration = 1.1f;
                break;
            case 2:
                UpgradeDuration = 1.2f;
                break;
            case 3:
                UpgradeDuration = 1.3f;
                break;
            case 4:
                UpgradeDuration = 1.4f;
                break;
            case 5:
                UpgradeDuration = 1.5f;
                break;
        }
    }
    public void Projectile()
    {
        projectileLevel++;
        switch (projectileLevel)
        {
            case 1:
                UpgradeProjectile = 1f;
                break;
            case 2:
                UpgradeProjectile = 2f;
                break;
            case 3:
                UpgradeProjectile = 3f;
                break;
            case 4:
                UpgradeProjectile = 4f;
                break;
            case 5:
                UpgradeProjectile = 5f;
                break;
        }
    }
    public void AttackRange()
    {
        attackRangeLevel++;
        switch (attackRangeLevel)
        {
            case 1:
                UpgradeAttackRange = 1.1f;
                break;
            case 2:
                UpgradeAttackRange = 1.2f;
                break;
            case 3:
                UpgradeAttackRange = 1.3f;
                break;
            case 4:
                UpgradeAttackRange = 1.4f;
                break;
            case 5:
                UpgradeAttackRange = 1.5f;
                break;
        }
    }
    public void BulletSpeed()
    {
        bulletSpeedLevel++;
        switch (bulletSpeedLevel)
        {
            case 1:
                UpgradeBulletSpeed = 1.1f;
                break;
            case 2:
                UpgradeBulletSpeed = 1.2f;
                break;
            case 3:
                UpgradeBulletSpeed = 1.3f;
                break;
            case 4:
                UpgradeBulletSpeed = 1.4f;
                break;
            case 5:
                UpgradeBulletSpeed = 1.5f;
                break;
        }
    }
    public void MainMenu()
    {
        fader.FadeTo("MainMenu");
    }

    public void ResetUpgrade()
    {
        damageLevel = 0;
        coolTimeLevel = 0;
        durationLevel = 0;
        projectileLevel = 0;
        attackRangeLevel = 0;
        bulletSpeedLevel = 0;
    }

    public void PlayerState()
    {
        PlayerPrefs.SetFloat("Damage", UpgradeDamage);
        PlayerPrefs.SetFloat("CoolTime", UpgradeCoolTime);
        PlayerPrefs.SetFloat("Duration", UpgradeDuration);
        PlayerPrefs.SetFloat("Projectile", UpgradeProjectile);
        PlayerPrefs.SetFloat("AttackRange", UpgradeAttackRange);
        PlayerPrefs.SetFloat("BulletSpeed", UpgradeBulletSpeed);

        PlayerPrefs.Save();
    }
}
