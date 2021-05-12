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
    public GameObject SonrakineGecButton;

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
    OyunBir oyunBir;

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
        if (OyunBir != null)
        {
            oyunBir = OyunBir.GetComponent<OyunBir>();
        }
    }
    void Update()
    {
        if (OyunAlti != null)
        {
            if (oyunAlti.oyunKazanildi == true)
            {
                Time.timeScale = 0;
                WinMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunAlti.oyunKaybedildi == true)
            {
                Time.timeScale = 0;
                LostMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunAlti.sonrakineGecButton == true)
            {
                SonrakineGecButton.SetActive(true);
                gameStop = true;
            }
        }
        if (OyunBes != null && oyunBes.oyunKazanildi == true)
        {
            Time.timeScale = 0;
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunDort != null)
        {
            if (oyunDort.oyunKazanildi == true)
            {
                Time.timeScale = 0;
                WinMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunDort.oyunKaybedildi == true)
            {
                Time.timeScale = 0;
                LostMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunDort.sonrakineGecButton == true && oyunDort.oyunKazanildi == false && oyunDort.oyunKaybedildi == false)
            {
                SonrakineGecButton.SetActive(true);
                gameStop = true;
            }
        }
        if (OyunUc != null)
        {
            if (oyunUc.oyunKazanildi == true)
            {
                Time.timeScale = 0;
                WinMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunUc.oyunKaybedildi == true)
            {
                Time.timeScale = 0;
                LostMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunUc.sonrakineGecButton == true && oyunUc.oyunKazanildi == false && oyunUc.oyunKaybedildi == false)
            {
                SonrakineGecButton.SetActive(true);
                gameStop = true;
            }
        }
        if (OyunIki != null && oyunIki.oyunKazanildi == true)
        {
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunBir != null && oyunBir.oyunKazanildi == true)
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
    public  void SonrakineGec()
    {
        Time.timeScale = 1;
        gameStop = false;
        SonrakineGecButton.SetActive(false);
        if (OyunAlti != null)
        {
            oyunAlti.sonrakineGecButton = false;
        }
        if (oyunUc != null)
        {
            oyunUc.sonrakineGecButton = false;
        }
        if (oyunDort != null)
        {
            oyunDort.sonrakineGecButton = false;
        }
    }
    public void OpenGameOne()
    {
        SceneManager.LoadScene("1Oyun");
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
