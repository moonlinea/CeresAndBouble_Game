
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Timer timeUpdate;
    private static float totalGold;
    [SerializeField] public float levelTotalGold;
    private PlayerShoot playerShoot;
    private ShieldController shieldController;
    [SerializeField] public float itemsCollectedCount;
    private GameManager gameManager;

    private void Start()
    {
        itemsCollectedCount = 0;
        levelTotalGold = 0;
        // Timer scriptini içeren GameObject'i bul ve Timer bileşenine erişimi sağla
        timeUpdate = FindObjectOfType<Timer>();
        totalGold = PlayerPrefs.GetFloat("TotalGold", totalGold);
        playerShoot = FindObjectOfType<PlayerShoot>();
        shieldController = FindObjectOfType<ShieldController>();
        gameManager= FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")|| collision.collider.CompareTag("PlayerShield"))
        {
            switch (gameObject.tag)
            {
                case "ItemTime":
                    timeUpdate.UpdateTime();
                    gameManager.ScoreItemCalculated();
                    break;
                case "ItemCoin":
                    levelTotalGold += 10;
                    totalGold += 10;
                    PlayerPrefs.SetFloat("TotalGold", totalGold);
                    PlayerPrefs.Save();
                    gameManager.ScoreItemCalculated();
                    gameManager.ScoreGoldCalculated();

                    break;
                case "ItemGun1":
                    playerShoot.ResetSelectedWeaponCoroutine();
                    playerShoot.SelectedWeaponIndex = 1;
                    playerShoot.SelectedBulletHoleIndex = 0;
                    DestroyOldBullet();
                    gameManager.ScoreItemCalculated();
                    break;
                case "ItemGun2":
                    DestroyOldBullet();
                    playerShoot.SelectedWeaponIndex = 3;
                    gameManager.ScoreItemCalculated();
                    break;
                case "ItemShield":
                    shieldController.ActivateForDuration(30f);
                    gameManager.ScoreItemCalculated();

                    break;
                default:
                    break;
            }
            Destroy(gameObject);
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
