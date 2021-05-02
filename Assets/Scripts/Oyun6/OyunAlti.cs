using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunAlti : MonoBehaviour
{
    public GameObject CardLetter;
    public GameObject clickObject;
    public GameObject Menus;
    public int YanlisBilmeHakki;
    public int yanlisBilmeHakkiYedek;

    ClickControl clickControl;
    Menus menus;

    public List<string> musicalInstruments;
    public List<string> selectedMusicalInstruments;
    public List<LetterCards> CardLetters;

    public string CardInstrument;

    LetterCards letterCardsClass;
    public List<char> letterCount;

    bool kelimeSecildi = false;
    bool dogruMu;
    bool yanlisMi;
    int bilindiMi;
    public bool oyunKaybedildi = false;

    void Start()
    {
        menus = Menus.GetComponent<Menus>();
        musicalInstruments = new List<string>();
        CardLetters = new List<LetterCards>();
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

        KelimeSec();
    }

    public void KelimeSec()
    {
        var b = 0;
        letterCount = new List<char>();
        selectedMusicalInstruments = new List<string>();
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

        CardInstrument = CardInstrument.ToUpper();

        var Baslangic = (int)Mathf.Ceil(CardInstrument.Length / 2);

        for (int i = -Baslangic; i < CardInstrument.Length - Baslangic; i++)
        {
            if (CardInstrument[b].ToString() != " ")
            {
                Vector3 positionCardLetter = new Vector3((i * 1.25f), 2.3f, -5.5f);
                var newCardLetter = Instantiate(CardLetter, positionCardLetter, CardLetter.transform.rotation);
                letterCardsClass = new LetterCards()
                {
                    Card = newCardLetter,
                    Letter = CardInstrument[b]
                };
                CardLetters.Add(letterCardsClass);
                newCardLetter.name = "CardLetter" + CardInstrument[b];
                newCardLetter.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "_";
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
        yanlisBilmeHakkiYedek = YanlisBilmeHakki;
        kelimeSecildi = true;
    }

    void Update()
    {
        if (menus.gameStop == false)
        {
            if (clickObject.GetComponent<ClickControl>().SelectedObject != null && kelimeSecildi == true && clickObject.GetComponent<ClickControl>().SelectedObject.name.Contains("CardIsim"))
            {
                clickControl = clickObject.GetComponent<ClickControl>();
                foreach (var item in CardLetters)
                {
                    if (clickControl.SelectedObject != null && item.Letter.ToString().Equals(clickControl.SelectedObject.name.Substring(8, 1).ToString()))
                    {
                        item.Card.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = clickControl.SelectedObject.name.Substring(8, 1).ToString();
                    }
                }
                foreach (var item in letterCount)
                {
                    if (clickControl.SelectedObject != null && item.ToString() == clickControl.SelectedObject.name.Substring(8, 1).ToString())
                    {
                        dogruMu = true;
                        yanlisMi = false;
                        break;
                    }
                    else if (clickControl.SelectedObject != null && item.ToString() != clickControl.SelectedObject.name.Substring(8, 1).ToString())
                    {
                        yanlisMi = true;
                        dogruMu = false;
                    }
                }
                clickControl.SelectedObject = null;
                if (dogruMu == true)
                {
                    bilindiMi--;
                    dogruMu = false;
                }
                if (yanlisMi == true)
                {
                    yanlisBilmeHakkiYedek--;
                    yanlisMi = false;
                }
                if (bilindiMi == 0)
                {
                    kelimeSecildi = false;
                }
            }
            if (kelimeSecildi == false)
            {
                foreach (var item in CardLetters)
                {
                    Destroy(item.Card);
                }
                CardLetters = new List<LetterCards>();
                KelimeSec();
                yanlisBilmeHakkiYedek = YanlisBilmeHakki;
                kelimeSecildi = true;
            }
            if (yanlisBilmeHakkiYedek == 0)
            {
                oyunKaybedildi = true;
            }
        }
    }
    
}
