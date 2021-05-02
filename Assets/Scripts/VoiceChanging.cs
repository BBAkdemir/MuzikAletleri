using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceChanging : MonoBehaviour
{
    public ClickControl clickControl;
    public AudioSource audioSource;
    OyunIki oyunIki;
    OyunUc oyunUc;
    OyunDort oyunDort;
    OyunBes oyunBes;
    public List<AudioClip> Sounds;

    public GameObject OyunIkiObject;
    public GameObject OyunUcObject;
    public GameObject OyunDortObject;
    public GameObject OyunBesObject;

    bool basladi = false;
    string calanObje;
    // Start is called before the first frame update
    void Start()
    {
        clickControl = gameObject.GetComponent<ClickControl>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (OyunIkiObject != null)
            oyunIki = OyunIkiObject.GetComponent<OyunIki>();
        if (OyunUcObject != null)
            oyunUc = OyunUcObject.GetComponent<OyunUc>();
        if (OyunDortObject != null)
            oyunDort = OyunDortObject.GetComponent<OyunDort>();
        if (OyunBesObject != null)
            oyunBes = OyunBesObject.GetComponent<OyunBes>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (oyunUc != null && oyunUc.trueMi == true)
        {
            foreach (var item in Sounds)
            {
                if (item.name == oyunUc.Question + " Ses"/*clickControl.SelectedObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text + " Ses"*/)
                {
                    clickControl.SelectedObject = null;
                    audioSource.clip = item;
                    audioSource.Play();
                    oyunUc.trueMi = false;
                    break;
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
        }
    }
}
