using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour
{
	
	private Rigidbody2D rigidbody2d;

	public float speed;
	public Boundary boundary;

	public bool stun;
	public float stunTime;

	private float stunEnd;

	void Start ()
	{
		// Initialize variables.
		stun = false;
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Loop through all the collisions that happened.
		foreach (ContactPoint2D c in coll.contacts) {

			// If collided with bullet, then stun.
			if (c.collider.name == "Bullet(Clone)") {
				Destroy (coll.gameObject);
				if (!stun) {
					stun = true;
					stunEnd = Time.time + stunTime;
				}
			}

			// If collided with melee, then destroy.
			if (c.collider.name == "Melee") {
				Destroy (this.gameObject);
			}
		}
	}

	void Update ()
	{

		// Unstun after certain amount of time.
		if (Time.time > stunEnd) {
			stun = false;
		}

		// Movement stuff (only if not stunned!)
		if (!stun) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
			rigidbody2d.velocity = movement * speed;
		}

//		rigidbody2d.position = new Vector2 (
//			Mathf.Clamp (rigidbody2d.position.x, boundary.xMin, boundary.xMax),
//			Mathf.Clamp (rigidbody2d.position.y, boundary.yMin, boundary.yMax)
//		);
	}
}
