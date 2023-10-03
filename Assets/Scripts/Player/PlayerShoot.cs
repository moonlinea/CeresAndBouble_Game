using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;   // Oyuncu kontrolleri için bir değişken tanımlanıyor.
    [SerializeField] private Animator animator;  // Animator bileşenine erişmek için bir değişken tanımlanıyor.

    [SerializeField] private GameObject bullet;       // Mermi prefabını referans almak için bir değişken tanımlanıyor.
    [SerializeField] private Transform bulletHole;    // Mermi deliği pozisyonunu belirtmek için bir değişken tanımlanıyor.
    [SerializeField] private float force = 400;       // Mermiye uygulanacak kuvvetin büyüklüğünü belirlemek için bir değişken tanımlanıyor.

    void Awake()
    {
        controls = new PlayerControls();   // Oyuncu kontrolleri için yeni bir PlayerControls nesnesi oluşturuluyor.
        controls.Enable();                  // Oyuncu kontrolleri etkinleştiriliyor.

        // "Shoot" aksiyonu gerçekleştiğinde Fire fonksiyonu çağrılıyor.
        controls.Land.Shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        //animator.SetTrigger("shoot");   // Animator bileşeninde "shoot" tetikleyicisi etkinleştiriliyor.

        GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");   // Sahnede mevcut olan bullet objesini buluyoruz.

        if (existingBullet != null)
        {
            Destroy(existingBullet);   // Eğer mevcut bir bullet objesi varsa onu yok ediyoruz.
        }

        // Yeni bir bullet objesi oluşturuyoruz.
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

        go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);  // go GameObject'inin Rigidbody2D bileşenine force büyüklüğünde yukarı doğru bir kuvvet uygulanıyor.
       

        Destroy(go, 1.1f);   // go GameObject'i 1.1 saniye sonra yok ediliyor.

    }

    private void OnEnable()
    {
        controls.Enable();   // Script etkinleştirildiğinde oyuncu kontrolleri etkinleştiriliyor.
    }

    private void OnDisable()
    {
        controls.Disable();  // Script devre dışı bırakıldığında oyuncu kontrolleri devre dışı bırakılıyor.
    }

}
