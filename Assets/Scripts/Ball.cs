using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialForce;
    [SerializeField] private GameObject nextBallPrefab;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] public GameObject particleSystemPrefab;

    private void Start()
    {
        rigidBody.AddForce(initialForce, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if (nextBallPrefab != null)
        {
            GameObject ball1 = Instantiate(nextBallPrefab, rigidBody.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBallPrefab, rigidBody.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<Ball>().initialForce = new Vector2(2f, 3f);
            ball2.GetComponent<Ball>().initialForce = new Vector2(-2f, 3f);

            GameObject particleInstance = Instantiate(particleSystemPrefab, rigidBody.position, Quaternion.identity);
            particleInstance.GetComponent<ParticleSystem>().Play();

            DropItemController[] dropItemControllers = FindObjectsOfType<DropItemController>();
            foreach (DropItemController dropItemController in dropItemControllers)
            {
                dropItemController.DropItems(rigidBody.position);
            }
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacles")
        {
            Split();
        }
    }
}
