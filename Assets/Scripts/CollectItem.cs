using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Timer TimeUpdate;

    private static float gold;
    private PlayerShoot playerShoot;

    private void Start()
    {
        // Timer scriptini içeren GameObject'i bul ve Timer bileþenine eriþimi saðla
        TimeUpdate = FindObjectOfType<Timer>();
        gold = PlayerPrefs.GetFloat("TotalGold", gold);
        playerShoot = FindObjectOfType<PlayerShoot>();
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
                playerShoot.ChangeGun(1);
               
            }
            Destroy(this.gameObject);
        }
    }
}
