using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;   // Oyuncu kontrolleri için bir deðiþken tanýmlanýyor.
    [SerializeField] private Animator animator;  // Animator bileþenine eriþmek için bir deðiþken tanýmlanýyor.

    [SerializeField] private GameObject bullet;       // Mermi prefabýný referans almak için bir deðiþken tanýmlanýyor.
    [SerializeField] private Transform bulletHole;    // Mermi deliði pozisyonunu belirtmek için bir deðiþken tanýmlanýyor.
    [SerializeField] private float force = 400;       // Mermiye uygulanacak kuvvetin büyüklüðünü belirlemek için bir deðiþken tanýmlanýyor.

    void Awake()
    {
        controls = new PlayerControls();   // Oyuncu kontrolleri için yeni bir PlayerControls nesnesi oluþturuluyor.
        controls.Enable();                  // Oyuncu kontrolleri etkinleþtiriliyor.

        // "Shoot" aksiyonu gerçekleþtiðinde Fire fonksiyonu çaðrýlýyor.
        controls.Land.Shoot.performed += ctx => Fire();
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
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

        go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);  // go GameObject'inin Rigidbody2D bileþenine force büyüklüðünde yukarý doðru bir kuvvet uygulanýyor.
       

        Destroy(go, 1.1f);   // go GameObject'i 1.1 saniye sonra yok ediliyor.

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
