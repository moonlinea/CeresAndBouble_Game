using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Timer TimeUpdate;

    private static float gold;

    private void Start()
    {
        // Timer scriptini i�eren GameObject'i bul ve Timer bile�enine eri�imi sa�la
        TimeUpdate = FindObjectOfType<Timer>();
        gold = PlayerPrefs.GetFloat("TotalGold", gold);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
           
            if (this.gameObject.tag == "ItemTime")
            {
                
                TimeUpdate.UpdateTime();

            }
            else if (this.gameObject.tag == "ItemCoin")
            {
                gold += 10;
                
                PlayerPrefs.SetFloat("TotalGold", gold);
                PlayerPrefs.Save();
                
            }
            else if(this.gameObject.tag=="ItemGun1")
            {
                
            }
            Destroy(this.gameObject);
        }
    }
}
