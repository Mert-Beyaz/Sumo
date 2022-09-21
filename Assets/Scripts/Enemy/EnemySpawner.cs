using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> SpawnTransformList = new List<Transform>();
    public GameController pool;
    public List<GameObject> EnemyList = new List<GameObject>();
    public TextMeshProUGUI EnemyText;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy() //Burada arenada belirlediğimiz yerlere AI'ları spawn ediyoruz.
    {
        for (int i = 0; i < pool.EnemyCount ; i++)
        {
            Transform location = SpawnTransformList[i];
            GameObject enemy = pool.GetEnemyFromPool();
            enemy.transform.position = location.position;
            EnemyList.Add(enemy);
        }
    }

    private void Update()
    {
        EnemyText.text = "Enemy " + EnemyList.Count; 
    }
}
