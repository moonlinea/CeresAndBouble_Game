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
    [SerializeField] public int WhichGun = 0;
    [SerializeField] public int WhichHole = 0;

    private bool isRopeSoundOn;

    private const float bulletDestroyTime = 1.1f;
    private const int destroyTimeForGun1 = 15;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Shoot.performed += ctx => Fire();
    }

    private void Start()
    {
        WhichGun = 0;
        WhichHole = 0;
    }

    private IEnumerator ResetWhichGunCoroutine()
    {
        yield return new WaitForSeconds(10f);
        WhichGun = 0;
        WhichHole = 0;
    }

    public void Fire()
    {
        isRopeSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
        if (isRopeSoundOn) ropeSound.Play();

        GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");

        if (existingBullet != null)
        {
            Destroy(existingBullet);
        }

        if (WhichGun == 2)
        {
            WhichHole = 1;
        }

        GameObject newBullet = Instantiate(bullets[WhichGun], bulletHole[WhichHole].position, bullets[WhichGun].transform.rotation);

        Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(Vector2.up * force);

        if (WhichGun == 0)
        {
            Destroy(newBullet, bulletDestroyTime);
        }
        else if (WhichGun == 1 || WhichGun==2)
        {
            Destroy(newBullet, destroyTimeForGun1);
        }
     
    }
  

    public void ChangeGun(int GunNumber)
    {
        WhichGun = GunNumber;
        StartCoroutine(ResetWhichGunCoroutine());
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
