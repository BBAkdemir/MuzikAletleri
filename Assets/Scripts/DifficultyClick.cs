using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DifficultyClick : MonoBehaviour,IPointerDownHandler
{
    DifficultySelect difficultySelect;
    public GameObject difficultySelectObject;
    void Start()
    {
        difficultySelect = difficultySelectObject.GetComponent<DifficultySelect>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        difficultySelect.clickedButton = eventData.selectedObject;
    }
    
}
