using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform bulletHole;
    [SerializeField] private float force = 400;
    [SerializeField] public int WhichGun = 0;

    private const float bulletDestroyTime = 1.1f;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Shoot.performed += ctx => Fire();
    }

    private IEnumerator ResetWhichGunCoroutine()
    {
        yield return new WaitForSeconds(3f);
        WhichGun = 0;
    }

    void Fire()
    {
        // animator.SetTrigger("shoot");

        GameObject existingBullet = GameObject.FindGameObjectWithTag("Bullet");

        if (existingBullet != null)
        {
            Destroy(existingBullet);
        }

        GameObject newBullet = Instantiate(bullets[WhichGun], bulletHole.position, bullets[WhichGun].transform.rotation);

        Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(Vector2.up * force);

        Destroy(newBullet, bulletDestroyTime);
    }

    public void ChangeGun(int GunNumber)
    {
        WhichGun = 1;
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
