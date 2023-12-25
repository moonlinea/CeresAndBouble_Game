using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;   // Oyuncu kontrolleri için bir deðiþken tanýmlanýyor.
    [SerializeField] private Animator animator;  // Animator bileþenine eriþmek için bir deðiþken tanýmlanýyor.

    [SerializeField] private GameObject[] bullets;       // Mermi prefabýný referans almak için bir deðiþken tanýmlanýyor.
    [SerializeField] private Transform bulletHole;    // Mermi deliði pozisyonunu belirtmek için bir deðiþken tanýmlanýyor.
    [SerializeField] private float force = 400;       // Mermiye uygulanacak kuvvetin büyüklüðünü belirlemek için bir deðiþken tanýmlanýyor.
    [SerializeField] public int WhichGun=0;
    void Awake()
    {
        controls = new PlayerControls();   // Oyuncu kontrolleri için yeni bir PlayerControls nesnesi oluþturuluyor.
        controls.Enable();                  // Oyuncu kontrolleri etkinleþtiriliyor.

        // "Shoot" aksiyonu gerçekleþtiðinde Fire fonksiyonu çaðrýlýyor.
        controls.Land.Shoot.performed += ctx => Fire();
    }
    private IEnumerator ResetWhichGun()
    {
        yield return new WaitForSeconds(3f);  // 10 saniye bekleyip sonra WhichGun'ı sıfıra çevir
        WhichGun = 0;

    }

    void Fire()
    {
        //animator.SetTrigger("shoot");   // Animator bileþeninde "shoot" tetikleyicisi etkinleþtiriliyor.

        GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");   // Sahnede mevcut olan bullet objesini buluyoruz.

        if (existingBullet != null)
        {
            Destroy(existingBullet);   // Eðer mevcut bir bullet objesi varsa onu yok ediyoruz.
        }

        // Yeni bir bullet objesi oluþturuyoruz.
        GameObject go = Instantiate(bullets[WhichGun], bulletHole.position, bullets[WhichGun].transform.rotation);

        go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);  // go GameObject'inin Rigidbody2D bileþenine force büyüklüðünde yukarý doðru bir kuvvet uygulanýyor.
       

        Destroy(go, 1.1f);   // go GameObject'i 1.1 saniye sonra yok ediliyor.

    }

    public void ChangeGun(int GunNumber)
    {
        WhichGun = 1;  // ItemGun1 toplandığında WhichGun'ı 1 yap
        StartCoroutine(ResetWhichGun());
    }

    private void OnEnable()
    {
        controls.Enable();   // Script etkinleþtirildiðinde oyuncu kontrolleri etkinleþtiriliyor.
    }

    private void OnDisable()
    {
        controls.Disable();  // Script devre dýþý býrakýldýðýnda oyuncu kontrolleri devre dýþý býrakýlýyor.
    }

}
