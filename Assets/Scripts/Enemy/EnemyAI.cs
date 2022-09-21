using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject EnemyList;
    public GameObject CoinList;
    public GameObject Speed;
    public GameObject GameOver;
    private Transform Target;
    private int TargetListLenght;
    private float AISpeed;
    public List<GameObject> TargetList = new List<GameObject>();
    void Start()
    {
        Speed = GameObject.FindGameObjectWithTag("Player");
        EnemyList = GameObject.FindGameObjectWithTag("Arena");
        CoinList = GameObject.FindGameObjectWithTag("GameManager");
        GameOver = GameObject.FindGameObjectWithTag("GameManager");
        AISpeed = Speed.GetComponent<PlayerController>().Speed;

        TargetListCreate(); // En yakındaki objeye gitmesi için altın ve düşmanları aynı listeye alıyoruz.
    }

    void Update()
    {      
        TargetFollow();
        TargetListCreate();
    }

    public void TargetFollow()
    {
        if (GameOver.GetComponent<GameOver>().isAlive)
        {
            TargetListLenght = TargetList.Count;

            float distance;
            float distanceTarget;
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            distanceTarget = Vector3.Distance(Target.transform.position, transform.position); //Düşman ile player arasında ki mesafeyi ölçüyoruz.
            for (int i = 0; i < TargetListLenght; i++)
            {
                GameObject enemy = TargetList[i];

                distance = Vector3.Distance(enemy.transform.position, transform.position);
                if (distance != 0 && distance < distanceTarget)//Kendisi dışındaki en yakın hedefe gitmesi için bu komutu koyuyoruz. Eğer Player'den daha yakın bir obje varsa hedefi değiştiriyoruz. 
                {
                    distanceTarget = distance;
                    Target = enemy.transform;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, Target.position, AISpeed / 0.2f * Time.deltaTime);
        }
    }

    public void TargetListCreate()
    {
        TargetList.Clear();
        TargetList.AddRange(EnemyList.GetComponent<EnemySpawner>().EnemyList);
        TargetList.AddRange(CoinList.GetComponent<CoinSpawner>().CoinList);
    }
}
