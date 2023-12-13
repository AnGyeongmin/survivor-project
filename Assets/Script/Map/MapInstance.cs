using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstance : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 PlayerPos = GameManager.Instance.player.transform.position;
        Vector3 TilePos = transform.position;
        float diffx = Mathf.Abs(TilePos.x - PlayerPos.x);
        float diffy = Mathf.Abs(TilePos.y - PlayerPos.y);

        Vector3 PlayerVec = GameManager.Instance.player.rb.velocity;
        float dirx = PlayerVec.x < 0 ? -1 : 1;
        float diry = PlayerVec.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffx > diffy)
                {
                    transform.Translate(Vector3.right * dirx * 60);
                }
                else if(diffx < diffy)
                {
                    transform.Translate(Vector3.up * diry * 60);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
