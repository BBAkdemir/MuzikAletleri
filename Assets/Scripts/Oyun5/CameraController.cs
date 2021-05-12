using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    OyunBes oyunBes;
    OyunIki oyunIki;
    public GameObject OyunBesObject;
    public GameObject OyunIkiObject;

    public float speed = 1f;
    public float Sensivity = 1f;

    public float sensitivity = 1f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;

    public float maxYEkseniArti;
    public float maxZEkseniArti;
    public float maxZEkseniEksi;
    public float maxXEkseniArti;
    public float maxXEkseniEksi;
    void Start()
    {
        if (OyunBesObject != null)
        {
            oyunBes = OyunBesObject.GetComponent<OyunBes>();
            if (oyunBes.difficulty == Difficulty.Easy)
            {
                transform.position += new Vector3(0, 0, 0);
                maxZEkseniArti = -0.3f;
                maxZEkseniEksi = -6f;
                maxYEkseniArti = 6f;
            }
            if (oyunBes.difficulty == Difficulty.Normal)
            {
                transform.position += new Vector3(0, 1.25f, -2.25f);
                maxZEkseniArti = 1.5f;
                maxZEkseniEksi = -8f;
                maxYEkseniArti = 8f;
            }
            if (oyunBes.difficulty == Difficulty.Hard)
            {
                transform.position += new Vector3(0, 2.25f, -4.75f);
                maxZEkseniArti = 4.5f;
                maxZEkseniEksi = -10f;
                maxYEkseniArti = 10f;
            }
        }
        if (OyunIkiObject != null)
        {
            oyunIki = OyunIkiObject.GetComponent<OyunIki>();
            if (oyunIki.Difficulty == Difficulty.Easy)
            {
                transform.position += new Vector3(0, 0, 0);
                maxZEkseniArti = 1.5f;
                maxZEkseniEksi = -6f;
                maxYEkseniArti = 6f;
                maxXEkseniArti = transform.position.x + 5;
                maxXEkseniEksi = transform.position.x - 5;
            }
            if (oyunIki.Difficulty == Difficulty.Normal)
            {
                transform.position += new Vector3(1.84f, 1.25f, -2.25f);
                maxZEkseniArti = 3f;
                maxZEkseniEksi = -8f;
                maxYEkseniArti = 8f;
                maxXEkseniArti = transform.position.x + 5;
                maxXEkseniEksi = transform.position.x - 5;
            }
            if (oyunIki.Difficulty == Difficulty.Hard)
            {
                transform.position += new Vector3(3.63f, 2.25f, -4.75f);
                maxZEkseniArti = 6f;
                maxZEkseniEksi = -10f;
                maxYEkseniArti = 10f;
                maxXEkseniArti = transform.position.x + 5;
                maxXEkseniEksi = transform.position.x - 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 4 && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            transform.Translate(Vector3.forward * speed);
        }
        else if (transform.position.y <= maxYEkseniArti && Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            transform.Translate(-Vector3.forward * speed);
            if (transform.position.z >= maxZEkseniArti)
            {
                transform.localPosition -= new Vector3(0, 0, 0.9f);
            }
            if (transform.position.z < maxZEkseniEksi)
            {
                transform.Translate(Vector3.forward * speed);
            }
        }

        if (transform.position.z <= maxZEkseniArti && Input.GetKey("w"))
        {
            transform.localPosition += new Vector3(0, 0, 0.1f);
        }
        if (transform.position.z >= maxZEkseniEksi && Input.GetKey("s"))
        {
            transform.localPosition -= new Vector3(0, 0, 0.1f);
        }
        if (transform.position.x >= maxXEkseniEksi && Input.GetKey("a"))
        {
            transform.localPosition -= new Vector3(0.1f, 0, 0);
        }
        if (transform.position.x <= maxXEkseniArti && Input.GetKey("d"))
        {
            transform.localPosition += new Vector3(0.1f, 0, 0);
        }



    }
}
