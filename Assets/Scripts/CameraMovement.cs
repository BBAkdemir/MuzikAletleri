using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 touchStart;
    float minX, maxX, minZ, maxZ, zoomOutMin, zoomOutMax;
    public float easyMinX, easyMaxX, easyMinZ, easyMaxZ, easyZoomOutMin, easyZoomOutMax;
    public float mediumMinX, mediumMaxX, mediumMinZ, mediumMaxZ, mediumZoomOutMin, mediumZoomOutMax;
    public float hardMinX, hardMaxX, hardMinZ, hardMaxZ, hardZoomOutMin, hardZoomOutMax;
    public Vector3 easyCamStartPos, mediumCamStartPos, hardCamStartPos;
    
    public GameObject OyunBesObject;
    public GameObject OyunIkiObject;
    public GameObject OyunBirObject;
    OyunBes oyunBes;
    OyunIki oyunIki;
    private void Start()
    {
        Invoke("CameraPosition", 0.1f);
    }
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);

            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            }
            if (Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
                Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x + direction.x, minX, maxX), Camera.main.transform.position.y, Mathf.Clamp(Camera.main.transform.position.z + direction.z, minZ, maxZ));
            }
        }
        void zoom(float increment)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        }
    }
    public void CameraPosition()
    {
        if (OyunBirObject != null)
        {
            if (PlayerPrefs.GetInt("OyunBirZorluk") <= 10)
            {
                transform.position = easyCamStartPos;
                minX = easyMinX;
                maxX = easyMaxX;
                minZ = easyMinZ;
                maxZ = easyMaxZ;
                zoomOutMin = easyZoomOutMin;
                zoomOutMax = easyZoomOutMax;
                Camera.main.orthographicSize = easyZoomOutMax;
            }
            if (PlayerPrefs.GetInt("OyunBirZorluk") > 10 && PlayerPrefs.GetInt("OyunBirZorluk") <= 15)
            {
                transform.position = mediumCamStartPos;
                minX = mediumMinX;
                maxX = mediumMaxX;
                minZ = mediumMinZ;
                maxZ = mediumMaxZ;
                zoomOutMin = mediumZoomOutMin;
                zoomOutMax = mediumZoomOutMax;
                Camera.main.orthographicSize = mediumZoomOutMax;
            }
            if (PlayerPrefs.GetInt("OyunBirZorluk") > 15)
            {
                transform.position = hardCamStartPos;
                minX = hardMinX;
                maxX = hardMaxX;
                minZ = hardMinZ;
                maxZ = hardMaxZ;
                zoomOutMin = hardZoomOutMin;
                zoomOutMax = hardZoomOutMax;
                Camera.main.orthographicSize = hardZoomOutMax;
            }
        }
        if (OyunIkiObject != null)
        {
            oyunIki = OyunIkiObject.GetComponent<OyunIki>();
            if (oyunIki.Difficulty == Difficulty.Easy)
            {
                transform.position = easyCamStartPos;
                minX = easyMinX;
                maxX = easyMaxX;
                minZ = easyMinZ;
                maxZ = easyMaxZ;
                zoomOutMin = easyZoomOutMin;
                zoomOutMax = easyZoomOutMax;
                Camera.main.orthographicSize = easyZoomOutMax;
            }
            if (oyunIki.Difficulty == Difficulty.Normal)
            {
                transform.position = mediumCamStartPos;
                minX = mediumMinX;
                maxX = mediumMaxX;
                minZ = mediumMinZ;
                maxZ = mediumMaxZ;
                zoomOutMin = mediumZoomOutMin;
                zoomOutMax = mediumZoomOutMax;
                Camera.main.orthographicSize = mediumZoomOutMax;
            }
            if (oyunIki.Difficulty == Difficulty.Hard)
            {
                transform.position = hardCamStartPos;
                minX = hardMinX;
                maxX = hardMaxX;
                minZ = hardMinZ;
                maxZ = hardMaxZ;
                zoomOutMin = hardZoomOutMin;
                zoomOutMax = hardZoomOutMax;
                Camera.main.orthographicSize = hardZoomOutMax;
            }
        }
        if (OyunBesObject != null)
        {
            oyunBes = OyunBesObject.GetComponent<OyunBes>();
            if (oyunBes.difficulty == Difficulty.Easy)
            {
                transform.position = easyCamStartPos;
                minX = easyMinX;
                maxX = easyMaxX;
                minZ = easyMinZ;
                maxZ = easyMaxZ;
                zoomOutMin = easyZoomOutMin;
                zoomOutMax = easyZoomOutMax;
                Camera.main.orthographicSize = easyZoomOutMax;
            }
            if (oyunBes.difficulty == Difficulty.Normal)
            {
                transform.position = hardCamStartPos;
                minX = mediumMinX;
                maxX = mediumMaxX;
                minZ = mediumMinZ;
                maxZ = mediumMaxZ;
                zoomOutMin = mediumZoomOutMin;
                zoomOutMax = mediumZoomOutMax;
                Camera.main.orthographicSize = mediumZoomOutMax;
            }
        }
    }
}
