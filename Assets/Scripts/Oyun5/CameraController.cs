using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    OyunBir oyunBir;
    OyunBes oyunBes;
    OyunIki oyunIki;
    public GameObject OyunBesObject;
    public GameObject OyunIkiObject;
    public GameObject OyunBirObject;
    Click selectedObject;
    public GameObject ClickObject;

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

    public GameObject UpButton;
    public GameObject DownButton;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject PlusButton;
    public GameObject NegativeButton;
    void Start()
    {
        Invoke("CameraPosition", 0.1f);
    }

    public void CameraPosition()
    {
        selectedObject = ClickObject.GetComponent<Click>();
        /*if (OyunBirObject != null)
        {
            oyunBir = OyunBirObject.GetComponent<OyunBir>();
            if (oyunBir.KelimeSayisi <= 10)
            {
                transform.position += new Vector3(0, 0, 0);
                maxZEkseniArti = 0.5f;
                maxZEkseniEksi = -15.3f;
                maxYEkseniArti = 18.2f;
                maxXEkseniArti = transform.position.x + 7;
                maxXEkseniEksi = transform.position.x - 7;
            }
            if (oyunBir.KelimeSayisi > 10 && oyunBir.KelimeSayisi <= 15)
            {
                transform.position = new Vector3(19f, 27f, -20f);
                maxZEkseniArti = 3.5f;
                maxZEkseniEksi = -23.3f;
                maxYEkseniArti = 27f;
                maxXEkseniArti = transform.position.x + 7;
                maxXEkseniEksi = transform.position.x - 7;
            }
            if (oyunBir.KelimeSayisi > 15)
            {
                transform.position = new Vector3(18.9f, 26.24f, -20.26f);
                maxZEkseniArti = 4.5f;
                maxZEkseniEksi = -25.3f;
                maxYEkseniArti = 29.2f;
                maxXEkseniArti = transform.position.x + 7;
                maxXEkseniEksi = transform.position.x - 7;
            }
        }*/
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
                transform.position = new Vector3(-0.1f, 7.5f, -7f);
                maxZEkseniArti = 1.5f;
                maxZEkseniEksi = -8f;
                maxYEkseniArti = 9f;
            }
            if (oyunBes.difficulty == Difficulty.Hard)
            {
                transform.position = new Vector3(-0.1f, 7.5f, -7f);
                maxZEkseniArti = 4.5f;
                maxZEkseniEksi = -10f;
                maxYEkseniArti = 10f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 4 && (Input.GetAxis("Mouse ScrollWheel") > 0f || (selectedObject.MoveButtonDown != null && selectedObject.MoveButtonDown == PlusButton)))
        {
            transform.Translate(Vector3.forward * speed);
        }
        else if (transform.position.y <= maxYEkseniArti && (Input.GetAxis("Mouse ScrollWheel") < 0f || (selectedObject.MoveButtonDown != null && selectedObject.MoveButtonDown == NegativeButton)))
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

        if (transform.position.z <= maxZEkseniArti && (Input.GetKey("w") || (selectedObject.MoveButtonDown != null && selectedObject.MoveButtonDown == UpButton)))
        {
            transform.localPosition += new Vector3(0, 0, 0.5f);
        }
        if (transform.position.z >= maxZEkseniEksi && (Input.GetKey("s") || (selectedObject.MoveButtonDown != null && selectedObject.MoveButtonDown == DownButton)))
        {
            transform.localPosition -= new Vector3(0, 0, 0.5f);
        }
        if (transform.position.x >= maxXEkseniEksi && (Input.GetKey("a") || (selectedObject.MoveButtonDown != null && selectedObject.MoveButtonDown == LeftButton)))
        {
            transform.localPosition -= new Vector3(0.5f, 0, 0);
        }
        if (transform.position.x <= maxXEkseniArti && (Input.GetKey("d") || (selectedObject.MoveButtonDown != null && selectedObject.MoveButtonDown == RightButton)))
        {
            transform.localPosition += new Vector3(0.5f, 0, 0);
        }
    }
}
