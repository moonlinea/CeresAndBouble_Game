using UnityEngine;

public class ChainCollision : MonoBehaviour
{
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
    }
}
