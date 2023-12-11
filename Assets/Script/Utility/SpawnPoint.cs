using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Vector3 SpawnRange;

    public Transform Player;
    // Update is called once per frame
    void Update()
    {
        float randX = Random.Range(-20, 20);
        float randY = Random.Range(-20, 20);

        SpawnRange = new Vector2(Player.position.x + randX, Player.position.y + randY);

        transform.position = SpawnRange;
    }
}
