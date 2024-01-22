using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LevelsArrowButtonsControl : MonoBehaviour
{
    [SerializeField] public GameObject[] levelCards;
    private int currentIndex = 0;
    private void Start()
    {
        UpdateLevelCardsVisibility(currentIndex);
    }

    public void ArrowButtonClick(string buttonName)
    {
        int direction = buttonName == "Right Button" ? 1 : -1; // Sağa tıklanırsa 1, sola tıklanırsa -1
        currentIndex = (currentIndex + direction + levelCards.Length) % levelCards.Length;

        UpdateLevelCardsVisibility(currentIndex);
    }

    //public void ArrowButtonClick(string buttonName)
    //{
    //    if (buttonName == "Right Button")
    //    {

    //      UpdateLevelCardsVisibility(  currentIndex += 1);

    //    }
    //    else if (buttonName == "Left Button")
    //    {
    //      UpdateLevelCardsVisibility(  currentIndex -= 1);
    //    }
    //}


    private void UpdateLevelCardsVisibility(int activeArrayIndex)
    {
        foreach(GameObject card in levelCards)
        {
            card.SetActive(false);
        }
        levelCards[activeArrayIndex].SetActive(true);
    }
}
