using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject Quit_Continue;
    public void OnPauseClick()
    {
        Quit_Continue.SetActive(true);
        Time.timeScale = 0f;//Oyunu durduruyor.
    }
    public void OnContinueClick()
    {
        Quit_Continue.SetActive(false);
        Time.timeScale = 1f;//Oyunu başlatıyor.
    }
    public void OnTryAgainClick()// Play again ve Tyr again de çağrılan fonksiyon.
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }


}
