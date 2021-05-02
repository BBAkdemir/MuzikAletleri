using System;
using System.Collections;
using System.Collections.Generic;
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

    public Camera camera;
    ClickControl clickControl;

    public GameObject clickObject;
    public Material material1;
    public Material material2;
    public Material material3;

    List<GameObject> EskiHalineDönecekler;
    GameObject[] Control;
    int cardX;
    int cardZ;
    bool seciliyor = false;
    public Yonler yonler;
    public bool yonAtandi = false;

    public List<GameObject> SecilenKelime;

    LineRenderers lineRenderersClass;
    public List<LineRenderers> lineRenderers;
    public bool dahaOnceSecilmismi = false;
    public GameObject newLineRendererObject;
    public GameObject LineRendererObject;
    public bool birinciNoktaVerildi = false;
    public bool ikinciNoktaVerildi = true;
    void Start()
    {
        EskiHalineDönecekler = new List<GameObject>();
        musicalInstruments = new List<string>();
        Control = new GameObject[2];
        lineRenderers = new List<LineRenderers>();

        #region Müzik aletlerini listeye ekliyoruz
        musicalInstruments.Add("BALABAN");
        musicalInstruments.Add("BAÐLAMA");
        musicalInstruments.Add("KEMENÇE");
        musicalInstruments.Add("NEY");
        musicalInstruments.Add("TAR");
        musicalInstruments.Add("UD");
        musicalInstruments.Add("ELEKTROGÝTAR");
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

        #region kelimeleri yerleþtiriyoruz
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
        for (int i = 0; i < DiziBuyuklugu; i++)
        {
            for (int j = 0; j < DiziBuyuklugu; j++)
            {
                GameObject.Find("Kart_" + (j + 1) + "_" + (i + 1)).transform.GetChild(0).GetChild(0).GetComponent<Text>().text = KelimeDizisi[i, j];
            }
        }
        #endregion
    }
    void Update()
    {
        #region yön atama
        Ray rayYon = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfoYon;
        if (Physics.Raycast(rayYon, out hitInfoYon))
        {
            if (Input.GetMouseButtonDown(0) && hitInfoYon.transform.gameObject.name.Contains("Kart"))
            {
                Control[0] = hitInfoYon.transform.gameObject;
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
            if (Input.GetMouseButton(0))
            {
                if (hitInfoYon.transform.gameObject == Control[0])
                {
                    //hitInfoYon.transform.gameObject.GetComponent<MeshRenderer>().material = material3;
                }
                if (hitInfoYon.transform.gameObject != Control[0])
                {
                    if (hitInfoYon.transform.gameObject != null && hitInfoYon.transform.gameObject.transform.position.z == Control[0].transform.position.z)
                    {
                        yonler = Yonler.Yatay;
                        SecilenKelime = new List<GameObject>();
                        SecilenKelime.Add(Control[0]);
                    }
                    if (hitInfoYon.transform.gameObject != null && hitInfoYon.transform.gameObject.transform.position.x == Control[0].transform.position.x)
                    {
                        yonler = Yonler.Dikey;
                        SecilenKelime = new List<GameObject>();
                        SecilenKelime.Add(Control[0]);
                    }
                    if (hitInfoYon.transform.gameObject != null && Math.Abs(hitInfoYon.transform.gameObject.transform.position.z - Control[0].transform.position.z) == Math.Abs(hitInfoYon.transform.gameObject.transform.position.x - Control[0].transform.position.x))
                    {
                        yonler = Yonler.Capraz;
                        SecilenKelime = new List<GameObject>();
                        SecilenKelime.Add(Control[0]);
                    }
                    yonAtandi = true;
                }
            }
        }
        #endregion

        if (clickObject.GetComponent<ClickControl>() != null)
        {
            clickControl = clickObject.GetComponent<ClickControl>();
            if (Input.GetMouseButtonDown(0) && birinciNoktaVerildi == false && ikinciNoktaVerildi == true && clickControl.SelectedObject != null && clickControl.SelectedObject.transform.gameObject.name.Contains("Kart"))
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
                    newLineRendererObject.GetComponent<LineRenderer>().SetPosition(0, clickControl.SelectedObject.transform.position);
                    lineRenderersClass = new LineRenderers()
                    {
                        LineRenderer = newLineRendererObject,
                        CardOne = clickControl.SelectedObject
                    };
                    lineRenderers.Add(lineRenderersClass);

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
            if (Input.GetMouseButton(0) && newLineRendererObject != null && ikinciNoktaVerildi == false && birinciNoktaVerildi == true /*&& KacDogruOldu != KacDogruOlmali*/)
            {
                newLineRendererObject.GetComponent<LineRenderer>().SetPosition(1, hitInfo.point);
                if (!hitInfo.transform.gameObject.name.Contains("Kart") && Input.GetMouseButtonUp(0))
                {
                    Destroy(newLineRendererObject);
                    lineRenderers.RemoveAt(lineRenderers.IndexOf(lineRenderersClass));
                    clickControl.SelectedObject = null;
                    birinciNoktaVerildi = false;
                    ikinciNoktaVerildi = true;
                }

                if (hitInfo.transform.gameObject.name.Contains("Kart") && Input.GetMouseButtonUp(0) && clickControl.SelectedObject != null)
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
                        newLineRendererObject.GetComponent<LineRenderer>().SetPosition(1, clickControl.SelectedObject.transform.position);
                        lineRenderers[lineRenderers.IndexOf(lineRenderersClass)].CardTwo = clickControl.SelectedObject;
                        birinciNoktaVerildi = false;
                        ikinciNoktaVerildi = true;
                    }
                }
            }
        }
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
                    GameObject newKart = Instantiate(Kart, new Vector3(i * 1.25f, 1, -j * 1.25f), new Quaternion(0, 0, 0, 0));
                    newKart.name = "Kart_" + (i + 1) + "_" + (j + 1);
                }
            }
            KelimeDizisi = new string[10, 10];
            DiziBuyuklugu = 10;
            DiziBuyukluguYedek = 10;
        }

        if (KelimeSayisi > 10 && KelimeSayisi <= 15)
        {
            for (int i = 0; i < KelimeSayisi; i++)
            {
                for (int j = 0; j < KelimeSayisi; j++)
                {
                    GameObject newKart = Instantiate(Kart, new Vector3(i * 1.25f, 1, -j * 1.25f), new Quaternion(0, 0, 0, 0));
                    newKart.name = "Kart_" + (i + 1) + "_" + (j + 1);
                }
            }
            KelimeDizisi = new string[KelimeSayisi, KelimeSayisi];
            DiziBuyuklugu = KelimeSayisi;
            DiziBuyukluguYedek = KelimeSayisi;
        }

        if (KelimeSayisi > 15)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    GameObject newKart = Instantiate(Kart, new Vector3(i * 1.25f, 1, -j * 1.25f), new Quaternion(0, 0, 0, 0));
                    newKart.name = "Kart_" + (i + 1) + "_" + (j + 1);
                }
            }
            KelimeDizisi = new string[15, 15];
            DiziBuyuklugu = 15;
            DiziBuyukluguYedek = 15;
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

