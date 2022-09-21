using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class TriggerController : MonoBehaviour
{
    public GameObject Pool;
    public GameObject EnemyList;
    public GameObject Enemy;
    public GameObject CoinSpawner;
    public GameObject LastTriggerObject;
    public GameObject ScoreFind;
    public GameObject GameOver;
    public TextMeshProUGUI ScoreText;
    public int Score = 0;
    public int PassingScore = 500;
    private Rigidbody rb;


    private void Start()
    {
        Pool = GameObject.FindGameObjectWithTag("GameManager");
        EnemyList = GameObject.FindGameObjectWithTag("Arena");
        CoinSpawner = GameObject.FindGameObjectWithTag("GameManager");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        ScoreFind = GameObject.FindGameObjectWithTag("GameManager");
        GameOver = GameObject.FindGameObjectWithTag("GameManager");
        ScoreText = ScoreFind.GetComponent<GameController>().ScoreText;
         rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Score >= PassingScore)
        {
            transform.localScale += Vector3.one / 2; 
            PassingScore += 500;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player") //Eğer çarptığımız şey düşman veya Player ise çarpımanın etkisi ile geri tepiyoruz.
        {
            LastTriggerObject = other.gameObject;
            rb.AddForce(Vector3.back * 4);//çarpıştığı noktayı bulup tersine göndereceğiz

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadArea") //Arenadan çıkan oyuncuları buluyoruz.
        {
            if (this.gameObject.tag == "Player")
            {
                GameOver.GetComponent<GameOver>().isAlive = false;
            }
            if (LastTriggerObject != null)// Burada düştükten sonra düşen oyuncuya en son dokununan kişiyi bulup, ona düşen oyuncunun puanlarını veriyoruz.
            {
                GetComponent<TriggerController>().Score += LastTriggerObject.GetComponent<TriggerController>().Score;
                if (this.gameObject.tag == "Player")
                {
                    ScoreText.text = "" + Score;
                }
            }
            EnemyList.GetComponent<EnemySpawner>().EnemyList.Remove(this.gameObject);
            Pool.GetComponent<GameController>().ResendEnemyToPool(this.gameObject);

        }

        if (other.gameObject.tag == "Coin")// Altın toplayan her oyuncu +100 puan kazanacak
        {
            Score += 100;
            if (this.gameObject.tag == "Player")
            {
                ScoreText.text = "" + Score;
            }
            other.gameObject.SetActive(false);
            StartCoroutine(SpawnAgain());
            IEnumerator SpawnAgain()
            {
                yield return new WaitForSeconds(1);
                Vector3 randomPos = CoinSpawner.GetComponent<CoinSpawner>().RandomPosCoin();
                other.gameObject.SetActive(true);
                other.gameObject.transform.position = randomPos;

            }

        }
    }   

}
