using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelect : MonoBehaviour
{
    public List<GameObject> difficulty;
    public GameObject clickedButton;
    public GameObject StartButton;
    public void SelectDifficulty()
    {
        foreach (var item in difficulty)
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
        clickedButton.transform.GetChild(0).gameObject.SetActive(true);
        StartButton.GetComponent<Button>().interactable = true;
    }
}
