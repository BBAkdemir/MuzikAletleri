using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceChanging : MonoBehaviour
{
    public Click clickControl;
    public AudioSource audioSource;
    OyunBir oyunBir;
    OyunIki oyunIki;
    OyunUc oyunUc;
    OyunDort oyunDort;
    OyunBes oyunBes;
    OyunAlti oyunAlti;
    public List<AudioClip> Sounds;

    public GameObject OyunBirObject;
    public GameObject OyunIkiObject;
    public GameObject OyunUcObject;
    public GameObject OyunDortObject;
    public GameObject OyunBesObject;
    public GameObject OyunAltiObject;

    bool basladi = false;
    string calanObje;
    // Start is called before the first frame update
    void Start()
    {
        clickControl = gameObject.GetComponent<Click>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (OyunBirObject != null)
            oyunBir = OyunBirObject.GetComponent<OyunBir>();
        if (OyunIkiObject != null)
            oyunIki = OyunIkiObject.GetComponent<OyunIki>();
        if (OyunUcObject != null)
            oyunUc = OyunUcObject.GetComponent<OyunUc>();
        if (OyunDortObject != null)
            oyunDort = OyunDortObject.GetComponent<OyunDort>();
        if (OyunBesObject != null)
            oyunBes = OyunBesObject.GetComponent<OyunBes>();
        if (OyunAltiObject != null)
            oyunAlti = OyunAltiObject.GetComponent<OyunAlti>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunBir != null)
        {
            if (oyunBir.DogruMuzikCal == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name.ToUpper() == oyunBir.ensturman + " SES")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunBir.DogruMuzikCal = false;
                        break;
                    }
                }
            }
            if (oyunBir.YanlisMuzikCal == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == "Yanlis")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunBir.YanlisMuzikCal = false;
                        break;
                    }
                }
            }
        }
        if (oyunIki != null && oyunIki.Control[0] != null && oyunIki.Control[1] != null && oyunIki.Control[0].Substring(6, oyunIki.Control[0].Length - 6) == oyunIki.Control[1].Substring(6, oyunIki.Control[1].Length - 6))
        {
            foreach (var item in Sounds)
            {
                if (calanObje != oyunIki.Control[0].Substring(6, oyunIki.Control[0].Length - 6))
                {
                    basladi = false;
                }
                if (item.name == oyunIki.Control[0].Substring(6, oyunIki.Control[0].Length - 6) + " Ses" && basladi == false)
                {
                    audioSource.clip = item;
                    audioSource.Play();
                    basladi = true;
                    calanObje = oyunIki.Control[0].Substring(6, oyunIki.Control[0].Length - 6);
                }
            }
        }
        if (oyunIki != null && oyunIki.yanlisEslestirme == true)
        {
            foreach (var item in Sounds)
            {
                if (item.name == "Yanlis")
                {
                    clickControl.SelectedObject = null;
                    audioSource.clip = item;
                    audioSource.Play();
                    oyunIki.yanlisEslestirme = false;
                    break;
                }
            }
        }
        if (oyunUc != null)
        {
            if (oyunUc.trueMi == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == oyunUc.Question + " Ses")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunUc.trueMi = false;
                        break;
                    }
                }
            }
            if (oyunUc.falseMi == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == "Yanlis")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunUc.falseMi = false;
                        break;
                    }
                }
            }
        }
        if (oyunDort != null)
        {
            if (oyunDort.yenidenDinle == true)
            {
                oyunDort.yenidenDinle = false;
                foreach (var item in Sounds)
                {
                    if (item.name == oyunDort.Question + " Ses")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        break;
                    }
                }
            }
            if (oyunDort.DogruMuzikCal == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == "Dogru")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunDort.DogruMuzikCal = false;
                        break;
                    }
                }
            }
            if (oyunDort.YanlisMuzikCal == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == "Yanlis")
                    {
                        clickControl.SelectedObject = null;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunDort.YanlisMuzikCal = false;
                        break;
                    }
                }
            }
        }
        if (oyunBes != null)
        {
            if (oyunBes.MuzikCal == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == oyunBes.CalacakMuzikAleti + " Ses")
                    {
                        Time.timeScale = 1;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunBes.MuzikCal = false;
                        break;
                    }
                }
            }
            if (oyunBes.YanlisMuzikCal == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == "Yanlis")
                    {
                        Time.timeScale = 1;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunBes.YanlisMuzikCal = false;
                        break;
                    }
                }
            }
        }
        if (oyunAlti != null)
        {
            if (oyunAlti.MuzikCalsin == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == oyunAlti.CalacakMuzikAleti + " Ses")
                    {
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunAlti.MuzikCalsin = false;
                        break;
                    }
                }
            }
            if (oyunAlti.YanlisMuziki == true)
            {
                foreach (var item in Sounds)
                {
                    if (item.name == "DusenAdamVeYanlisSes")
                    {
                        Time.timeScale = 1;
                        audioSource.clip = item;
                        audioSource.Play();
                        oyunAlti.YanlisMuziki = false;
                        break;
                    }
                }
            }
        }
    }
}
