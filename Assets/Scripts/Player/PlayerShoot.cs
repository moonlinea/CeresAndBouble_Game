//using UnityEngine;
//using System.Collections;

//public class PlayerShoot : MonoBehaviour
//{
//    PlayerControls controls;
//    [SerializeField] private Animator animator;
//    [SerializeField] private GameObject[] bullets;
//    [SerializeField] private AudioSource ropeSound;
//    [SerializeField] private Transform[] bulletHole;
//    [SerializeField] private float force = 400;
//    [SerializeField] public int WhichGun = 0;
//    [SerializeField] public int WhichHole = 0;
//    private Transform firstHoleTransform;

//    private bool isRopeSoundOn;
//    private bool oneShoot = true;

//    private const float bulletDestroyTime = 1.1f;
//    private const int destroyTimeForGun1 = 15;
//    private const float resetWhichGunWaitTime = 10f;

//    void Awake()
//    {
//        controls = new PlayerControls();
//        controls.Enable();
//        controls.Land.Shoot.performed += ctx => Fire();
//    }

//    private void Start()
//    {
//        WhichGun = 0;
//        WhichHole = 0;
//        firstHoleTransform = bulletHole[0];

//    }

//    public IEnumerator ResetWhichGunCoroutine()
//    {
//        yield return new WaitForSeconds(resetWhichGunWaitTime);
//        WhichGun = 0;
//        WhichHole = 0;
//    }

//    public void Fire()
//    {
//        isRopeSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
//        if (isRopeSoundOn) ropeSound.Play();
//        if (WhichGun != 3)
//        {
//            bulletHole[0] = firstHoleTransform;
//            GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");
//            if (existingBullet != null)
//            {
//                Destroy(existingBullet);
//            }

//            WhichHole = (WhichGun == 2) ? 1 : 0;
//            Shoot(WhichHole, WhichGun, 0);

//        }
//        else { GroundLaserShoot(); }
//    }
//    public void GroundLaserShoot()
//    {
//        if (oneShoot)
//        {
//            Shoot(1, 3, 0); // Kuvveti sıfır olarak geç
//            oneShoot = false;
//        }
//        else
//        {
//            Shoot(0, 2, 400f); // Diğer durumlar için kuvvet varsayılan olarak geçilecek
//                               // GroundLaserHole pozisyonunu almak için oneShoot'i tersine çevir

//        }
//    }


//    public void Shoot(int WhichHole, int WhichGun, float customForce = 400f)
//    {
//        if (WhichGun == 0 || WhichGun == 1)
//        {
//            GameObject newBullet = Instantiate(bullets[WhichGun], bulletHole[WhichHole].position, bullets[WhichGun].transform.rotation);

//            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
//            bulletRigidbody.AddForce(Vector2.up * force);
//            float destroyTime = (WhichGun == 0) ? bulletDestroyTime : destroyTimeForGun1;
//            Destroy(newBullet, destroyTime);

//        }
//        else if (WhichGun == 2)
//        {
//            bulletHole[WhichHole].position = GameObject.FindGameObjectWithTag("GroundLaserHole").transform.position;
//            GameObject newBullet = Instantiate(bullets[WhichGun], bulletHole[WhichHole].position, bullets[WhichGun].transform.rotation);

//            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
//            bulletRigidbody.AddForce(Vector2.up * force);
//            Destroy(newBullet, 2f);
//        }
//        else
//        {
//            GameObject newBullet = Instantiate(bullets[WhichGun], bulletHole[WhichHole].position, bullets[WhichGun].transform.rotation);

//            // Kuvvet uygulamak yerine sadece pozisyonu ayarlayabilirsiniz.
//            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Kuvveti sıfırla
//            newBullet.GetComponent<Rigidbody2D>().isKinematic = true; // Kinetik olmayan (hareketsiz) bir rigidbody yap

//            float destroyTime = (WhichGun == 0) ? bulletDestroyTime : destroyTimeForGun1;

//            // Kuvvet parametresini kontrol et ve ona göre uygula
//            if (customForce != 0f)
//            {
//                newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * customForce);
//            }

//            Destroy(newBullet, destroyTime);
//        }
//    }


//    public void ChangeGun(int GunNumber)
//    {
//        WhichGun = GunNumber;
//        if (WhichGun == 0 || WhichGun == 1)
//        {
//            StartCoroutine(ResetWhichGunCoroutine());
//        }
//    }

