using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 startForce;
    [SerializeField] private GameObject nextBall;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if (nextBall != null)
        {
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<Ball>().startForce = new Vector2(2f, 3f);
            ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 3f);

            DropItemController[] dropItemControllers = FindObjectsOfType<DropItemController>();
            foreach (DropItemController dropItemController in dropItemControllers)
            {
                dropItemController.DropItems(rb.position);
            }

        }

        Destroy(gameObject);
    }
}