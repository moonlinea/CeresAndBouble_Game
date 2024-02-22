using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] bullets;
    public AudioSource[] ropeSound = new AudioSource[2]; // 5 elemanlı bir dizi olarak örnek olarak
    [SerializeField] private Transform[] bulletHole;
    [SerializeField] private float force = 400;
    [SerializeField] public int SelectedWeaponIndex = 0;
    [SerializeField] public int SelectedBulletHoleIndex = 0;
    public GroundLaserController groundLaserController;
    float destroyTime;
    private bool isRopeSoundOn;
    private int bulletLenght;
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
        SelectedWeaponIndex = 0;
        SelectedBulletHoleIndex = 0;
        groundLaserController = FindObjectOfType<GroundLaserController>();

    }

    public IEnumerator ResetSelectedWeaponCoroutine()
    {
        yield return new WaitForSeconds(resetSelectedWeaponWaitTime);
        SelectedWeaponIndex = 0;
        SelectedBulletHoleIndex = 0;
    }

    public void GetGroundLaser(bool isGetGorundLaser)
    {
        if (isGetGorundLaser)
        {
            SelectedWeaponIndex = 4;
            SelectedBulletHoleIndex = 1;


        }
        else SelectedWeaponIndex = 2;

    }

    public void Fire()
    {
       
        //-----------------------------------------------------------------------------
        if (SelectedWeaponIndex == 0 || SelectedWeaponIndex == 1)
        {
            GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");
            if (existingBullet != null)
            {
                Destroy(existingBullet);
            }

            Shoot(0, SelectedWeaponIndex);
        }

        //---------------------------------------------------------------------------
        else if (SelectedWeaponIndex == 2)
        {
            Shoot(2, 2, 400f);
        }

        else if (SelectedWeaponIndex == 3)
        {
            Shoot(1, 3, 0);

        }
        else if (SelectedWeaponIndex == 4)
        {
            Shoot(0, 4, 0);
        }
        else
        {
            Debug.Log("BulletHole Index" + SelectedBulletHoleIndex + "____Bullet Index" + SelectedWeaponIndex);
        }


    }



    public void Shoot(int selectedBulletHoleIndex, int selectedWeaponIndex, float customForce = 400f)
    {
        isRopeSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;

        if (isRopeSoundOn && ropeSound != null)
        {
            if (selectedWeaponIndex == 0) ropeSound[0].Play();
            else ropeSound[1].Play();

        }
        if (selectedWeaponIndex == 0 || selectedWeaponIndex == 1)
        {

            GameObject newBullet = Instantiate(bullets[selectedWeaponIndex], bulletHole[selectedBulletHoleIndex].position, bullets[selectedWeaponIndex].transform.rotation);

            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(Vector2.up * force);


            if (selectedWeaponIndex == 0)
            {
                destroyTime = bulletDestroyTime;

            }
            else destroyTime = destroyTimeForGun1;

            Destroy(newBullet, destroyTime);
        }
        else if (selectedWeaponIndex == 2)
        {
            if (CountObjectsWithTag("Bullet") != 3)
            {
                bulletHole[selectedBulletHoleIndex].position = GameObject.FindGameObjectWithTag("GroundLaserHole").transform.position;

                GameObject newBullet = Instantiate(bullets[selectedWeaponIndex], bulletHole[selectedBulletHoleIndex].position, bullets[selectedWeaponIndex].transform.rotation);

                Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
                bulletRigidbody.AddForce(Vector2.up * force);
                Destroy(newBullet, 1f);
            }
            else Debug.Log("YAVAŞŞŞŞ");     
            
           

        }
        else if (selectedWeaponIndex == 3)
        {

            GameObject newBullet = Instantiate(bullets[selectedWeaponIndex], bulletHole[selectedBulletHoleIndex].position, bullets[selectedWeaponIndex].transform.rotation);
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = Vector2.zero;
            bulletRigidbody.isKinematic = true;
            SelectedWeaponIndex = 2;


        }
        else if (selectedWeaponIndex == 4)
        {
            Destroy(GameObject.FindGameObjectWithTag("GroundLaserHole"));
            SelectedWeaponIndex = 3;



        }
        else { Debug.Log("BulletHole Index" + selectedBulletHoleIndex + "____Bullet Index" + selectedWeaponIndex); }
    }

    public int  CountObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        int objectCount = objectsWithTag.Length;
        return objectCount;
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
