﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Timer timeUpdate;
    private static float totalGold;
    private PlayerShoot playerShoot;

    private void Start()
    {
        // Timer scriptini içeren GameObject'i bul ve Timer bileşenine erişimi sağla
        timeUpdate = FindObjectOfType<Timer>();
        totalGold = PlayerPrefs.GetFloat("TotalGold", totalGold);
        playerShoot = FindObjectOfType<PlayerShoot>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("ItemTime"))
            {
                timeUpdate.UpdateTime();
            }
            else if (this.gameObject.CompareTag("ItemCoin"))
            {
                totalGold += 10;
                PlayerPrefs.SetFloat("TotalGold", totalGold);
                PlayerPrefs.Save();
            }
            else if (this.gameObject.CompareTag("ItemGun1"))
            {
                playerShoot.ResetSelectedWeaponCoroutine();
                playerShoot.SelectedWeaponIndex=1;
                playerShoot.SelectedBulletHoleIndex = 0;
                DestroyOldBullet();
            }
            else if (this.gameObject.CompareTag("ItemGun2") )
            {
                DestroyOldBullet();
                playerShoot.SelectedWeaponIndex =3;
            }
            Destroy(this.gameObject);
        }
    }


    public void DestroyOldBullet()
    {
        if (GameObject.FindGameObjectWithTag("GroundLaserHole"))
        {
            GameObject oldBullet = GameObject.FindGameObjectWithTag("GroundLaserHole");
            Destroy(oldBullet);
        }
    }
}
