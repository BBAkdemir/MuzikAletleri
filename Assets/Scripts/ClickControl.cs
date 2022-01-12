using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerMoveHandler
{
    Click click;

    OyunBes oyunBes;
    public GameObject OyunBesObject;
    OyunIki oyunIki;
    public GameObject OyunIkiObject;
    OyunBir oyunBir;
    public GameObject OyunBirObject;
    void Start()
    {
        OyunBesObject = GameObject.Find("OyunBes");
        OyunIkiObject = GameObject.Find("OyunIki");
        OyunBirObject = GameObject.Find("OyunBir");
        if (OyunBirObject != null)
        {
            oyunBir = OyunBirObject.GetComponent<OyunBir>();
        }
        if (OyunIkiObject != null)
        {
            oyunIki = OyunIkiObject.GetComponent<OyunIki>();
        }
        if (OyunBesObject != null)
        {
            oyunBes = OyunBesObject.GetComponent<OyunBes>();
        }
        click = GameObject.Find("Sounds").GetComponent<Click>();
        click.SelectedObject = null;
    }
    void SelectObject(GameObject selected)
    {
        if (click.SelectedObject != null)
        {
            if (selected == click.SelectedObject)
            {
                return;
            }
            ClearSelection();
        }
        click.SelectedObject = selected;

    }
    void ClearSelection()
    {
        if (click.SelectedObject == null)
        {
            return;
        }
        click.SelectedObject = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (oyunBir == null && eventData.eligibleForClick && Input.touchCount < 2)
        {
            SelectObject(eventData.pointerPress);
        }
        //if (oyunBir == null && oyunIki != null && oyunIki.OyunIkiActive == true)
        //{
        //    ClearSelection();
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.eligibleForClick && (oyunBir != null || oyunBes != null) && oyunIki == null && !eventData.pointerEnter.gameObject.name.Contains("Button") && Input.touchCount < 2)
        {
            SelectObject(eventData.pointerEnter);
        }
        if (eventData.eligibleForClick && (oyunIki != null || oyunBir != null || oyunBes != null) && eventData.pointerEnter.gameObject.name.Contains("Button") && Input.touchCount < 2)
        {
            click.MoveButtonDown = eventData.pointerEnter;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.eligibleForClick && (oyunBir != null || oyunBes != null) && oyunIki == null && !eventData.pointerEnter.gameObject.name.Contains("Button") && Input.touchCount < 2)
        {
            SelectObject(eventData.pointerEnter);
        }
        if (eventData.eligibleForClick && (oyunIki != null || oyunBir != null || oyunBes != null) && eventData.pointerEnter.gameObject.name.Contains("Button") && Input.touchCount < 2)
        {
            click.MoveButtonDown = null;
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (oyunBes != null && Input.touchCount < 2)
        {
            click.MouseDownPosition = eventData.pointerCurrentRaycast.worldPosition;
        }
    }
}
