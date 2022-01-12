using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaveMySql : MonoBehaviour
{
    [SerializeField]
    private string SkorKaydetURL = "http://www.oyunlaogreniyorum.com/muzikaletleri/ScoreSave.php";
    public void UploadScore(GameObject userName)
    {
        if (userName.GetComponent<TMP_InputField>().text != "")
        {
            PlayerPrefs.SetString("Isim", userName.GetComponent<TMP_InputField>().text);
            StartCoroutine(SaveScore(PlayerPrefs.GetInt("Oyun"), PlayerPrefs.GetString("Isim"), PlayerPrefs.GetInt("Puan")));
        }
        else
        {
            GameObject.Find("Menus").GetComponent<Menus>().uyariYazisiAc = true;
        }
    }

    IEnumerator SaveScore(int oyun, string kullaniciAdi, int score)
    {
        WWWForm SkorKayitForm = new WWWForm();
        SkorKayitForm.AddField("oyun", oyun);
        SkorKayitForm.AddField("kullaniciAdi", /*kullaniciAdi*/karakterCevir(kullaniciAdi));
        SkorKayitForm.AddField("score", score);

        WWW veriGonder = new WWW(SkorKaydetURL, SkorKayitForm);
        yield return veriGonder;
        if (veriGonder.isDone)
        {
            Debug.Log("Hesap oluþturma baþarýlý");
        }
        else
        {
            Debug.Log(veriGonder.error);
        }
    }
    public string karakterCevir(string kelime)
    {
        string mesaj = kelime;
        char[] oldValue = new char[] { 'ö', 'Ö', 'ü', 'Ü', 'ç', 'Ç', 'Ý', 'ý', 'Ð', 'ð', 'Þ', 'þ', ' ' };
        char[] newValue = new char[] { 'o', 'O', 'u', 'U', 'c', 'C', 'I', 'i', 'G', 'g', 'S', 's', '_' };
        for (int sayac = 0; sayac < oldValue.Length; sayac++)
        {
            mesaj = mesaj.Replace(oldValue[sayac], newValue[sayac]);
        }
        return mesaj;
    }
}
