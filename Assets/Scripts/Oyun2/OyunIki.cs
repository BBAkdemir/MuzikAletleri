using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OyunIki : MonoBehaviour
{
    public bool OyunIkiActive = false;
    public GameObject Card;
    public GameObject TrueObject;

    Datalar datalar;
    public Click clickControl;
    public GameObject clickObject;

    public Difficulty Difficulty;
    public List<string> musicalInstruments;
    public List<Sprite> Images;
    public List<string> selectedMusicalInstruments;
    public List<string> foundBeforeMusicalInstruments1;
    public List<string> foundBeforeMusicalInstruments2;
    public string[,] Cards;

    bool donecek1 = false;
    bool donecek2 = false;
    bool eskiyeDon = false;
    bool birinciyiAl = false;
    public bool oyunKazanildi = false;

    //int oyunKazanildi = 0;
    public int kacDogruOldu;
    int kacDogruOlmali;

    GameObject donecekObje1;
    GameObject yedekDonecekObje1;
    GameObject yedekDonecekObje2;
    GameObject donecekObje2;

    public List<Transform> transforms;
    public List<Bilgiler> bilgiler;

    public List<string> theRight;
    bool tasinacak = false;

    public GameObject canvas;
    public GameObject name;
    public GameObject aciklama;
    public GameObject turu;
    public GameObject geri;
    public bool acildiMi = false;
    public bool yanlisEslestirme = false;

    public string[] Control;

    #region zaman Deðiþkenleri
    public GameObject DuraklatMenu;
    public GameObject TimeObjectSoruBasinaZaman;
    public GameObject ScoreObject;
    Text SoruBasinaZamanObject;
    Text ScoreObjectText;
    int Scores = 0;
    float SoruBasinaZaman = 0;
    int SoruBasinaZamanYedek = 0;
    int KartBasinaPuan = 100;
    int SaniyeBasinaPuan = 1;
    bool ZamaniSifirla = false;
    #endregion
    void Start()
    {
        if (PlayerPrefs.GetString("OyunIkiZorluk") == "Kolay")
        {
            Difficulty = Difficulty.Easy;
        }
        if (PlayerPrefs.GetString("OyunIkiZorluk") == "Orta")
        {
            Difficulty = Difficulty.Normal;
        }
        if (PlayerPrefs.GetString("OyunIkiZorluk") == "Zor")
        {
            Difficulty = Difficulty.Hard;
        }
        SoruBasinaZamanObject = TimeObjectSoruBasinaZaman.GetComponent<Text>();
        ScoreObjectText = ScoreObject.GetComponent<Text>();
        OyunIkiActive = true;
        bilgiler = new List<Bilgiler>();
        Control = new string[2];
        musicalInstruments = new List<string>();
        musicalInstruments.Add("Balaban");
        musicalInstruments.Add("Baðlama");
        musicalInstruments.Add("Kemençe");
        musicalInstruments.Add("Ney");
        musicalInstruments.Add("Tar");
        musicalInstruments.Add("Ud");
        musicalInstruments.Add("Elektro Gitar");
        musicalInstruments.Add("Gitar");
        musicalInstruments.Add("Cümbüþ");
        musicalInstruments.Add("Mandolin");
        musicalInstruments.Add("Arp");
        musicalInstruments.Add("Keman");
        musicalInstruments.Add("Piyano");
        musicalInstruments.Add("Akordeon");
        musicalInstruments.Add("Ukulele");
        musicalInstruments.Add("Dombra");
        musicalInstruments.Add("Bendir");
        musicalInstruments.Add("Darbuka");
        musicalInstruments.Add("Def");
        musicalInstruments.Add("Kanun");
        musicalInstruments.Add("Kaval");
        musicalInstruments.Add("Kopuz");
        musicalInstruments.Add("Tambur");
        musicalInstruments.Add("Tulum");
        musicalInstruments.Add("Zurna");
        musicalInstruments.Add("Davul");
        musicalInstruments.Add("Bateri");
        musicalInstruments.Add("Zil");
        musicalInstruments.Add("Klarnet");
        musicalInstruments.Add("Saksofon");
        musicalInstruments.Add("Armonika");
        musicalInstruments.Add("Flüt");
        musicalInstruments.Add("Melodika");
        musicalInstruments.Add("Viyola");
        musicalInstruments.Add("Kontrbas");
        musicalInstruments.Add("Viyolonsel");
        musicalInstruments.Add("Obua");
        musicalInstruments.Add("Trompet");
        musicalInstruments.Add("Trombon");
        musicalInstruments.Add("Korno");
        musicalInstruments.Add("Bandoneon");

        transforms = new List<Transform>();
        if (Difficulty == Difficulty.Easy)
        {
            CardMakerMethod(6, 4, 3);
            CikanlarPositionBelirleme(6, 2, 3, 5);
        }
        if (Difficulty == Difficulty.Normal)
        {
            CardMakerMethod(10, 5, 4);
            CikanlarPositionBelirleme(6, 2, 5, 6);
        }
        if (Difficulty == Difficulty.Hard)
        {
            CardMakerMethod(15, 6, 5);
            CikanlarPositionBelirleme(6, 3, 5, 7);
        }
    }

    public void CikanlarPositionBelirleme(int howManyInstruments, int arrayX, int arrayZ, int BaslangicX)
    {
        var a = 0;
        for (int i = 0; i < arrayX; i++)
        {
            for (int j = 0; j < arrayZ; j++)
            {
                a++;
                Vector3 position = new Vector3(((BaslangicX + i) * 2), 0, (j * 3));
                var newCard = Instantiate(TrueObject, position, new Quaternion(0, 0, 0, 0));
                newCard.name = "True" + a;
                transforms.Add(newCard.transform);
            }
        }
    }
    public void CardMakerMethod(int howManyInstruments, int arrayX, int arrayZ)
    {
        kacDogruOlmali = howManyInstruments;
        var Instrument = "";

        selectedMusicalInstruments = new List<string>();
        theRight = new List<string>();
        do
        {
            var kelimeBul = new System.Random().Next(musicalInstruments.Count());
            Instrument = musicalInstruments[kelimeBul];
            if (!selectedMusicalInstruments.Any(a => a == Instrument))
            {
                selectedMusicalInstruments.Add(Instrument);
            }
        } while (selectedMusicalInstruments.Count < howManyInstruments);

        int a = selectedMusicalInstruments.Count;

        for (int i = 0; i < a; i++)
        {
            selectedMusicalInstruments.Add(selectedMusicalInstruments[i]);
        }

        foundBeforeMusicalInstruments1 = new List<string>();
        foundBeforeMusicalInstruments2 = new List<string>();
        Cards = new string[arrayX, arrayZ];
        for (int i = 0; i < arrayX; i++)
        {
            for (int j = 0; j < arrayZ; j++)
            {
                if (selectedMusicalInstruments.Count != 0)
                {
                    var kelimeBul = new System.Random().Next(selectedMusicalInstruments.Count());
                    Instrument = selectedMusicalInstruments[kelimeBul];
                    selectedMusicalInstruments.RemoveAt(kelimeBul);
                }
                Cards[i, j] = Instrument;

                Vector3 position = new Vector3(i * 2.0f, 0, j * 3.0f);
                var newCard = Instantiate(Card, position, Card.transform.rotation);
                newCard.name = "Card" + i + j + Instrument;
                foreach (var item in Images)
                {
                    if (item.name == Instrument)
                    {
                        newCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item;
                    }
                }
                newCard.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Instrument;
            }
        }


    }
    void Update()
    {
        if (DuraklatMenu.activeSelf == false && oyunKazanildi == false && ZamaniSifirla == false)
        {
            SoruBasinaZaman += Time.deltaTime;
            SoruBasinaZamanObject.text = "" + (int)SoruBasinaZaman;
        }
        if (ZamaniSifirla == true)
        {
            Scores += KartBasinaPuan - ((int)SoruBasinaZaman * SaniyeBasinaPuan);
            SoruBasinaZaman = SoruBasinaZamanYedek;
            ZamaniSifirla = false;
            ScoreObjectText.text = "" + Scores;
        }
        if (oyunKazanildi == true)
        {
            if (Scores <= 0)
            {
                Scores = 0;
            }
            PlayerPrefs.SetInt("Puan", Scores);
        }

        if (clickObject.GetComponent<Click>() != null)
        {
            clickControl = clickObject.GetComponent<Click>();
        }

        if (clickControl.SelectedObject != null && clickControl.SelectedObject.name.Contains("Bilgi"))
        {
            var name1 = name.GetComponent<Text>();
            var turu1 = turu.GetComponent<Text>();
            var aciklama1 = aciklama.GetComponent<Text>();

            foreach (var item in bilgiler)
            {
                if (item.Name == clickControl.SelectedObject.name.Substring(5, clickControl.SelectedObject.name.Length - 5).ToUpper())
                {
                    name1.text = item.Name;
                    turu1.text = "Türü: " + item.Turu;
                    aciklama1.text = item.Aciklama;
                    canvas.SetActive(true);
                }
            }
        }

        if (kacDogruOldu < kacDogruOlmali)
        {
            if (clickControl.SelectedObject != null && clickControl.SelectedObject.name.Contains("Card") && Control[0] == null && Control[1] == null && Control[0] != clickControl.SelectedObject.name && eskiyeDon == false && tasinacak != true)
            {
                Control[0] = clickControl.SelectedObject.name;
                donecek1 = true;
                donecekObje1 = clickControl.SelectedObject;
            }

            if (clickControl.SelectedObject != null && clickControl.SelectedObject.name.Contains("Card") && Control[0] != null && Control[1] == null && Control[0] != clickControl.SelectedObject.name && eskiyeDon == false && tasinacak != true)
            {
                Control[1] = clickControl.SelectedObject.name;
                donecek2 = true;
                donecekObje2 = clickControl.SelectedObject;
            }

            if (eskiyeDon == true)
            {
                donecekObje1.transform.rotation = Quaternion.Lerp(donecekObje1.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 12f);
                donecekObje2.transform.rotation = Quaternion.Lerp(donecekObje2.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 12f);

                if (donecekObje1.transform.rotation.z < Quaternion.Euler(-130, -90, 0).z || donecekObje2.transform.rotation.z < Quaternion.Euler(-130, -90, 0).z)
                {
                    donecekObje1.transform.position = Vector3.MoveTowards(donecekObje1.transform.position, new Vector3(donecekObje1.transform.position.x, 1, donecekObje1.transform.position.z), Time.deltaTime * 14f);
                    donecekObje2.transform.position = Vector3.MoveTowards(donecekObje2.transform.position, new Vector3(donecekObje2.transform.position.x, 1, donecekObje2.transform.position.z), Time.deltaTime * 14f);
                }
                else
                {
                    donecekObje1.transform.position = Vector3.MoveTowards(donecekObje1.transform.position, new Vector3(donecekObje1.transform.position.x, 0, donecekObje1.transform.position.z), Time.deltaTime * 2f);
                    donecekObje2.transform.position = Vector3.MoveTowards(donecekObje2.transform.position, new Vector3(donecekObje2.transform.position.x, 0, donecekObje2.transform.position.z), Time.deltaTime * 2f);
                }
                if ((donecekObje1.transform.rotation == Quaternion.Euler(0, -90, 0) && donecekObje1.transform.position == new Vector3(donecekObje1.transform.position.x, 0, donecekObje1.transform.position.z)) && (donecekObje2.transform.rotation == Quaternion.Euler(0, -90, 0) && donecekObje2.transform.position == new Vector3(donecekObje2.transform.position.x, 0, donecekObje2.transform.position.z)))
                {
                    eskiyeDon = false;
                    Control[0] = null;
                    Control[1] = null;
                }
            }

            if (donecek1 == true && eskiyeDon == false && yedekDonecekObje1 == null)
            {
                donecekObje1.transform.rotation = Quaternion.Lerp(donecekObje1.transform.rotation, Quaternion.Euler(180, -90, 0), Time.deltaTime * 5f);
                if (donecekObje1.transform.rotation.z > Quaternion.Euler(-130, -90, 0).z)
                {
                    donecekObje1.transform.position = Vector3.MoveTowards(donecekObje1.transform.position, new Vector3(donecekObje1.transform.position.x, 1, donecekObje1.transform.position.z), Time.deltaTime * 14f);
                }
                else
                {
                    donecekObje1.transform.position = Vector3.MoveTowards(donecekObje1.transform.position, new Vector3(donecekObje1.transform.position.x, 0, donecekObje1.transform.position.z), Time.deltaTime * 2f);
                }
                if (donecekObje1.transform.rotation == Quaternion.Euler(-180, -90, 0) && donecekObje1.transform.position == new Vector3(donecekObje1.transform.position.x, 0, donecekObje1.transform.position.z))
                {
                    donecek1 = false;
                }
            }

            if (donecek2 == true && eskiyeDon == false)
            {
                donecekObje2.transform.rotation = Quaternion.Lerp(donecekObje2.transform.rotation, Quaternion.Euler(180, -90, 0), Time.deltaTime * 5f);
                if (donecekObje2.transform.rotation.z > Quaternion.Euler(-130, -90, 0).z)
                {
                    donecekObje2.transform.position = Vector3.MoveTowards(donecekObje2.transform.position, new Vector3(donecekObje2.transform.position.x, 1, donecekObje2.transform.position.z), Time.deltaTime * 14f);
                }
                else
                {
                    donecekObje2.transform.position = Vector3.MoveTowards(donecekObje2.transform.position, new Vector3(donecekObje2.transform.position.x, 0, donecekObje2.transform.position.z), Time.deltaTime * 2f);
                }
                if (donecekObje2.transform.rotation == Quaternion.Euler(-180, -90, 0) && donecekObje2.transform.position == new Vector3(donecekObje2.transform.position.x, 0, donecekObje2.transform.position.z))
                {
                    donecek2 = false;
                    if (Control[0].Substring(6, Control[0].Length - 6) == Control[1].Substring(6, Control[1].Length - 6))
                    {
                        tasinacak = true;
                        theRight.Add(Control[0]);
                    }
                    else
                    {
                        yanlisEslestirme = true;
                        eskiyeDon = true;
                    }
                }
            }

            if (tasinacak == true && donecek2 == false && Control[0] != null && Control[1] != null)
            {
                for (int i = 0; i < theRight.Count; i++)
                {
                    if (theRight[i] == Control[0])
                    {
                        if (donecekObje1.transform.position != transforms[i].position || (donecekObje2 != null && donecekObje2.transform.position != transforms[i].position))
                        {
                            if (donecekObje1.transform.position.x <= (transforms[i].position.x - donecekObje1.transform.position.x) / 2 || donecekObje2.transform.position.x <= (transforms[i].position.x - donecekObje2.transform.position.x) / 2)
                            {
                                donecekObje1.transform.position = Vector3.MoveTowards(donecekObje1.transform.position, new Vector3(transforms[i].position.x, 4, transforms[i].position.z), Time.deltaTime * 15f);
                                donecekObje2.transform.position = Vector3.MoveTowards(donecekObje2.transform.position, new Vector3(transforms[i].position.x, 4, transforms[i].position.z), Time.deltaTime * 15f);
                            }
                            else
                            {
                                donecekObje1.transform.position = Vector3.MoveTowards(donecekObje1.transform.position, new Vector3(transforms[i].position.x, 0, transforms[i].position.z), Time.deltaTime * 15f);
                                donecekObje2.transform.position = Vector3.MoveTowards(donecekObje2.transform.position, new Vector3(transforms[i].position.x, 0, transforms[i].position.z), Time.deltaTime * 15f);
                            }
                        }
                        else
                        {
                            ZamaniSifirla = true;
                            Destroy(donecekObje2);
                            donecekObje1.name = "Bilgi" + Control[0].Substring(6, Control[0].Length - 6);

                            datalar = gameObject.GetComponent<Datalar>();
                            foreach (var item in datalar.explanations)
                            {
                                if (item.Name == donecekObje1.name.Substring(5, donecekObje1.name.Length - 5).ToUpper())
                                {
                                    var bilgis = new Bilgiler()
                                    {
                                        Id = item.Id,
                                        Name = item.Name,
                                        Turu = item.Turu,
                                        Aciklama = item.Aciklama
                                    };
                                    bilgiler.Add(bilgis);
                                }
                            }
                            Control[0] = null;
                            Control[1] = null;
                            kacDogruOldu++;
                            tasinacak = false;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            oyunKazanildi = true;
        }
    }
    public void GeriButton()
    {
        if (clickObject.GetComponent<Click>() != null)
        {
            clickControl.SelectedObject = null;
        }
        canvas.SetActive(false);
    }
}
