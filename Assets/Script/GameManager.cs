using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public TimerUI timer;
    public ExpSpawner spawner;

    private void Awake()
    {
        instance = this;
    }
}
