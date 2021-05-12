using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OyunBes : MonoBehaviour
{
    public Camera camera;

    public GameObject Masa;

    public float time;
    public Text timeText;

    ClickControl clickControl;
    LineRenderer lineRenderer;

    public GameObject clickObject;
    public GameObject CardResim;
    public GameObject CardIsim;
    public GameObject CardResimIsim;
    public GameObject ClickAndSoundObject;
    public GameObject LineRendererObject;
    public GameObject newLineRendererObject;

    public List<string> musicalInstruments;
    public List<LineRenderers> lineRenderers;
    public List<string> selectedMusicalInstruments;
    public List<string> Cikanlar;
    public List<QuestionCard> CardIsims;
    public List<QuestionCard> CardResims;
    public List<Sprite> Images;

    public Difficulty difficulty;

    public string Instrument;
    public string CardInstrument;
    public string CalacakMuzikAleti;

    public bool birinciNoktaVerildi = false;
    public bool ikinciNoktaVerildi = true;
    bool SecilenCardIsim = false;
    bool SecilenCardResim = false;
    public bool dahaOnceSecilmismi = false;
    public bool oyunKazanildi = false;
    public bool MuzikCal = false;
    public bool YanlisMuzikCal = false;

    LineRenderers lineRenderersClass;
    QuestionCard questionCardClass;

    public string[] Control;

    public int KacDogruOlmali;
    public int KacDogruOldu = 0;
    void Start()
    {
        time = 0;
        Cikanlar = new List<string>();
        lineRenderers = new List<LineRenderers>();
        musicalInstruments = new List<string>();
        Control = new string[2];
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
            CardMaker(6);
        }
        if (difficulty == Difficulty.Normal)
        {
            CardMaker(10);
            Masa.transform.position = new Vector3(0, -0.65f, 0.71f);
            Masa.transform.localScale = new Vector3(0.396002f, 0.3f, 0.396002f);
        }
        if (difficulty == Difficulty.Hard)
        {
            CardMaker(14);
            Masa.transform.position = new Vector3(0, -0.65f, 0.71f);
            Masa.transform.localScale = new Vector3(0.5491556f, 0.3f, 0.5491556f);
        }
        
    }

    public void CardMaker(int HowManyOption)
    {
        KacDogruOlmali = HowManyOption;
        CardIsims = new List<QuestionCard>();
        CardResims = new List<QuestionCard>();
        var a = 0;
        if (HowManyOption == 6)
        {
            for (int i = -2; i < HowManyOption - 2; i++)
            {
                Vector3 positionCardIsim = new Vector3(-2.25f, 0, (i * 1.25f));
                Vector3 positionCardResim = new Vector3(2.25f, 0, (i * 1.25f));
                var newCardIsim = Instantiate(CardIsim, positionCardIsim, CardIsim.transform.rotation);
                questionCardClass = new QuestionCard()
                {
                    Card = newCardIsim
                };
                CardIsims.Add(questionCardClass);
                var newCardResim = Instantiate(CardResim, positionCardResim, CardResim.transform.rotation);
                questionCardClass = new QuestionCard()
                {
                    Card = newCardResim
                };
                CardResims.Add(questionCardClass);
                newCardIsim.name = "CardIsim" + a + Instrument;
                newCardResim.name = "CardResim" + a + Instrument;
                a++;
            }
        }
        if (HowManyOption == 10)
        {
            for (int i = -4; i < HowManyOption - 4; i++)
            {
                Vector3 positionCardIsim = new Vector3(-2.25f, 0, (i * 1.25f));
                Vector3 positionCardResim = new Vector3(2.25f, 0, (i * 1.25f));
                var newCardIsim = Instantiate(CardIsim, positionCardIsim, CardIsim.transform.rotation);
                questionCardClass = new QuestionCard()
                {
                    Card = newCardIsim
                };
                CardIsims.Add(questionCardClass);
                var newCardResim = Instantiate(CardResim, positionCardResim, CardResim.transform.rotation);
                questionCardClass = new QuestionCard()
                {
                    Card = newCardResim
                };
                CardResims.Add(questionCardClass);
                newCardIsim.name = "CardIsim" + a + Instrument;
                newCardResim.name = "CardResim" + a + Instrument;

                a++;
            }
        }
        if (HowManyOption == 14)
        {
            for (int i = -6; i < HowManyOption - 6; i++)
            {
                Vector3 positionCardIsim = new Vector3(-2.25f, 0, (i * 1.25f));
                Vector3 positionCardResim = new Vector3(2.25f, 0, (i * 1.25f));
                var newCardIsim = Instantiate(CardIsim, positionCardIsim, CardIsim.transform.rotation);
                questionCardClass = new QuestionCard()
                {
                    Card = newCardIsim
                };
                CardIsims.Add(questionCardClass);
                var newCardResim = Instantiate(CardResim, positionCardResim, CardResim.transform.rotation);
                questionCardClass = new QuestionCard()
                {
                    Card = newCardResim
                };
                CardResims.Add(questionCardClass);
                newCardIsim.name = "CardIsim" + a + Instrument;
                newCardResim.name = "CardResim" + a + Instrument;

                a++;
            }
        }

        selectedMusicalInstruments = new List<string>();
        do
        {
            var kelimeBul = new System.Random().Next(musicalInstruments.Count());
            CardInstrument = musicalInstruments[kelimeBul];
            if (!selectedMusicalInstruments.Any(a => a == CardInstrument))
            {
                selectedMusicalInstruments.Add(CardInstrument);
            }
        } while (selectedMusicalInstruments.Count < HowManyOption);

        foreach (var item in CardIsims)
        {
            do
            {
                var kelimeBul = new System.Random().Next(selectedMusicalInstruments.Count());
                CardInstrument = selectedMusicalInstruments[kelimeBul];
                if (!Cikanlar.Any(a => a == CardInstrument))
                {
                    item.Instrument = CardInstrument;
                    Cikanlar.Add(CardInstrument);
                    break;
                }
            } while (Cikanlar.Any(a => a == CardInstrument));
        }
        Cikanlar = new List<string>();

        foreach (var item in CardResims)
        {
            do
            {
                var kelimeBul = new System.Random().Next(selectedMusicalInstruments.Count());
                CardInstrument = selectedMusicalInstruments[kelimeBul];
                if (!Cikanlar.Any(a => a == CardInstrument))
                {
                    item.Instrument = CardInstrument;
                    Cikanlar.Add(CardInstrument);
                    break;
                }
            } while (Cikanlar.Any(a => a == CardInstrument));
        }

        foreach (var item in CardIsims)
        {
            item.Card.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Text>().text = item.Instrument;
        }
        foreach (var item in CardResims)
        {
            foreach (var item1 in Images)
            {
                if (item1.name.Equals(item.Instrument))
                {
                    item.Card.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Image>().sprite = item1;
                    break;
                }
            }
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "" + (int)time;
        if (clickObject.GetComponent<ClickControl>() != null)
        {
            clickControl = clickObject.GetComponent<ClickControl>();
            if (birinciNoktaVerildi == false && ikinciNoktaVerildi == true && clickControl.SelectedObject != null && clickControl.SelectedObject.transform.gameObject.name.Contains("Card"))
            {
                foreach (var item in lineRenderers)
                {
                    if (item.CardOne == clickControl.SelectedObject || item.CardTwo == clickControl.SelectedObject)
                    {
                        dahaOnceSecilmismi = true;
                        break;
                    }
                    else
                    {
                        dahaOnceSecilmismi = false;
                    }
                }
                if (dahaOnceSecilmismi == false)
                {
                    newLineRendererObject = Instantiate(LineRendererObject, clickControl.SelectedObject.transform.position, new Quaternion(0, 0, 0, 0));

                    newLineRendererObject.name = "LineRendererObject" + lineRenderers.Count;
                    newLineRendererObject.GetComponent<LineRenderer>().SetPosition(0, clickControl.SelectedObject.transform.GetChild(7).position);
                    lineRenderersClass = new LineRenderers()
                    {
                        LineRenderer = newLineRendererObject,
                        CardOne = clickControl.SelectedObject
                    };
                    lineRenderers.Add(lineRenderersClass);
                    if (clickControl.SelectedObject.transform.gameObject.name.Contains("Isim"))
                    {
                        SecilenCardIsim = true;
                        foreach (var item in CardIsims)
                        {
                            if (item.Card == clickControl.SelectedObject)
                            {
                                Control[0] = item.Instrument;
                            }
                        }
                    }
                    else
                    {
                        SecilenCardResim = true;
                        foreach (var item in CardResims)
                        {
                            if (item.Card == clickControl.SelectedObject)
                            {
                                Control[0] = item.Instrument;
                            }
                        }
                    }
                    clickControl.SelectedObject = null;
                    birinciNoktaVerildi = true;
                    ikinciNoktaVerildi = false;
                }
            }
        }

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (newLineRendererObject != null && ikinciNoktaVerildi == false && birinciNoktaVerildi == true && KacDogruOldu != KacDogruOlmali)
            {
                newLineRendererObject.GetComponent<LineRenderer>().SetPosition(1, hitInfo.point);
                if (!hitInfo.transform.gameObject.name.Contains("Card") && Input.GetMouseButtonDown(0))
                {
                    Destroy(newLineRendererObject);
                    lineRenderers.RemoveAt(lineRenderers.IndexOf(lineRenderersClass));
                    clickControl.SelectedObject = null;
                    birinciNoktaVerildi = false;
                    ikinciNoktaVerildi = true;
                }
                if (hitInfo.transform.gameObject.name.Contains("Card") && Input.GetMouseButtonDown(0) && clickControl.SelectedObject != null)
                {
                    foreach (var item in lineRenderers)
                    {
                        if (item.CardOne == clickControl.SelectedObject || item.CardTwo == clickControl.SelectedObject)
                        {
                            dahaOnceSecilmismi = true;
                            break;
                        }
                        else
                        {
                            dahaOnceSecilmismi = false;
                        }
                    }
                    if ((SecilenCardIsim == true && clickControl.SelectedObject.name.Contains("Resim") && dahaOnceSecilmismi == false) || (SecilenCardResim == true && clickControl.SelectedObject.name.Contains("Isim") && dahaOnceSecilmismi == false))
                    {
                        newLineRendererObject.GetComponent<LineRenderer>().SetPosition(1, clickControl.SelectedObject.transform.GetChild(7).position);
                        lineRenderers[lineRenderers.IndexOf(lineRenderersClass)].CardTwo = clickControl.SelectedObject;
                        ikinciNoktaVerildi = true;
                        if (SecilenCardResim == true)
                        {
                            foreach (var item in CardIsims)
                            {
                                if (item.Card == clickControl.SelectedObject)
                                {
                                    Control[1] = item.Instrument;
                                    break;
                                }
                            }
                        }
                        if (SecilenCardIsim == true)
                        {
                            foreach (var item in CardResims)
                            {
                                if (item.Card == clickControl.SelectedObject)
                                {
                                    Control[1] = item.Instrument;
                                    break;
                                }
                            }
                        }
                        if (Control[0] != null && Control[1] != null && Control[0] != Control[1])
                        {
                            YanlisMuzikCal = true;
                            Destroy(newLineRendererObject);
                            lineRenderers.RemoveAt(lineRenderers.IndexOf(lineRenderersClass));
                            ikinciNoktaVerildi = true;
                            Control[0] = null;
                            Control[1] = null;
                            time += 5;
                        }
                        if (Control[0] != null && Control[1] != null && Control[0] == Control[1])
                        {
                            CalacakMuzikAleti = Control[0];
                            MuzikCal = true;
                            KacDogruOldu++;
                        }
                        clickControl.SelectedObject = null;
                        birinciNoktaVerildi = false;
                        Control[0] = null;
                        Control[1] = null;
                    }
                    else
                    {
                        Destroy(newLineRendererObject);
                        lineRenderers.RemoveAt(lineRenderers.IndexOf(lineRenderersClass));
                        clickControl.SelectedObject = null;
                        birinciNoktaVerildi = false;
                        ikinciNoktaVerildi = true;
                        Control[0] = null;
                    }
                }
            }
            if (KacDogruOldu == KacDogruOlmali)
            {
                oyunKazanildi = true;
            }
        }
    }
}
