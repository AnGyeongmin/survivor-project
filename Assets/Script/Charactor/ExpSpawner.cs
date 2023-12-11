using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    public GameObject ExpPrefab;
    public List<GameObject> pool;

    private GameObject Exp;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < 200; i++)
        {
            Exp = Instantiate(ExpPrefab, transform.position, Quaternion.identity);
            Exp.SetActive(false);
            pool.Add(Exp);
            Exp.transform.parent = transform;
        }
    }
}
