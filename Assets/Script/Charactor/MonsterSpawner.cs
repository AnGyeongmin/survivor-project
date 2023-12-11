using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //public Transform tile;

    //프리펩 보관 변수
    public GameObject[] EnemyPrefab;
    //스폰 포인트
    public Transform SpawnPoint;
    //리스트
    List<GameObject> pool;
    //스폰 포인트
    private Vector2 SpawnRange;
    //스폰 시간
    private float countDown = 0;
    private float spawnTime = 3;

    private GameObject enemys;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < EnemyPrefab.Length; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                enemys = Instantiate(EnemyPrefab[i], transform.position, Quaternion.identity);
                enemys.SetActive(false);
                pool.Add(enemys);
                enemys.transform.parent = transform;
            }
        }
    }

    private void Update()
    {
        countDown += Time.deltaTime;
        if (countDown > spawnTime)
        {
            StartCoroutine(GetEnemy());
            countDown = 0;
        }
    }

    IEnumerator GetEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            if (enemys.gameObject.activeSelf)
                yield return null;

            int rand = Random.Range(0, 800);
            yield return new WaitForSeconds(0.1f);
            pool[rand].transform.position = SpawnPoint.transform.position;
            pool[rand].SetActive(true);
        }
    }
}

