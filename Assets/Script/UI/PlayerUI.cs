using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI Exp;
    public Image expBar;
    public SceneFader fader;

    public PlayerController ThePlayer;

    private void Awake()
    {
        ThePlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        fader.InFade(0.1f);
    }

    private void Update()
    {
        playerLevel.text = "0" + ThePlayer.PlayerLevel;
        Exp.text = $"{ThePlayer.PlayerExp} / {ThePlayer.PlayerMaxExp}";

        expBar.fillAmount = ThePlayer.PlayerExp / ThePlayer.PlayerMaxExp;
    }
}
