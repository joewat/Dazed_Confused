using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float speed;

	void Start ()
	{
		// Initialize bullet movement speed.
		this.rigidbody2d = GetComponent<Rigidbody2D> ();
		this.rigidbody2d.velocity = transform.up * this.speed;	
	}

	public void OnTriggerEnter2D (Collider2D coll)
	{
		// Get collided game object.
		GameObject go = coll.gameObject;

		// Check tag of collided object.
		if (go.tag == "Player") {
			if (!go.GetComponent<PlayerMovement> ().IsInvincible ()) {
				go.GetComponent<PlayerMovement> ().StartStun (2);
			}
			Destroy (this.gameObject);
		} else if (go.tag == "Wall") {
			Destroy (this.gameObject);
		}
	}
}