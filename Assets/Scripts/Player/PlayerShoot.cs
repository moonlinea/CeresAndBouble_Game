using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;   // Oyuncu kontrolleri i�in bir de�i�ken tan�mlan�yor.
    [SerializeField] private Animator animator;  // Animator bile�enine eri�mek i�in bir de�i�ken tan�mlan�yor.

    [SerializeField] private GameObject bullet;       // Mermi prefab�n� referans almak i�in bir de�i�ken tan�mlan�yor.
    [SerializeField] private Transform bulletHole;    // Mermi deli�i pozisyonunu belirtmek i�in bir de�i�ken tan�mlan�yor.
    [SerializeField] private float force = 400;       // Mermiye uygulanacak kuvvetin b�y�kl���n� belirlemek i�in bir de�i�ken tan�mlan�yor.

    void Awake()
    {
        controls = new PlayerControls();   // Oyuncu kontrolleri i�in yeni bir PlayerControls nesnesi olu�turuluyor.
        controls.Enable();                  // Oyuncu kontrolleri etkinle�tiriliyor.

        // "Shoot" aksiyonu ger�ekle�ti�inde Fire fonksiyonu �a�r�l�yor.
        controls.Land.Shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        //animator.SetTrigger("shoot");   // Animator bile�eninde "shoot" tetikleyicisi etkinle�tiriliyor.

        GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");   // Sahnede mevcut olan bullet objesini buluyoruz.

        if (existingBullet != null)
        {
            Destroy(existingBullet);   // E�er mevcut bir bullet objesi varsa onu yok ediyoruz.
        }

        // Yeni bir bullet objesi olu�turuyoruz.
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

        go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);  // go GameObject'inin Rigidbody2D bile�enine force b�y�kl���nde yukar� do�ru bir kuvvet uygulan�yor.
       

        Destroy(go, 1.1f);   // go GameObject'i 1.1 saniye sonra yok ediliyor.

    }

    private void OnEnable()
    {
        controls.Enable();   // Script etkinle�tirildi�inde oyuncu kontrolleri etkinle�tiriliyor.
    }

    private void OnDisable()
    {
        controls.Disable();  // Script devre d��� b�rak�ld���nda oyuncu kontrolleri devre d��� b�rak�l�yor.
    }

}
