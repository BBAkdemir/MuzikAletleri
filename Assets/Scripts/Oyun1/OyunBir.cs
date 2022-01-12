using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OyunBir : MonoBehaviour
{
    #region kartlarý oluþturma iþlemleri için
    public List<string> musicalInstruments;

    #region Yön Belirleme
    public bool CaprazKelimeler;
    public bool TersKelimeler;
    int Yon;
    int TersMiDuzMu;
    #endregion

    #region kart oluþturma
    public GameObject Kart;
    public int KelimeSayisi;
    string[,] KelimeDizisi;
    int DiziBuyuklugu;
    int DiziBuyukluguYedek;
    #endregion

    int YerSatir;
    int YerSutun;

    List<UygunKelimelerClass> uygunKelimeler;
    int bosSayisi = 0;

    KontrolOzellik[] kontrolDizisi;
    int kontrolSayisi = 1;
    int harfSayisi = 0;
    bool hicHarfYok = true;
    List<EnBuyukBosluklar> enBuyukBosluklar;

    List<string> yerlesenKelimeler;
    bool yerlesti = false;
    string kelime;

    int BaslangicIndis;
    #endregion
    Click clickControl;

    public GameObject clickObject;
    public Material material1;
    public Material material2;
    public Material material3;

    List<GameObject> EskiHalineDönecekler;
    public List<GameObject> KelimeYerleri;
    public GameObject kelimelerEasyCanvas;
    public GameObject kelimelerNormalCanvas;
    public GameObject kelimelerHardCanvas;
    public GameObject[] Control;
    int cardX;
    int cardZ;
    bool seciliyor = false;
    public Yonler yonler;
    public bool yonAtandi = false;

    #region kontrol et elemanlarý
    int CardYedekX;
    int CardYedekZ;
    int Card1X;
    int Card1Z;
    int Card2X;
    int Card2Z;
    public string ensturman;
    public bool yenisiVerildi = false;
    public bool ensturmanVar = false;
    public List<GameObject> kelimeHarfleri;
    #endregion

    public List<string> bilinenler;
    public int bilinensayisi = 0;
    public List<GameObject> SecilenKelime;
    public bool oyunKazanildi = false;

    public bool DogruMuzikCal = false;
    public bool YanlisMuzikCal = false;

    #region puan elemanlarý
    public GameObject DuraklatMenu;
    public GameObject TimeObjectGenelZaman;
    public GameObject TimeObjectSoruBasinaZaman;
    public GameObject PointObject;
    Text GenelZamanObject;
    Text SoruBasinaZamanObject;
    Text PointObjectText;
    int Points = 0;
    float GenelZaman = 0;
    float SoruBasinaZaman = 10;
    int SoruBasinaZamanYedek = 10;
    int KelimeBasinaPuan = 100;
    int SaniyeBasinaPuan = 10;
    bool ZamaniSifirla = false;
    bool PuanVerildi = false;
    #endregion
    void Start()
    {
        PointObjectText = PointObject.GetComponent<Text>();
        GenelZamanObject = TimeObjectGenelZaman.GetComponent<Text>();
        SoruBasinaZamanObject = TimeObjectSoruBasinaZaman.GetComponent<Text>();
        KelimeSayisi = PlayerPrefs.GetInt("OyunBirZorluk");
        EskiHalineDönecekler = new List<GameObject>();
        bilinenler = new List<string>();
        musicalInstruments = new List<string>();
        Control = new GameObject[2];

        #region Müzik aletlerini listeye ekliyoruz
        musicalInstruments.Add("BALABAN");
        musicalInstruments.Add("BAÐLAMA");
        musicalInstruments.Add("KEMENÇE");
        musicalInstruments.Add("NEY");
        musicalInstruments.Add("TAR");
        musicalInstruments.Add("UD");
        musicalInstruments.Add("GÝTAR");
        musicalInstruments.Add("CÜMBÜÞ");
        musicalInstruments.Add("MANDOLÝN");
        musicalInstruments.Add("ARP");
        musicalInstruments.Add("KEMAN");
        musicalInstruments.Add("PÝYANO");
        musicalInstruments.Add("AKORDEON");
        musicalInstruments.Add("UKULELE");
        musicalInstruments.Add("DOMBRA");
        musicalInstruments.Add("BENDÝR");
        musicalInstruments.Add("DARBUKA");
        musicalInstruments.Add("DEF");
        musicalInstruments.Add("KANUN");
        musicalInstruments.Add("KAVAL");
        musicalInstruments.Add("KOPUZ");
        musicalInstruments.Add("TAMBUR");
        musicalInstruments.Add("TULUM");
        musicalInstruments.Add("ZURNA");
        musicalInstruments.Add("DAVUL");
        musicalInstruments.Add("BATERÝ");
        musicalInstruments.Add("ZÝL");
        musicalInstruments.Add("KLARNET");
        musicalInstruments.Add("SAKSOFON");
        musicalInstruments.Add("ARMONÝKA");
        musicalInstruments.Add("FLÜT");
        musicalInstruments.Add("MELODÝKA");
        musicalInstruments.Add("VÝYOLA");
        musicalInstruments.Add("KONTRBAS");
        musicalInstruments.Add("VÝYOLONSEL");
        musicalInstruments.Add("OBUA");
        musicalInstruments.Add("TROMPET");
        musicalInstruments.Add("TROMBON");
        musicalInstruments.Add("KORNO");
        musicalInstruments.Add("BANDONEON");
        #endregion
        string[] harfler = {"A","B","C","Ç","D","E","F","G","Ð","H","I","Ý","J","K","L","M","N","O","Ö","P","R","S","Þ","T","U","Ü","V","Y","Z","X"};

        #region kelimeleri yerleþtiriyoruz
        KelimeYerleri = new List<GameObject>();
        kartlariGetir(KelimeSayisi);
        yerlesenKelimeler = new List<string>();
        do
        {
            DiziBuyuklugu = DiziBuyukluguYedek;
            uygunKelimeler = new List<UygunKelimelerClass>();
            kontrolDizisi = new KontrolOzellik[DiziBuyuklugu];
            enBuyukBosluklar = new List<EnBuyukBosluklar>();

            YonSec(CaprazKelimeler, TersKelimeler);
            YerSec();
            YereUygunKelimeSec(TersMiDuzMu);
            if (uygunKelimeler.Count > 0)
            {
                UygunKelimeVarsaYerlestir();
            }
        } while (yerlesenKelimeler.Count != KelimeSayisi);
        DiziBuyuklugu = DiziBuyukluguYedek;
        System.Random rnd = new System.Random();
        for (int i = 0; i < DiziBuyuklugu; i++)
        {
            for (int j = 0; j < DiziBuyuklugu; j++)
            {
                if (KelimeDizisi[i,j] == null)
                {
                    //System.Random rnd = new System.Random();
                    int randHarf = rnd.Next(30);
                    //var randHarf = new System.Random().Next(harfler.Length);
                    GameObject.Find("Kart_" + (j + 1) + "_" + (i + 1)).transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = harfler[randHarf];
                }
                else
                {
                    GameObject.Find("Kart_" + (j + 1) + "_" + (i + 1)).transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = KelimeDizisi[i, j];
                }
            }
        }
        for (int i = 0; i < yerlesenKelimeler.Count; i++)
        {
            KelimeYerleri[i].GetComponent<TextMeshProUGUI>().text = yerlesenKelimeler[i];
        }
        #endregion
    }
    private void Update()
    {
        if (oyunKazanildi == false)
        {
            if (clickObject.GetComponent<Click>() != null)
            {
                clickControl = clickObject.GetComponent<Click>();
            }
            if (Input.GetMouseButtonDown(0) && clickControl.SelectedObject != null)
            {
                if (bilinensayisi < KelimeSayisi && clickControl.SelectedObject.name.Contains("Kart"))
                {
                    SecilenKelime = new List<GameObject>();
                    Control[0] = clickControl.SelectedObject;
                    if (Control[0].name.Length == 8)
                    {
                        cardX = Convert.ToInt32(Control[0].name.Substring(5, 1));
                        cardZ = Convert.ToInt32(Control[0].name.Substring(7, 1));
                    }
                    if (Control[0].name.Length == 9)
                    {
                        if (Control[0].name.Substring(7, 1) != "_")
                        {
                            cardX = Convert.ToInt32(Control[0].name.Substring(5, 1));
                            cardZ = Convert.ToInt32(Control[0].name.Substring(7, 2));
                        }
                        else
                        {
                            cardX = Convert.ToInt32(Control[0].name.Substring(5, 2));
                            cardZ = Convert.ToInt32(Control[0].name.Substring(8, 1));
                        }
                    }
                    if (Control[0].name.Length == 10)
                    {
                        cardX = Convert.ToInt32(Control[0].name.Substring(5, 2));
                        cardZ = Convert.ToInt32(Control[0].name.Substring(8, 2));
                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (bilinensayisi < KelimeSayisi)
                {
                    if (clickControl.SelectedObject != null && clickControl.SelectedObject != Control[0] && clickControl.SelectedObject.name.Contains("Kart"))
                    {
                        if (clickControl.SelectedObject != null && clickControl.SelectedObject.transform.position.z == Control[0].transform.position.z)
                        {
                            yonler = Yonler.Yatay;
                            SecilenKelime.Add(Control[0]);
                        }
                        if (clickControl.SelectedObject != null && clickControl.SelectedObject.transform.position.x == Control[0].transform.position.x)
                        {
                            yonler = Yonler.Dikey;
                            SecilenKelime.Add(Control[0]);
                        }
                        if (clickControl.SelectedObject != null && Math.Abs(clickControl.SelectedObject.transform.position.z - Control[0].transform.position.z) == Math.Abs(clickControl.SelectedObject.transform.position.x - Control[0].transform.position.x))
                        {
                            yonler = Yonler.Capraz;
                            SecilenKelime.Add(Control[0]);
                        }
                        yonAtandi = true;
                    }
                    if (yonAtandi == true && clickControl.SelectedObject.name.Contains("Kart"))
                    {
                        if (yonler == Yonler.Yatay)
                        {
                            RaycastHit hitInfoNew;
                            Vector3 position = new Vector3(clickControl.SelectedObject.transform.position.x, Control[0].transform.position.y, Control[0].transform.position.z - 1);
                            if (Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hitInfoNew))
                            {
                                SecilenKelime.Add(hitInfoNew.transform.gameObject);
                            }
                        }
                        if (yonler == Yonler.Dikey)
                        {
                            RaycastHit hitInfoNew;
                            Vector3 position = new Vector3(Control[0].transform.position.x, Control[0].transform.position.y, clickControl.SelectedObject.transform.position.z - 1);
                            if (Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hitInfoNew))
                            {
                                SecilenKelime.Add(hitInfoNew.transform.gameObject);
                            }
                        }
                        if (yonler == Yonler.Capraz)
                        {
                            RaycastHit hitInfoNew;
                            Vector3 position = new Vector3(clickControl.SelectedObject.transform.position.x, Control[0].transform.position.y, clickControl.SelectedObject.transform.position.z - 1);
                            if (Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hitInfoNew))
                            {
                                if (Math.Abs(Control[0].transform.position.x - hitInfoNew.transform.gameObject.transform.position.x) == Math.Abs(Control[0].transform.position.z - hitInfoNew.transform.gameObject.transform.position.z))
                                {
                                    SecilenKelime.Add(hitInfoNew.transform.gameObject);
                                }
                            }
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (clickControl.SelectedObject != null && bilinensayisi < KelimeSayisi && clickControl.SelectedObject.name.Contains("Kart"))
                {
                    Control[1] = clickControl.SelectedObject.transform.gameObject;
                    ensturman = null;
                    kelimeHarfleri = new List<GameObject>();
                    KontrolEtme(Control, kelimeHarfleri);
                    yonAtandi = false;
                }
            }
            #region zaman Ve Puan Kodlarý
            if (DuraklatMenu.activeSelf == false && bilinensayisi != KelimeSayisi)
            {
                GenelZaman += Time.deltaTime;
                GenelZamanObject.text = "" + (int)GenelZaman;
            }
            if (DuraklatMenu.activeSelf == false && SoruBasinaZaman > 0 && bilinensayisi != KelimeSayisi)
            {
                SoruBasinaZaman -= Time.deltaTime;
                SoruBasinaZamanObject.text = "" + (int)SoruBasinaZaman;
            }
            if (SoruBasinaZaman <= 0 && SoruBasinaZamanObject.color != Color.red)
            {
                SoruBasinaZamanObject.text = "0";
                SoruBasinaZamanObject.color = Color.red;
            }
            if (ZamaniSifirla == true)
            {
                Points += (int)SoruBasinaZaman * SaniyeBasinaPuan;
                SoruBasinaZaman = SoruBasinaZamanYedek;
                SoruBasinaZamanObject.color = Color.white;
                ZamaniSifirla = false;
            }
            if (bilinensayisi == KelimeSayisi && PuanVerildi == false)
            {
                Points -= (int)GenelZaman * SaniyeBasinaPuan;
                Points += KelimeSayisi * KelimeBasinaPuan;
                if (Points <= 0)
                {
                    Points = 0;
                }
                PuanVerildi = true;
                oyunKazanildi = true;
                PlayerPrefs.SetInt("Puan", Points);
            }
            PointObjectText.text = "" + Points;
            #endregion
        }
    }
    public void KontrolEtme(GameObject[] Control, List<GameObject> kelimeHarfleri)
    {
        var Kart1 = Control[0];
        var Kart2 = Control[1];
        XVeZDondurme(Kart1, CardYedekX, CardYedekZ);
        Card1X = CardYedekX;
        Card1Z = CardYedekZ;
        XVeZDondurme(Kart2, CardYedekX, CardYedekZ);
        Card2X = CardYedekX;
        Card2Z = CardYedekZ;

        if (Kart1.transform.gameObject.transform.position.z == Kart2.transform.position.z)
        {
            if (Card1X < Card2X)
            {
                for (int i = 0; i < (Math.Abs(Card2X - Card1X) + 1); i++)
                {
                    kelimeHarfleri.Add(GameObject.Find("Kart_" + (Card1X + i) + "_" + Card1Z));
                }
            }
            else
            {
                for (int i = 0; i < (Math.Abs(Card2X - Card1X) + 1); i++)
                {
                    kelimeHarfleri.Add(GameObject.Find("Kart_" + (Card1X - i) + "_" + Card1Z));
                }
            }
        }
        if (Kart1.transform.gameObject.transform.position.x == Kart2.transform.position.x)
        {
            if (Card1Z < Card2Z)
            {
                for (int i = 0; i < (Math.Abs(Card2Z - Card1Z) + 1); i++)
                {
                    kelimeHarfleri.Add(GameObject.Find("Kart_" + Card1X + "_" + (Card1Z + i)));
                }
            }
            else
            {
                for (int i = 0; i < (Math.Abs(Card2Z - Card1Z) + 1); i++)
                {
                    kelimeHarfleri.Add(GameObject.Find("Kart_" + Card1X + "_" + (Card1Z - i)));
                }
            }
        }
        if (Math.Abs(Card1Z - Card2Z) == Math.Abs(Card1X - Card2X))
        {
            if (Card1Z < Card2Z)
            {
                for (int i = 0; i < (Math.Abs(Card2X - Card1X) + 1); i++)
                {
                    kelimeHarfleri.Add(GameObject.Find("Kart_" + (Card1X + i) + "_" + (Card1Z + i)));
                }
            }
            else
            {
                for (int i = 0; i < (Math.Abs(Card2X - Card1X) + 1); i++)
                {
                    kelimeHarfleri.Add(GameObject.Find("Kart_" + (Card1X - i) + "_" + (Card1Z - i)));
                }
            }
        }

        for (int i = 0; i < kelimeHarfleri.Count; i++)
        {
            ensturman += kelimeHarfleri[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }

        foreach (var item in musicalInstruments)
        {
            if (item == ensturman)
            {
                ensturmanVar = true;
                ZamaniSifirla = true;
                bilinenler.Add(item);
                bilinensayisi++;
                foreach (var item2 in kelimeHarfleri)
                {
                    item2.transform.GetChild(1).gameObject.SetActive(true);
                }
                foreach (var item2 in KelimeYerleri)
                {
                    if (item2.GetComponent<TextMeshProUGUI>().text.ToUpper() == ensturman)
                    {
                        item2.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
                        item2.GetComponent<TextMeshProUGUI>().color = Color.green;
                    }
                }
                break;
            }
            else
            {
                ensturmanVar = false;
            }
        }
        if (ensturmanVar == false)
        {
            YanlisMuzikCal = true;
        }
        else
        {
            DogruMuzikCal = true;
        }
        yenisiVerildi = false;
    }
    public void XVeZDondurme(GameObject Kart, int cardX, int cardZ)
    {
        if (Kart.name.Length == 8)
        {
            cardX = Convert.ToInt32(Kart.name.Substring(5, 1));
            cardZ = Convert.ToInt32(Kart.name.Substring(7, 1));
        }
        if (Kart.name.Length == 9)
        {
            if (Kart.name.Substring(7, 1) != "_")
            {
                cardX = Convert.ToInt32(Kart.name.Substring(5, 1));
                cardZ = Convert.ToInt32(Kart.name.Substring(7, 2));
            }
            else
            {
                cardX = Convert.ToInt32(Kart.name.Substring(5, 2));
                cardZ = Convert.ToInt32(Kart.name.Substring(8, 1));
            }
        }
        if (Kart.name.Length == 10)
        {
            cardX = Convert.ToInt32(Kart.name.Substring(5, 2));
            cardZ = Convert.ToInt32(Kart.name.Substring(8, 2));
        }
        CardYedekX = cardX;
        CardYedekZ = cardZ;
    }
    #region kelimeleri yerleþtirme kodlarý
    public void kartlariGetir(int KelimeSayisi)
    {
        if (KelimeSayisi <= 10)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject newKart = Instantiate(Kart, new Vector3(i * 1.7f, 1, -j * 1.7f), Kart.transform.rotation);
                    newKart.name = "Kart_" + (i + 1) + "_" + (j + 1);
                }
            }
            KelimeDizisi = new string[10, 10];
            DiziBuyuklugu = 10;
            DiziBuyukluguYedek = 10;
            //camera.transform.position = easyCamStartPos;
            kelimelerEasyCanvas.SetActive(true);
            for (int i = 0; i < KelimeSayisi; i++)
            {
                KelimeYerleri.Add(kelimelerEasyCanvas.transform.GetChild(i).gameObject);
            }
        }

        if (KelimeSayisi > 10 && KelimeSayisi <= 15)
        {
            for (int i = 0; i < KelimeSayisi; i++)
            {
                for (int j = 0; j < KelimeSayisi; j++)
                {
                    GameObject newKart = Instantiate(Kart, new Vector3(i * 1.7f, 1, -j * 1.7f), Kart.transform.rotation);
                    newKart.name = "Kart_" + (i + 1) + "_" + (j + 1);
                }
            }
            KelimeDizisi = new string[KelimeSayisi, KelimeSayisi];
            DiziBuyuklugu = KelimeSayisi;
            DiziBuyukluguYedek = KelimeSayisi;
            //camera.transform.position = mediumCamStartPos;
            kelimelerNormalCanvas.SetActive(true);
            for (int i = 0; i < KelimeSayisi; i++)
            {
                KelimeYerleri.Add(kelimelerNormalCanvas.transform.GetChild(i).gameObject);
            }
        }

        if (KelimeSayisi > 15)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    GameObject newKart = Instantiate(Kart, new Vector3(i * 1.7f, 1, -j * 1.7f), Kart.transform.rotation);
                    newKart.name = "Kart_" + (i + 1) + "_" + (j + 1);
                }
            }
            KelimeDizisi = new string[15, 15];
            DiziBuyuklugu = 15;
            DiziBuyukluguYedek = 15;
            //camera.transform.position = hardCamStartPos;
            kelimelerHardCanvas.SetActive(true);
            for (int i = 0; i < KelimeSayisi; i++)
            {
                KelimeYerleri.Add(kelimelerHardCanvas.transform.GetChild(i).gameObject);
            }
        }
    }
    public void YonSec(bool caprazKelimeler, bool tersKelimeler)
    {
        if (caprazKelimeler == false && tersKelimeler == false)
        {
            Yon = UnityEngine.Random.Range(0, 2);// yatay mý(0) dikey mi(1)
        }
        else if (caprazKelimeler == true && tersKelimeler == false)
        {
            Yon = UnityEngine.Random.Range(0, 3);// yatay mý(0) dikey mi(1) capraz mý(2)
        }
        else if (caprazKelimeler == false && tersKelimeler == true)
        {
            Yon = UnityEngine.Random.Range(0, 2);// yatay mý(0) dikey mi(1)
            TersMiDuzMu = UnityEngine.Random.Range(0, 2);// duz mü(0) ters mi(1)
        }
        else if (caprazKelimeler == true && tersKelimeler == true)
        {
            Yon = UnityEngine.Random.Range(0, 3);// yatay mý(0) dikey mi(1) capraz mý(2)
            TersMiDuzMu = UnityEngine.Random.Range(0, 2);// duz mü(0) ters mi(1)
        }
    }
    public void YerSec()
    {
        YerSatir = UnityEngine.Random.Range(0, DiziBuyuklugu);
        YerSutun = UnityEngine.Random.Range(0, DiziBuyuklugu);

        int kacinci = 0;
        int indis = 0;
        if (Yon == 0)// yataysa
        {
            for (int i = 0; i < DiziBuyuklugu; i++)
            {
                if (KelimeDizisi[YerSatir, i] == null)
                {
                    kacinci++;
                    var kontrolOzellik = new KontrolOzellik()
                    {
                        Sayi = kacinci,
                        Indis = indis
                    };
                    kontrolDizisi[i] = kontrolOzellik;
                    indis++;
                }
                else
                {
                    kacinci = 0;

                    var kontrolOzellik = new KontrolOzellik()
                    {
                        Sayi = kacinci,
                        Harf = KelimeDizisi[YerSatir, i],
                        Indis = indis
                    };
                    kontrolDizisi[i] = kontrolOzellik;
                    indis++;
                }
            }
        }
        if (Yon == 1)//dikeyse
        {
            for (int i = 0; i < DiziBuyuklugu; i++)
            {
                if (KelimeDizisi[i, YerSutun] == null)
                {
                    kacinci++;
                    var kontrolOzellik = new KontrolOzellik()
                    {
                        Sayi = kacinci,
                        Indis = indis
                    };
                    kontrolDizisi[i] = kontrolOzellik;
                    indis++;
                }
                else
                {
                    kacinci = 0;

                    var kontrolOzellik = new KontrolOzellik()
                    {
                        Sayi = kacinci,
                        Harf = KelimeDizisi[i, YerSutun],
                        Indis = indis
                    };
                    kontrolDizisi[i] = kontrolOzellik;
                    indis++;
                }
            }
        }
        if (CaprazKelimeler == true && Yon == 2)//çaprazsa
        {
            if (YerSatir > YerSutun)
            {
                kontrolDizisiDoldur((YerSatir - YerSutun), 0);
            }
            if (YerSatir == YerSutun)
            {
                kontrolDizisiDoldur(0, 0);
            }
            if (YerSatir < YerSutun)
            {
                kontrolDizisiDoldur(0, (YerSutun - YerSatir));
            }
        }
    }
    public void kontrolDizisiDoldur(int Satir, int Sutun)
    {
        int kacinci = 0;
        int indis = 0;
        kontrolDizisi = new KontrolOzellik[DiziBuyuklugu - (Satir + Sutun)];
        DiziBuyuklugu = DiziBuyuklugu - (Satir + Sutun);
        for (int i = 0; i < DiziBuyuklugu; i++)
        {
            if (KelimeDizisi[(Satir + i), (Sutun + i)] == null)
            {
                kacinci++;
                var kontrolOzellik = new KontrolOzellik()
                {
                    Sayi = kacinci,
                    Indis = indis
                };
                kontrolDizisi[i] = kontrolOzellik;
                indis++;
            }
            else
            {
                kacinci = 0;

                var kontrolOzellik = new KontrolOzellik()
                {
                    Sayi = kacinci,
                    Harf = KelimeDizisi[YerSatir, i],
                    Indis = indis
                };
                kontrolDizisi[i] = kontrolOzellik;
                indis++;
            }
        }
    }
    public void YereUygunKelimeSec(int TersMiDuzMu)
    {
        for (int i = 0; i < kontrolDizisi.Length; i++)
        {
            if (kontrolDizisi[i]?.Sayi == 0)
            {
                hicHarfYok = false;
                KontrolEdilebilecekIndisleriBulma(i, i);
                if (kontrolSayisi > 1 && harfSayisi > 0)
                {
                    if (TersKelimeler == false || TersMiDuzMu == 0)
                    {
                        foreach (var item in musicalInstruments)
                        {
                            kelimeyiSec(musicalInstruments, kontrolDizisi, item, kontrolSayisi, harfSayisi, i);
                        }
                    }
                    if (TersKelimeler == true && TersMiDuzMu == 1)
                    {
                        foreach (var item in musicalInstruments)
                        {
                            char[] harfler = item.ToCharArray();
                            Array.Reverse(harfler);
                            string tersMusicalInstrument = new string(harfler);

                            kelimeyiSec(musicalInstruments, kontrolDizisi, tersMusicalInstrument, kontrolSayisi, harfSayisi, i);
                        }
                    }
                }
            }
        }
        if (hicHarfYok == true || uygunKelimeler.Count == 0)
        {
            enBuyukBosluklar = new List<EnBuyukBosluklar>();
            hicHarfYok = true;
            var enBuyukBosluk = new EnBuyukBosluklar();

            for (int i = 0; i < kontrolDizisi.Length; i++)
            {
                if (kontrolDizisi[i] != null)
                {
                    if ((kontrolDizisi[i].Sayi == 0 && kontrolDizisi[i].Indis >= 2 && kontrolDizisi[i - 1].Sayi != 0))
                    {
                        enBuyukBosluk.enBuyukBosluk = kontrolDizisi[i - 1].Sayi;
                        enBuyukBosluklar.Add(enBuyukBosluk);
                        enBuyukBosluk = new EnBuyukBosluklar();
                    }
                    if (kontrolDizisi[i].Indis == (DiziBuyuklugu - 1))
                    {
                        enBuyukBosluk.enBuyukBosluk = kontrolDizisi[i].Sayi;
                        enBuyukBosluklar.Add(enBuyukBosluk);
                        enBuyukBosluk = new EnBuyukBosluklar();
                    }
                    if (kontrolDizisi[i].Sayi == 1)
                    {
                        enBuyukBosluk.BoslukBaslangicIndexi = kontrolDizisi[i].Indis;
                    }
                }
            }
            foreach (var item in musicalInstruments)
            {
                for (int i = 0; i < enBuyukBosluklar.Count; i++)
                {
                    if (item.Length <= enBuyukBosluklar[i].enBuyukBosluk)
                    {
                        var uygunKelime = new UygunKelimelerClass()
                        {
                            MusicalEnsturment = item,
                            Sayi = enBuyukBosluklar[i].BoslukBaslangicIndexi
                        };
                        uygunKelimeler.Add(uygunKelime);
                        break;
                    }
                }
            }
        }
    }
    public void kelimeyiSec(List<string> musicalInstrument, KontrolOzellik[] kontrolDizisi, string kelime, int kontrolSayisi, int harfSayisi, int i)
    {
        if (kontrolDizisi[i] != null && kelime.Length <= (((kontrolDizisi[i].Indis - kontrolSayisi)) + harfSayisi))
        {
            if (UygunMu(kelime, kontrolDizisi[i].Harf, kontrolSayisi, harfSayisi) == true)
            {
                var uygunKelime = new UygunKelimelerClass()
                {
                    MusicalEnsturment = kelime,
                    Sayi = kontrolDizisi[i].Indis - BaslangicIndis
                };
                uygunKelimeler.Add(uygunKelime);
            }
            else
            {
                hicHarfYok = true;
            }
        }
    }
    public bool UygunMu(string kelime, string kontrolHarf, int harftenOncesiKacTane, int harftenSonrasiKacTane)
    {
        var uygunMu = false;
        char[] harfler = kelime.ToCharArray();
        for (int i = 0; i < harfler.Length; i++)
        {
            if (harfler[i].ToString() == kontrolHarf)
            {
                if (i <= harftenOncesiKacTane && (harfler.Length - i - 1) <= harftenSonrasiKacTane)
                {
                    BaslangicIndis = i;
                    uygunMu = true;
                }
            }
        }
        return uygunMu;
    }
    public void UygunKelimeVarsaYerlestir()
    {
        int rand = UnityEngine.Random.Range(0, uygunKelimeler.Count);
        bool VarMi = false;
        foreach (var item in yerlesenKelimeler)
        {
            if (item == uygunKelimeler[rand].MusicalEnsturment)
            {
                VarMi = true;
                break;
            }
        }
        if (VarMi == false)
        {
            kelime = uygunKelimeler[rand].MusicalEnsturment;
            if (TersKelimeler == true && TersMiDuzMu == 1)
            {
                char[] harfler = kelime.ToCharArray();
                Array.Reverse(harfler);
                kelime = new string(harfler);
            }
            if (Yon == 0)//yataysa
            {
                for (int i = uygunKelimeler[rand].Sayi; i < uygunKelimeler[rand].Sayi + kelime.Length; i++)
                {
                    KelimeDizisi[YerSatir, i] = kelime[i - uygunKelimeler[rand].Sayi].ToString();
                }
                yerlesenKelimeler.Add(uygunKelimeler[rand].MusicalEnsturment);
            }
            if (Yon == 1)//dikeyse
            {
                for (int i = uygunKelimeler[rand].Sayi; i < uygunKelimeler[rand].Sayi + kelime.Length; i++)
                {
                    KelimeDizisi[i, YerSutun] = kelime[i - uygunKelimeler[rand].Sayi].ToString();
                }
                yerlesenKelimeler.Add(uygunKelimeler[rand].MusicalEnsturment);
            }
            if (Yon == 2)//çaprazsa
            {
                if (YerSatir > YerSutun)
                {
                    for (int i = uygunKelimeler[rand].Sayi; i < uygunKelimeler[rand].Sayi + kelime.Length; i++)
                    {
                        KelimeDizisi[(YerSatir - YerSutun) + i, i] = kelime[i - uygunKelimeler[rand].Sayi].ToString();
                    }
                }
                if (YerSatir == YerSutun)
                {
                    for (int i = uygunKelimeler[rand].Sayi; i < uygunKelimeler[rand].Sayi + kelime.Length; i++)
                    {
                        KelimeDizisi[i, i] = kelime[i - uygunKelimeler[rand].Sayi].ToString();
                    }
                }
                if (YerSatir < YerSutun)
                {
                    for (int i = uygunKelimeler[rand].Sayi; i < uygunKelimeler[rand].Sayi + kelime.Length; i++)
                    {
                        KelimeDizisi[i, (YerSutun - YerSatir) + i] = kelime[i - uygunKelimeler[rand].Sayi].ToString();
                    }
                }
                yerlesenKelimeler.Add(uygunKelimeler[rand].MusicalEnsturment);
            }

            yerlesti = true;
        }
    }
    public void KontrolEdilebilecekIndisleriBulma(int i1, int i2)
    {
        bool bitti1 = false;
        bool bitti2 = false;
        if (i1 >= 0 || i2 <= kontrolDizisi.Length)
        {
            if (kontrolDizisi[i1].Sayi >= 1 && bitti1 == false)
            {
                kontrolSayisi++;
                if (kontrolDizisi[i1].Sayi == 1)
                {
                    bitti1 = true;
                }
            }
            else
            {
                bitti1 = true;
            }
            i2++;
            if (bitti2 == false && kontrolDizisi[i2 - 1].Indis != DiziBuyuklugu - 1 && kontrolDizisi[i2] != null)
            {
                if (bitti2 == false && kontrolDizisi[i2].Sayi > 0)
                {
                    harfSayisi++;
                }
                if (kontrolDizisi[i2].Sayi == 0)
                {
                    bitti2 = true;
                }
            }
            else
            {
                bitti2 = true;
            }

            i1--;
        }
    }
    #endregion
}

