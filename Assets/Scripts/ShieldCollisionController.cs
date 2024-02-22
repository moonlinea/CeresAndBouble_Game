using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisionController : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        // Objeye bağlı Animator bileşenini alıyoruz
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball" || col.tag == "Obstacles")
        {
           
                ShieldController shieldController = FindObjectOfType<ShieldController>();

                shieldController.Deactivate();

                Debug.Log("Shield açık");

            animator.SetBool("ShieldClosing", true);
           
        }
      
    }
}
