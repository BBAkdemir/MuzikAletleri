using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    public GameObject SelectedObject;
    public Camera camera;

    OyunIki oyunIki;
    public GameObject OyunIkiObject;
    void Start()
    {
        if (OyunIkiObject != null)
        {
            oyunIki = OyunIkiObject.GetComponent<OyunIki>();
        }
        SelectedObject = null;
    }
    void SelectObject(GameObject selected)
    {
        if (SelectedObject != null)
        {
            if (selected == SelectedObject)
            {
                return;
            }
            ClearSelection();
        }
        SelectedObject = selected;
    }
    void ClearSelection()
    {
        if (SelectedObject == null)
        {
            return;
        }
        SelectedObject = null;
    }
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject(hitObject);
            }
            else if (oyunIki != null && oyunIki.OyunIkiActive == true)
            {
                ClearSelection();
            }
        }
    }
}
