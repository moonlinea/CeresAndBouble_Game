using UnityEngine;

public class ChainCollision : MonoBehaviour {
	

	void OnTriggerEnter2D (Collider2D col)
	{
        Ball ballComponent = col.GetComponent<Ball>();
        if (col.tag == "Ball")
		{
			if (ballComponent != null)
			{
                col.GetComponent<Ball>().Split();
            }
		
			Destroy(gameObject);
		
		}
	}
	


}
