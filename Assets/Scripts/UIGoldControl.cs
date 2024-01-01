using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGoldControl : MonoBehaviour
{
    private float totalGold;
    [SerializeField] private TextMeshProUGUI totalGoldText;

    private void Start()
    {
        totalGold = PlayerPrefs.GetFloat("TotalGold", 0f);
    }

    void Update()
    {
        totalGold = PlayerPrefs.GetFloat("TotalGold", 0f);
        totalGoldText.text = totalGold.ToString();
    }
}
