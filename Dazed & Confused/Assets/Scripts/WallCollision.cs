using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Loop through all the collisions that happened.
		foreach (ContactPoint2D c in coll.contacts) {

			// If collided with wall, then destroy.
			if (c.collider.name == "Bullet(Clone)") {
				Destroy (coll.gameObject);
			}
		}
	}
}
