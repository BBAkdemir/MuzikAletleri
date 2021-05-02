using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject ESCMenu;
    public GameObject LostMenu;
    public GameObject WinMenu;
    public GameObject stopButton;

    public GameObject OyunAlti;
    public GameObject OyunBes;
    public GameObject OyunDort;
    public GameObject OyunUc;
    public GameObject OyunIki;
    public GameObject OyunBir;

    OyunAlti oyunAlti;
    OyunBes oyunBes;
    OyunDort oyunDort;
    OyunUc oyunUc;
    OyunIki oyunIki;

    public bool gameStop = false;

    void Start()
    {
        if (OyunAlti != null)
        {
            oyunAlti = OyunAlti.GetComponent<OyunAlti>();
        }
        if (OyunBes != null)
        {
            oyunBes = OyunBes.GetComponent<OyunBes>();
        }
        if (OyunDort != null)
        {
            oyunDort = OyunDort.GetComponent<OyunDort>();
        }
        if (OyunUc != null)
        {
            oyunUc = OyunUc.GetComponent<OyunUc>();
        }
        if (OyunIki != null)
        {
            oyunIki = OyunIki.GetComponent<OyunIki>();
        }
    }

    void Update()
    {
        if (OyunAlti != null && oyunAlti.oyunKaybedildi == true)
        {
            Time.timeScale = 0;
            LostMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunBes != null && oyunBes.oyunKazanildi == true)
        {
            Time.timeScale = 0;
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunDort != null && oyunDort.oyunKaybedildi == true)
        {
            Time.timeScale = 0;
            LostMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunUc != null && oyunUc.oyunKaybedildi == true)
        {
            Time.timeScale = 0;
            LostMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunIki != null && oyunIki.oyunKazanildi == true)
        {
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        ESCMenu.SetActive(true);
        stopButton.SetActive(false);
        gameStop = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameStop = false;
        ESCMenu.SetActive(false);
        stopButton.SetActive(true);

    }
    public void OpenGameOne()
    {
        SceneManager.LoadScene("2Oyun");
    }
    public void OpenGameTwo()
    {
        SceneManager.LoadScene("2Oyun");
    }
    public void OpenGameThree()
    {
        SceneManager.LoadScene("3Oyun");
    }
    public void OpenGameFour()
    {
        SceneManager.LoadScene("4Oyun");
    }
    public void OpenGameFive()
    {
        SceneManager.LoadScene("5Oyun");
    }
    public void OpenGameSix()
    {
        SceneManager.LoadScene("6Oyun");
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("AnaMenu");
        Time.timeScale = 1;
        if (oyunAlti != null)
        {
            oyunAlti.oyunKaybedildi = false;
        }
    }
}
