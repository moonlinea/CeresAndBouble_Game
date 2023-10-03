using UnityEngine;

public class ChainCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Ball")
		{
			col.GetComponent<Ball>().Split();
			
			Destroy(gameObject);
		}
	}

}
