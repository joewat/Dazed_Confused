using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float speed;

	void Start ()
	{
		// Initialize bullet movement speed.
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = transform.up * speed;	
	}

	public void OnTriggerEnter2D(Collider2D coll) {

		switch (coll.gameObject.layer) {
		case 8: // Player Layer
			coll.gameObject.GetComponent<PlayerMovement> ().startStun ();
			Destroy (this.gameObject);
			break;
		case 10: // Wall Layer
			Destroy (this.gameObject);
			break;
		}
	}
}