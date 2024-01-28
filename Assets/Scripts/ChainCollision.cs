using UnityEngine;

public class ChainCollision : MonoBehaviour
{
    private PlayerShoot playerShoot;
    int whichGun;
    private void Start()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();
        whichGun = playerShoot.WhichGun;
        
        Debug.Log(whichGun);
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
        Ball ballComponent = otherCollider.GetComponent<Ball>();
        if (otherCollider.CompareTag("Ball") || otherCollider.CompareTag("Obstacles"))
        {
            if (ballComponent != null)
            {
                otherCollider.GetComponent<Ball>().Split();
            }

            Destroy(gameObject);
        }
        if (otherCollider.CompareTag("Ceiling"))
        {if(whichGun == 1) { 
            Rigidbody2D bulletRigidbody = GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = Vector2.zero;
        }
        
        }

    }
}
