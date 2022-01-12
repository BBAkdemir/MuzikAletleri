using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OyunUc : MonoBehaviour
{
    public Click clickControl;
    public GameObject clickObject;

    public List<string> musicalInstruments;
    public List<Sprite> Images;
    public List<string> selectedMusicalInstruments;
    public List<string> Cikanlar;
    public List<OptionCards> options;
    public QuestionCard question;

    public int yanlisBilmeHakki;

    public int cevaplananSoruSayisi = 1;
    public int cevaplananDogruSoruSayisi;
    public int cevaplananYanlisSoruSayisi;
    public int controlSoruSayisi;
    public int trueOption;

    public GameObject soruCard;
    public GameObject soruCardImage;
    public GameObject SecenekCard;
    public GameObject YanlisSayisiCanvas;

    public Difficulty difficulty;

    public string Instrument = "";
    public string Question = "";
    int sayi = 0;

    bool yanlis = false;
    public bool trueMi = false;
    public bool falseMi = false;
    public bool birdahakiSoruyaGec = true;

    public bool oyunKaybedildi = false;
    public bool oyunKazanildi = false;
    public bool sonrakineGecButton = false;

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
    int SaniyeBasinaPuan = 10;
    bool ZamaniSifirla = false;
    bool zamaniDurdur = false;
    #endregion
    void Start()
    {
        if (PlayerPrefs.GetString("OyunUcZorluk") == "Kolay")
        {
            difficulty = Difficulty.Easy;
        }
        if (PlayerPrefs.GetString("OyunUcZorluk") == "Orta")
        {
            difficulty = Difficulty.Normal;
        }
        if (PlayerPrefs.GetString("OyunUcZorluk") == "Zor")
        {
            difficulty = Difficulty.Hard;
        }
        SoruBasinaZamanObject = TimeObjectSoruBasinaZaman.GetComponent<Text>();
        ScoreObjectText = ScoreObject.GetComponent<Text>();
        musicalInstruments = new List<string>();
        options = new List<OptionCards>();
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

        if (difficulty == Difficulty.Easy)
        {
            CardMaker(3);
        }
        if (difficulty == Difficulty.Normal)
        {
            CardMaker(4);
        }
        if (difficulty == Difficulty.Hard)
        {
            CardMaker(5);
        }
    }
    public string InsturmentSelect()
    {
        var b = false;
        do
        {
            var kelimeBul = new System.Random().Next(musicalInstruments.Count());
            Instrument = musicalInstruments[kelimeBul];
            if (selectedMusicalInstruments.Any(a => a == Instrument))
            {
                b = false;

            }
            else
            {
                b = true;
            }
        } while (b == false);
        if (b == true)
        {
            selectedMusicalInstruments.Add(Instrument);
        }
        return Instrument;
    }
    public void CardQuestion()
    {
        var b = false;
        do
        {
            var question = new System.Random().Next(musicalInstruments.Count());
            Question = musicalInstruments[question];
            if (Cikanlar.Any(a => a == Question))
            {
                b = false;
            }
            else
            {
                b = true;
            }
        } while (b == false);
        if (b == true)
        {
            Cikanlar.Add(Question);
        }
        var questionCard = new QuestionCard()
        {
            Card = soruCard,
            Instrument = Question
        };
        question = questionCard;

        foreach (var image in Images)
        {
            if (image.name == Question)
            {
                soruCardImage.GetComponent<Image>().sprite = image;
            }
        }
    }
    public void CardMaker(int HowManyOption)
    {
        var a = 0;
        #region kolaysa(3 þýk)
        if (HowManyOption == 3)
        {
            for (int i = -1; i < HowManyOption - 1; i++)
            {
                Vector3 position = new Vector3((i * 2.25f), 0, -3);
                var newCard = Instantiate(SecenekCard, position, SecenekCard.transform.rotation);
                newCard.name = "SecenekCard" + a + Instrument;

                var optionCards = new OptionCards()
                {
                    Id = a,
                    Card = newCard
                };
                options.Add(optionCards);
                a++;
            }
        }
        #endregion
        #region normalse(4 þýk)
        if (HowManyOption == 4)
        {
            for (int i = -1; i < 1; i++)
            {
                Vector3 position = new Vector3(((i * 2.25f) - 1.125f), 0, -3);
                var newCard = Instantiate(SecenekCard, position, SecenekCard.transform.rotation);
                newCard.name = "SecenekCard" + a + Instrument;
                var optionCards = new OptionCards()
                {
                    Id = a,
                    Card = newCard
                };
                options.Add(optionCards);
                a++;
            }
            for (int i = 0; i < 2; i++)
            {
                Vector3 position = new Vector3(((i * 2.25f) + 1.125f), 0, -3);
                var newCard = Instantiate(SecenekCard, position, SecenekCard.transform.rotation);
                newCard.name = "SecenekCard" + a + Instrument;
                var optionCards = new OptionCards()
                {
                    Id = a,
                    Card = newCard
                };
                options.Add(optionCards);
                a++;
            }
        }
        #endregion
        #region zorsa(5 þýk)
        if (HowManyOption == 5)
        {
            for (int i = -2; i < HowManyOption - 2; i++)
            {
                Vector3 position = new Vector3((i * 2.25f), 0, -3);
                var newCard = Instantiate(SecenekCard, position, SecenekCard.transform.rotation);
                newCard.name = "SecenekCard" + a + Instrument;
                var optionCards = new OptionCards()
                {
                    Id = a,
                    Card = newCard
                };
                options.Add(optionCards);
                a++;
            }
        }
        #endregion
        a = 0;
    }
    void Update()
    {
        if (DuraklatMenu.activeSelf == false && oyunKazanildi == false && ZamaniSifirla == false && zamaniDurdur == false)
        {
            SoruBasinaZaman += Time.deltaTime;
            SoruBasinaZamanObject.text = "" + (int)SoruBasinaZaman;
        }
        if (ZamaniSifirla == true && yanlis == false)
        {
            Scores += KartBasinaPuan - ((int)SoruBasinaZaman * SaniyeBasinaPuan);
            SoruBasinaZaman = SoruBasinaZamanYedek;
            ZamaniSifirla = false;
            ScoreObjectText.text = "" + Scores;
            PlayerPrefs.SetInt("Puan", Scores);
        }
        if (ZamaniSifirla == true && yanlis == true)
        {
            Scores -= KartBasinaPuan - ((int)SoruBasinaZaman * SaniyeBasinaPuan);
            SoruBasinaZaman = SoruBasinaZamanYedek;
            ZamaniSifirla = false;
            yanlis = false;
            ScoreObjectText.text = "" + Scores;
            PlayerPrefs.SetInt("Puan", Scores);
        }
        if (oyunKazanildi == true)
        {
            if (Scores <= 0)
            {
                Scores = 0;
            }
            PlayerPrefs.SetInt("Puan", Scores);
        }

        if (cevaplananYanlisSoruSayisi < yanlisBilmeHakki)
        {
            if (sonrakineGecButton == false)
            {
                ZamaniSifirla = false;
                zamaniDurdur = false;
                if (cevaplananSoruSayisi < 41 && sayi < options.Count() - 1)
                {
                    CardQuestion();
                    selectedMusicalInstruments = new List<string>();
                    trueOption = new System.Random().Next(options.Count());
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (i == trueOption)
                        {
                            options[i].Instrument = Question;
                            selectedMusicalInstruments.Add(Question);
                            sayi++;
                        }
                    }

                    foreach (var item in options)
                    {
                        if (item.Id != trueOption)
                        {
                            item.Instrument = InsturmentSelect();
                            sayi++;
                        }
                    }

                    for (int i = 0; i < options.Count; i++)
                    {
                        GameObject.Find("SecenekCard" + i).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = options[i].Instrument;
                    }
                }

                if (clickObject.GetComponent<Click>() != null)
                {
                    clickControl = clickObject.GetComponent<Click>();
                }
                yanlis = false;
                if (clickControl.SelectedObject != null && clickControl.SelectedObject.name.Contains("Secenek"))
                {
                    foreach (var item in options)
                    {
                        if (clickControl.SelectedObject != null && clickControl.SelectedObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == soruCardImage.GetComponent<Image>().sprite.name /*item.Id == Convert.ToInt32(clickControl.SelectedObject.name.Substring(11, 1)) && item.Id == trueOption*/)
                        {
                            foreach (var item1 in options)
                            {
                                if (item1.Card.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text != soruCardImage.GetComponent<Image>().sprite.name)
                                {
                                    item1.Card.transform.GetChild(3).gameObject.SetActive(true);
                                }
                                if (item1.Card.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == soruCardImage.GetComponent<Image>().sprite.name)
                                {
                                    item1.Card.transform.GetChild(4).gameObject.SetActive(true);
                                }
                            }
                            sayi = 0;
                            cevaplananDogruSoruSayisi++;
                            yanlis = false;
                            trueMi = true;
                            ZamaniSifirla = true;
                            sonrakineGecButton = true;
                            clickControl.SelectedObject = null;
                            break;
                        }
                        else
                        {
                            yanlis = true;
                        }
                    }
                    if (yanlis == true)
                    {
                        foreach (var item1 in options)
                        {
                            if (item1.Card.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text != soruCardImage.GetComponent<Image>().sprite.name)
                            {
                                item1.Card.transform.GetChild(3).gameObject.SetActive(true);
                            }
                            if (item1.Card.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == soruCardImage.GetComponent<Image>().sprite.name)
                            {
                                item1.Card.transform.GetChild(4).gameObject.SetActive(true);
                            }
                        }
                        falseMi = true;
                        sayi = 0;
                        ZamaniSifirla = true;
                        cevaplananYanlisSoruSayisi++;
                        YanlisSayisiCanvas.transform.GetChild(0).GetComponent<Text>().text = "Yanlýþ Sayýsý " + cevaplananYanlisSoruSayisi + "/" + yanlisBilmeHakki;
                        sonrakineGecButton = true;
                        clickControl.SelectedObject = null;
                    }
                    cevaplananSoruSayisi++;
                }
            }
            else
            {
                if (clickObject.GetComponent<Click>() != null)
                {
                    clickControl = clickObject.GetComponent<Click>();
                    clickControl.SelectedObject = null;
                }
                zamaniDurdur = true;
            }
        }
        else
        {
            oyunKaybedildi = true;
        }
        if (cevaplananSoruSayisi == 41)
        {
            oyunKazanildi = true;
        }
    }
}