//    private void OnEnable()
//    {
//        controls.Enable();
//    }

//    private void OnDisable()
//    {
//        controls.Disable();
//    }
//}



using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private AudioSource ropeSound;
    [SerializeField] private Transform[] bulletHole;
    [SerializeField] private float force = 400;
    [SerializeField] public int SelectedWeaponIndex = 0;
    [SerializeField] public int SelectedBulletHoleIndex = 0;
    private Transform firstHoleTransform;

    private bool isRopeSoundOn;
    //private bool oneShoot = true;

    private const float bulletDestroyTime = 1.1f;
    private const int destroyTimeForGun1 = 15;
    private const float resetSelectedWeaponWaitTime = 10f;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Shoot.performed += ctx => Fire();
    }

    private void Start()
    {
        firstHoleTransform = bulletHole[0];
        SelectedWeaponIndex = 0;
        SelectedBulletHoleIndex = 0;
    }

    public IEnumerator ResetSelectedWeaponCoroutine()
    {
        yield return new WaitForSeconds(resetSelectedWeaponWaitTime);
        SelectedWeaponIndex = 0;
        SelectedBulletHoleIndex = 0;
    }

    public void Fire()
    {
        isRopeSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;

        if (isRopeSoundOn && ropeSound != null)
        {
            ropeSound.Play();
        }
        //-----------------------------------------------------------------------------

        if (SelectedWeaponIndex == 0 || SelectedWeaponIndex == 1)
        {
            bulletHole[0] = firstHoleTransform;
            GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");
            if (existingBullet != null)
            {
                Destroy(existingBullet);
            }

            Shoot(SelectedBulletHoleIndex, SelectedWeaponIndex);
        }

        //---------------------------------------------------------------------------
        else if (SelectedWeaponIndex == 2)
        {

            Shoot(0, 2, 400f);
            Debug.Log("Silah ateşlensin");
        }
        else if (SelectedWeaponIndex == 3)
        {
            Shoot(1, 3, 0);

        }
        else
        {
            Debug.Log("BulletHole Index" + SelectedBulletHoleIndex + "____Bullet Index" + SelectedWeaponIndex);
        }
    }



    public void Shoot(int selectedBulletHoleIndex, int selectedWeaponIndex, float customForce = 400f)
    {
        if (selectedWeaponIndex == 0 || selectedWeaponIndex == 1)
        {
            GameObject newBullet = Instantiate(bullets[selectedWeaponIndex], bulletHole[selectedBulletHoleIndex].position, bullets[selectedWeaponIndex].transform.rotation);

            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(Vector2.up * force);

            float destroyTime = (selectedWeaponIndex == 0) ? bulletDestroyTime : destroyTimeForGun1;
            Destroy(newBullet, destroyTime);
        }
        else if (selectedWeaponIndex == 2)
        {
            bulletHole[selectedBulletHoleIndex].position = GameObject.FindGameObjectWithTag("GroundLaserHole").transform.position;

            Debug.Log("laser gelicek");
            GameObject newBullet = Instantiate(bullets[selectedWeaponIndex], bulletHole[selectedBulletHoleIndex].position, bullets[selectedWeaponIndex].transform.rotation);

            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(Vector2.up * force);
            Debug.Log("Silah Ateşlendi");
            Destroy(newBullet, 1.5f);



        }
        else if (selectedWeaponIndex == 3)
        {

            GameObject newBullet = Instantiate(bullets[selectedWeaponIndex], bulletHole[selectedBulletHoleIndex].position, bullets[selectedWeaponIndex].transform.rotation);

            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = Vector2.zero;
            bulletRigidbody.isKinematic = true;
            SelectedWeaponIndex = 2;
            Debug.Log("Laser eklendi");
            Debug.Log("Seçili silah indexi" + SelectedWeaponIndex);


        }
        else { Debug.Log("BulletHole Index" + selectedBulletHoleIndex + "____Bullet Index" + selectedWeaponIndex); }
    }

    public void ChangeWeapon(int weaponNumber)
    {
        SelectedWeaponIndex = weaponNumber;
        if (SelectedWeaponIndex != 3 || SelectedWeaponIndex != 2)
            StartCoroutine(ResetSelectedWeaponCoroutine());
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
