using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileReposition : MonoBehaviour
{
    //public Transform Player;
    //public Transform tile;
    //public GameObject tPrefab;

    private GameObject thePlayer;
    private GameObject[] ArrayTile;

    private void Start()
    {
        //Player = GameObject.Find("Player").transform;
        
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        ArrayTile = new GameObject[4];
    }

    void Update()
    {
        /*float distanceX = Player.position.x - tile.position.x;
        float distanceY = Player.position.y - tile.position.y;
        if(Mathf.Abs(distanceX) > 60)
        {
            //Debug.Log(distanceX);
            Vector3 tReposition = new Vector3(Player.position.x + 60, Player.position.y, Player.position.z);
            Instantiate(tPrefab, tReposition, Quaternion.identity);
        }
        if (Mathf.Abs(distanceY) > 5)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Player.position.y, transform.localPosition.z);
        }*/
        for(int i = 0; i <= 3; i++)
        {
            GameObject[] Tile = GameObject.FindGameObjectsWithTag("Ground");
            float Idiff = thePlayer.transform.position.x - Tile[i].transform.position.x;
            for(int j = 1; j <= 3; j++)
            {
                float Jdiff = thePlayer.transform.position.x - Tile[j].transform.position.x;
                //Debug.Log(i);
                if (Idiff > Jdiff)
                {
                    ArrayTile[i] = Tile[i];
                    Debug.Log(Idiff);
                    Destroy(Tile[i], 3f);
                }
            }
        }
    }
}
