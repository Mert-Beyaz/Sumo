using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public GameObject Enemy;
    public int EnemyCount;
    public List<GameObject> EnemyPoolList = new List<GameObject>();
    public List<Color> EnemyColorList = new List<Color>();

    private void Awake() //Burada AI oyuncularını sürekli yok edip yendiden oluşturmamak için bir AI havuzu yapıyoruz. 
    {
        FillPool();
    }
    public void FillPool()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            var spawned = Instantiate(Enemy, transform);
            spawned.SetActive(false);
            spawned.GetComponent<MeshRenderer>().material.color = EnemyColorList[i];
            EnemyPoolList.Add(spawned);
        }
    }

    public GameObject GetEnemyFromPool()
    {
        GameObject enemy = EnemyPoolList[0];
        enemy.transform.parent = null;
        enemy.gameObject.SetActive(true);
        EnemyPoolList.Remove(enemy.gameObject);
        return enemy.gameObject;
    }

    public void ResendEnemyToPool(GameObject enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.parent = transform;
        EnemyPoolList.Add(enemy);
    }
}
