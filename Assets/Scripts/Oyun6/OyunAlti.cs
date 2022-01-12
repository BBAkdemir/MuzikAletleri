using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunAlti : MonoBehaviour
{
    public GameObject CardLetter;
    public GameObject clickObject;
    public GameObject Menus;
    public GameObject DusecekKafes;
    public GameObject CarpmaNoktasi;
    public int YanlisBilmeHakki;
    public int yanlisBilmeHakkiYedek;
    public int DogruBilmeSayisi;
    public int DogruBilmeSayisiYedek;
    public Transform CardLetterStartPosition;

    Click clickControl;
    CarpmaKontrolu carpmaKontrolu;
    Menus menus;

    public List<string> musicalInstruments;
    public List<string> selectedMusicalInstruments;
    public List<LetterCards> CardLetters;
    public List<GameObject> cikanHarfler;

    public string CardInstrument;
    public string CalacakMuzikAleti;

    LetterCards letterCardsClass;
    public List<char> letterCount;

    bool kelimeSecildi = false;
    bool dogruMu;
    bool yanlisMi;
    public int bilindiMi;
    public bool oyunKaybedildi = false;
    public bool oyunKazanildi = false;
    public bool dahaOnceCikti = false;
    public bool sonrakineGecButton = false;
    public bool adamDusecek = false;
    public bool MuzikCalsin = false;
    public bool YanlisMuziki = false;

    public GameObject YanlisBilmeHakkiText;

    int harfSayisiYedek;
    public int Score = 0;
    public GameObject ScoreObject;
    Text ScoreObjectText;

    void Start()
    {
        YanlisBilmeHakki = PlayerPrefs.GetInt("OyunAltiZorluk");
        menus = Menus.GetComponent<Menus>();
        musicalInstruments = new List<string>();
        CardLetters = new List<LetterCards>();
        selectedMusicalInstruments = new List<string>();
        ScoreObjectText = ScoreObject.GetComponent<Text>();
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

        cikanHarfler = new List<GameObject>();
        KelimeSec();
        YanlisBilmeHakkiText.GetComponent<Text>().text = "Kalan Hak " + yanlisBilmeHakkiYedek + "/" + YanlisBilmeHakki;
    }

    public void KelimeSec()
    {
        var b = 0;
        letterCount = new List<char>();
        do
        {
            var kelimeBul = new System.Random().Next(musicalInstruments.Count());
            CardInstrument = musicalInstruments[kelimeBul];

            if (!selectedMusicalInstruments.Any(a => a == CardInstrument))
            {
                selectedMusicalInstruments.Add(CardInstrument);
                break;
            }
        } while (selectedMusicalInstruments.Any(a => a == CardInstrument));

        CalacakMuzikAleti = CardInstrument;
        CardInstrument = CardInstrument.ToUpper();

        var Baslangic = (int)Mathf.Ceil(CardInstrument.Length / 2);

        for (int i = -Baslangic; i < CardInstrument.Length - Baslangic; i++)
        {
            if (CardInstrument[b].ToString() != " ")
            {
                Vector3 positionCardLetter = new Vector3(CardLetterStartPosition.position.x + (i * 50f), CardLetterStartPosition.position.y, CardLetterStartPosition.position.z);
                var newCardLetter = Instantiate(CardLetter, positionCardLetter, CardLetter.transform.rotation);
                letterCardsClass = new LetterCards()
                {
                    Card = newCardLetter,
                    Letter = CardInstrument[b]
                };
                CardLetters.Add(letterCardsClass);
                newCardLetter.name = "CardLetter" + CardInstrument[b];
                newCardLetter.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "_";
            }
            b++;
        }
        b = 0;
        foreach (var item in CardLetters)
        {
            if (!letterCount.Any(a => a == item.Letter))
            {
                letterCount.Add(item.Letter);
            }
        }
        bilindiMi = letterCount.Count;
        harfSayisiYedek = letterCount.Count;
        yanlisBilmeHakkiYedek = YanlisBilmeHakki;
        kelimeSecildi = true;
    }

    void Update()
    {
        if ((menus.gameStop == false || DogruBilmeSayisiYedek < DogruBilmeSayisi) && yanlisBilmeHakkiYedek > 0)
        {
            if (clickObject.GetComponent<Click>().SelectedObject != null && kelimeSecildi == true && clickObject.GetComponent<Click>().SelectedObject.name.Contains("CardIsim"))
            {
                clickControl = clickObject.GetComponent<Click>();
                foreach (var item in CardLetters)
                {
                    if (clickControl.SelectedObject != null && item.Letter.ToString().Equals(clickControl.SelectedObject.name.Substring(8, 1).ToString()))
                    {
                        item.Card.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = clickControl.SelectedObject.name.Substring(8, 1).ToString();
                    }
                }
                if (cikanHarfler.Count == 0)
                {
                    cikanHarfler.Add(clickControl.SelectedObject);
                }
                else
                {
                    foreach (var item1 in cikanHarfler)
                    {
                        if (clickControl.SelectedObject.name.Substring(8, 1).ToString() == item1.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text)
                        {
                            dahaOnceCikti = true;
                            break;
                        }
                        else
                        {
                            dahaOnceCikti = false;
                        }
                    }
                    if (dahaOnceCikti == false)
                    {
                        cikanHarfler.Add(clickControl.SelectedObject);
                    }
                }

                foreach (var item in letterCount)
                {
                    if (clickControl.SelectedObject != null && item.ToString() == clickControl.SelectedObject.name.Substring(8, 1).ToString())
                    {
                        if (dahaOnceCikti == false)
                        {
                            dogruMu = true;
                            yanlisMi = false;
                            break;
                        }
                        else
                        {
                            dogruMu = false;
                            yanlisMi = false;
                            break;
                        }
                    }
                    else
                    {
                        if (dahaOnceCikti == false)
                        {
                            yanlisMi = true;
                            dogruMu = false;
                        }
                        else
                        {
                            dogruMu = false;
                            yanlisMi = false;
                        }
                        
                    }
                }
                clickControl.SelectedObject = null;

                if (dogruMu == true && bilindiMi != 0 && yanlisBilmeHakkiYedek != 0)
                {
                    bilindiMi--;
                    dogruMu = false;
                }
                if (yanlisMi == true && bilindiMi != 0 && yanlisBilmeHakkiYedek != 0)
                {
                    yanlisBilmeHakkiYedek--;
                    YanlisBilmeHakkiText.GetComponent<Text>().text = "Kalan Hak " + yanlisBilmeHakkiYedek + "/" + YanlisBilmeHakki;
                    yanlisMi = false;
                }
                if (bilindiMi == 0 && yanlisBilmeHakkiYedek != 0)
                {
                    DogruBilmeSayisiYedek++;
                    if (YanlisBilmeHakki == 3)
                    {
                        Score += (harfSayisiYedek * 100) - ((YanlisBilmeHakki - yanlisBilmeHakkiYedek) * 10);
                    }
                    if (YanlisBilmeHakki == 6)
                    {
                        Score += (harfSayisiYedek * 100) - ((YanlisBilmeHakki - yanlisBilmeHakkiYedek) * 30);
                    }
                    if (YanlisBilmeHakki == 9)
                    {
                        Score += (harfSayisiYedek * 100) - ((YanlisBilmeHakki - yanlisBilmeHakkiYedek) * 50);
                    }
                    ScoreObjectText.text = "" + Score;
                    PlayerPrefs.SetInt("Puan", Score);
                    MuzikCalsin = true;
                    if (DogruBilmeSayisiYedek < DogruBilmeSayisi)
                    {
                        kelimeSecildi = false;
                        sonrakineGecButton = true;
                    }
                }
            }
            if (kelimeSecildi == false && sonrakineGecButton == false && DogruBilmeSayisiYedek < DogruBilmeSayisi)
            {
                foreach (var item in CardLetters)
                {
                    Destroy(item.Card);
                }
                cikanHarfler = new List<GameObject>();
                CardLetters = new List<LetterCards>();
                KelimeSec();
                yanlisBilmeHakkiYedek = YanlisBilmeHakki;
                YanlisBilmeHakkiText.GetComponent<Text>().text = "Kalan Hak " + yanlisBilmeHakkiYedek + "/" + YanlisBilmeHakki;
                kelimeSecildi = true;
            }
            if (yanlisBilmeHakkiYedek <= 0)
            {
                YanlisMuziki = true;
                adamDusecek = true;
                PlayerPrefs.SetInt("Puan", Score);
                foreach (var item in CardLetters)
                {
                    if (item.Card.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text != null)
                    {
                        item.Card.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Letter.ToString();
                    }
                }
                
            }
        }
        if(DogruBilmeSayisiYedek == DogruBilmeSayisi)
        {
            PlayerPrefs.SetInt("Puan", Score);
            oyunKazanildi = true;
        }
        if (DusecekKafes != null && adamDusecek == true)
        {
            DusecekKafes.transform.position = Vector3.MoveTowards(DusecekKafes.transform.position, new Vector3(DusecekKafes.transform.position.x, CarpmaNoktasi.transform.position.y, DusecekKafes.transform.position.z), 150*Time.deltaTime);
            Time.timeScale = 1;
        }
    }

}
