using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    private float spawnRange = 24;
    public List<GameObject> CoinList = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            CoinSpawn();
        }
    }

    public void CoinSpawn() //Burada altınları random şekilde spawn ediyoruz.
    {
        Vector3 randomPos = RandomPosCoin();
        var spawned = Instantiate(CoinPrefab, randomPos, CoinPrefab.transform.rotation);
        CoinList.Add(spawned);
    }
    public Vector3 RandomPosCoin()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.8f, spawnPosZ);

        return randomPos;
    }
}
