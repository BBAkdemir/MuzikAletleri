using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menus : MonoBehaviour
{
    public GameObject ESCMenu;
    public GameObject LostMenu;
    public GameObject WinMenu;
    public GameObject ScoreSaveMenuWin;
    public GameObject ScoreSaveMenuLost;
    public GameObject ScoreSaveMenuStopped;
    public GameObject stopButton;
    public GameObject SonrakineGecButton;
    public GameObject UyariYazisi;
    public GameObject exitButton;

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

    public bool uyariYazisiAc = false;
    float a;

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
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            exitButton.SetActive(false);
        }
    }
    void Update()
    {
        if (UyariYazisi != null && uyariYazisiAc == true)
        {
            UyariYazisi.SetActive(true);
        }
        if (UyariYazisi != null && UyariYazisi.activeSelf == true)
        {
            a += Time.deltaTime;
            if (a >= 3)
            {
                uyariYazisiAc = false;
                a = 0;
                UyariYazisi.SetActive(false);
            }
        }
        if (OyunAlti != null)
        {
            if (oyunAlti.oyunKazanildi == true && ScoreSaveMenuWin.activeSelf == false)
            {
                WinMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunAlti.oyunKaybedildi == true && ScoreSaveMenuLost.activeSelf == false)
            {
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
        if (OyunBes != null && oyunBes.oyunKazanildi == true && ScoreSaveMenuWin.activeSelf == false)
        {
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunDort != null)
        {
            if (oyunDort.oyunKazanildi == true && ScoreSaveMenuWin.activeSelf == false)
            {
                WinMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunDort.oyunKaybedildi == true && ScoreSaveMenuLost.activeSelf == false)
            {
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
            if (oyunUc.oyunKazanildi == true && ScoreSaveMenuWin.activeSelf == false)
            {
                WinMenu.SetActive(true);
                stopButton.SetActive(false);
                gameStop = true;
            }
            if (oyunUc.oyunKaybedildi == true && ScoreSaveMenuLost.activeSelf == false)
            {
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
        if (OyunIki != null && oyunIki.oyunKazanildi == true && ScoreSaveMenuWin.activeSelf == false)
        {
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
        if (OyunBir != null && oyunBir.oyunKazanildi == true && ScoreSaveMenuWin.activeSelf == false)
        {
            WinMenu.SetActive(true);
            stopButton.SetActive(false);
            gameStop = true;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StopGame()
    {
        ESCMenu.SetActive(true);
        stopButton.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveWin()
    {
        ScoreSaveMenuWin.SetActive(true);
        WinMenu.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveWinExit()
    {
        WinMenu.SetActive(true);
        WinMenu.transform.GetChild(2).GetComponent<Button>().interactable = false;
        ScoreSaveMenuWin.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveWinMenuExit()
    {
        WinMenu.SetActive(true);
        ScoreSaveMenuWin.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveLost()
    {
        ScoreSaveMenuLost.SetActive(true);
        LostMenu.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveLostExit()
    {
        LostMenu.SetActive(true);
        LostMenu.transform.GetChild(2).GetComponent<Button>().interactable = false;
        ScoreSaveMenuLost.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveLostMenuExit()
    {
        LostMenu.SetActive(true);
        ScoreSaveMenuLost.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveStopped()
    {
        ScoreSaveMenuStopped.SetActive(true);
        ESCMenu.SetActive(false);
        gameStop = true;
    }
    public void GameScoreSaveStoppedExit()
    {
        ESCMenu.SetActive(true);
        ScoreSaveMenuStopped.SetActive(false);
        SceneManager.LoadScene("AnaMenu");
        if (oyunAlti != null)
        {
            oyunAlti.oyunKaybedildi = false;
        }
        gameStop = true;
    }
    public void GameScoreSaveStoppedMenuExit()
    {
        ESCMenu.SetActive(true);
        ScoreSaveMenuStopped.SetActive(false);
        gameStop = true;
    }
    public void ResumeGame()
    {
        gameStop = false;
        ESCMenu.SetActive(false);
        stopButton.SetActive(true);
    }
    public void SonrakineGecGameSix()
    {
        gameStop = false;
        SonrakineGecButton.SetActive(false);
        if (OyunAlti != null)
        {
            oyunAlti.sonrakineGecButton = false;
        }
    }
    public void SonrakineGec()
    {
        gameStop = false;
        SonrakineGecButton.SetActive(false);
        if (oyunUc != null)
        {
            foreach (var item in oyunUc.options)
            {
                item.Card.transform.GetChild(3).gameObject.SetActive(false);
                item.Card.transform.GetChild(4).gameObject.SetActive(false);
            }
            oyunUc.sonrakineGecButton = false;
        }
        if (oyunDort != null)
        {
            foreach (var item in oyunDort.options)
            {
                item.Card.transform.GetChild(2).gameObject.SetActive(false);
                item.Card.transform.GetChild(3).gameObject.SetActive(false);
            }
            oyunDort.sonrakineGecButton = false;
        }
    }
    public void OyunBirZorlukSecildi()
    {
        TMP_Text ZorlukDD = gameObject.GetComponent<DifficultySelect>().clickedButton.transform.GetChild(1).GetComponent<TMP_Text>();
        int ZorlukDegeri = Convert.ToInt32(ZorlukDD.text);
        PlayerPrefs.SetInt("OyunBirZorluk", ZorlukDegeri);
    }
    public void OyunIkiZorlukSecildi()
    {
        //Text ZorlukDD = GameObject.FindWithTag("ZorlukDD").GetComponent<Text>();
        TMP_Text ZorlukDD = gameObject.GetComponent<DifficultySelect>().clickedButton.transform.GetChild(1).GetComponent<TMP_Text>();
        string ZorlukDegeri = ZorlukDD.text;
        PlayerPrefs.SetString("OyunIkiZorluk", ZorlukDegeri);
    }
    public void OyunUcZorlukSecildi()
    {
        //Text ZorlukDD = GameObject.FindWithTag("ZorlukDD").GetComponent<Text>();
        TMP_Text ZorlukDD = gameObject.GetComponent<DifficultySelect>().clickedButton.transform.GetChild(1).GetComponent<TMP_Text>();
        string ZorlukDegeri = ZorlukDD.text;
        PlayerPrefs.SetString("OyunUcZorluk", ZorlukDegeri);
    }
    public void OyunDortZorlukSecildi()
    {
        //Text ZorlukDD = GameObject.FindWithTag("ZorlukDD").GetComponent<Text>();
        TMP_Text ZorlukDD = gameObject.GetComponent<DifficultySelect>().clickedButton.transform.GetChild(1).GetComponent<TMP_Text>();
        string ZorlukDegeri = ZorlukDD.text;
        PlayerPrefs.SetString("OyunDortZorluk", ZorlukDegeri);
    }
    public void OyunBesZorlukSecildi()
    {
        //Text ZorlukDD = GameObject.FindWithTag("ZorlukDD").GetComponent<Text>();
        TMP_Text ZorlukDD = gameObject.GetComponent<DifficultySelect>().clickedButton.transform.GetChild(1).GetComponent<TMP_Text>();
        string ZorlukDegeri = ZorlukDD.text;
        PlayerPrefs.SetString("OyunBesZorluk", ZorlukDegeri);
    }
    public void OyunAltiZorlukSecildi()
    {
        //Text ZorlukDD = GameObject.FindWithTag("ZorlukDD").GetComponent<Text>();
        TMP_Text ZorlukDD = gameObject.GetComponent<DifficultySelect>().clickedButton.transform.GetChild(1).GetComponent<TMP_Text>();
        int ZorlukDegeri = Convert.ToInt32(ZorlukDD.text);
        PlayerPrefs.SetInt("OyunAltiZorluk", ZorlukDegeri);
    }
    public void OpenGameOneSettings()
    {
        SceneManager.LoadScene("1OyunGirisEkrani");
        PlayerPrefs.SetInt("Oyun", 1);
    }
    public void OpenScoreTable()
    {
        SceneManager.LoadScene("SkorTablosu");
    }
    public void OpenGameOne()
    {
        SceneManager.LoadScene("1Oyun");
    }
    public void OpenGameTwoSettings()
    {
        SceneManager.LoadScene("2OyunGirisEkrani");
        PlayerPrefs.SetInt("Oyun", 2);
    }
    public void OpenGameTwo()
    {
        SceneManager.LoadScene("2Oyun");
    }
    public void OpenGameThreeSettings()
    {
        SceneManager.LoadScene("3OyunGirisEkrani");
        PlayerPrefs.SetInt("Oyun", 3);
    }
    public void OpenGameThree()
    {
        SceneManager.LoadScene("3Oyun");
    }
    public void OpenGameFourSettings()
    {
        SceneManager.LoadScene("4OyunGirisEkrani");
        PlayerPrefs.SetInt("Oyun", 4);
    }
    public void OpenGameFour()
    {
        SceneManager.LoadScene("4Oyun");
    }
    public void OpenGameFiveSettings()
    {
        SceneManager.LoadScene("5OyunGirisEkrani");
        PlayerPrefs.SetInt("Oyun", 5);
    }
    public void OpenGameFive()
    {
        SceneManager.LoadScene("5Oyun");
    }
    public void OpenGameSixSettings()
    {
        SceneManager.LoadScene("6OyunGirisEkrani");
        PlayerPrefs.SetInt("Oyun", 6);
    }
    public void OpenGameSix()
    {
        SceneManager.LoadScene("6Oyun");
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("AnaMenu");
        if (oyunAlti != null)
        {
            oyunAlti.oyunKaybedildi = false;
        }
    }
    public void ExiteGame()
    {
        Application.Quit();
    }
}
