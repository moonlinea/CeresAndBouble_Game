using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLaserController : MonoBehaviour
{
    public PlayerShoot playerShoot;
    // Start is called before the first frame update
    private void Start()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();
    }
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerShoot.GetGroundLaser(true); 


        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            playerShoot.GetGroundLaser(false);
        }
    }
    public void DestroyGroundLaser()
    {
        Destroy(gameObject);
    }
}
