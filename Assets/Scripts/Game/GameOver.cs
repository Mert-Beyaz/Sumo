using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public EnemySpawner EnemySpawner;
    public TriggerController TriggerController;
    public Timer _time;
    public GameObject Win;
    public GameObject Lose;
    public bool isAlive = true;
    public Animator Animator;

    private void Update()
    {
        if (EnemySpawner.EnemyList.Count == 0) //Eğer Player herkesi düşürerek kazanmışsa çalışan bir if fonksiyonu.
        {
            StartCoroutine(WinAnim());
            IEnumerator WinAnim()
            {
                Animator.SetBool("Win", true);
                yield return new WaitForSeconds(2);
                Win.SetActive(true);
                Animator.SetBool("Win", false);
            }
            
        }

        else if (!isAlive)//Eğer Player alandan düşmüşse çalışan bir if fonksiyonu.
        {
            //kaybetme animasyonu
            Lose.SetActive(true);
        }
        else if (_time._Time <= 0)
        {
            StartCoroutine(WinAnim());
            IEnumerator WinAnim()
            {
                Animator.SetBool("Win", true);
                yield return new WaitForSeconds(2);
                Win.SetActive(true);
                Animator.SetBool("Win", false);
            }
        }
        
    }
}
