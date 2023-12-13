using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public PlayerController player;
    public TimerUI timer;
    public ExpSpawner spawner;

    private void Awake()
    {
        instance = this;
    }
}
