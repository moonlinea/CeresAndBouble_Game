using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGoldControl : MonoBehaviour
{
    private float _totalGold;
    [SerializeField] private TextMeshProUGUI _totalGoldText;
   


    private void Start()
    {
   
        _totalGold = PlayerPrefs.GetFloat("TotalGold", 0f);
    }
    void Update()
    {
       
        _totalGold = PlayerPrefs.GetFloat("TotalGold", 0f);
        _totalGoldText.text = _totalGold.ToString();
    }

 
}
