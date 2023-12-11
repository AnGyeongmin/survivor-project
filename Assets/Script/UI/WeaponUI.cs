using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public GameObject GunObject;
    public GameObject ShovelObject;
    public GameObject TridentObject;
    public GameObject thePlayer;

    public Button GunButton;
    public Button ShovelButton;
    public Button TridentButton;
    public Button HealButton;

    Gun weapon_Gun;
    Shovel weapon_Shovel;
    Trident weapon_Trident;

    public bool Gun_Max;
    public bool Shovel_Max;
    public bool Trident_Max;

    private void Start()
    {
        weapon_Gun = GunObject.GetComponent<Gun>();
        weapon_Shovel = ShovelObject.GetComponent<Shovel>();
        weapon_Trident = TridentObject.GetComponent<Trident>();
    }

    private void Update()
    {

        if (weapon_Gun.gunsLevel == weapon_Gun.MaxGunLevel)
        {
            GunButton.gameObject.SetActive(false);
            Gun_Max = true;
        }
        if (weapon_Shovel.shovelLevel == weapon_Shovel.MaxShovelLevel)
        {
            ShovelButton.gameObject.SetActive(false);
            Shovel_Max = true;
        }
        if (weapon_Trident.tridentLevel == weapon_Trident.MaxTridentLevel)
        {
            TridentButton.gameObject.SetActive(false);
            Trident_Max = true;
        }

        if(Gun_Max && Shovel_Max && Trident_Max)
        {
            HealButton.gameObject.SetActive(true);
        }
    }

    public void Weapon_Gun()
    {
        if (weapon_Gun.hasGun == false)
        {
            GunObject.SetActive(true);
            weapon_Gun.gunsLevel = 1;
            weapon_Gun.hasGun = true;
        }
        else if(weapon_Gun.hasGun == true)
        {
            weapon_Gun.gunsLevel++;
        }
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Weapon_Shovel()
    {
        if (weapon_Shovel.HasShovel == false)
        {
            weapon_Shovel.shovelLevel = 1;
            ShovelObject.SetActive(true);
            weapon_Shovel.HasShovel = true;
        }
        else if(weapon_Shovel.HasShovel == true)
        {
            weapon_Shovel.gameObject.SetActive(false);
            foreach(Transform child in weapon_Shovel.transform)
            {
                Destroy(child.gameObject);
            }
            weapon_Shovel.list.Clear();
            weapon_Shovel.count++;
            weapon_Shovel.shovelLevel++;
            weapon_Shovel.Countdown = 0;
            weapon_Shovel.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Weapon_Trident()
    {
        if(weapon_Trident.hasTrident == false)
        {
            TridentObject.SetActive(true);
            weapon_Trident.tridentLevel = 1;
            weapon_Trident.hasTrident = true;
        }
        if(weapon_Trident.hasTrident == true)
        {
            weapon_Trident.tridentLevel++;
        }

        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Heal()
    {
        PlayerController player = thePlayer.GetComponent<PlayerController>();
        player.TakeHeal(20);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
