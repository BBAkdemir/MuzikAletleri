using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpmaKontrolu : MonoBehaviour
{
    OyunAlti oyunAlti;
    public GameObject OyunAltiObject;

    private void Start()
    {
        oyunAlti = OyunAltiObject.GetComponent<OyunAlti>();
    }

    void OnCollisionEnter(Collision collision)
    {
        oyunAlti.oyunKaybedildi = true;
        Destroy(collision.gameObject);
    }
}
