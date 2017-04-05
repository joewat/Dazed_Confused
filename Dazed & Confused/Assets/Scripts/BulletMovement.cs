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

		if (go.name == "Melee" &&
			((this.name == "BlueBullet(Clone)" && go.name != "Player (1)") || (this.name == "RedBullet(Clone)" && go.name != "Player (2)"))
		) {
			go.SetActive (false);
			go.transform.parent.gameObject.GetComponent<PlayerMovement> ().StartInvincible (0.5f);
			this.gameObject.name = this.gameObject.name == "BlueBullet(Clone)" ? "RedBullet(Clone)" : "BlueBullet(Clone)";
			this.rigidbody2d.velocity = transform.up * -this.speed;
			//			go.transform.parent.gameObject.GetComponent<BulletFire> ().Fire (new Quaternion(
//				this.gameObject.transform.rotation.x * 1.0f,
//				this.gameObject.transform.rotation.y * -1.0f,
//				this.gameObject.transform.rotation.z * -1.0f,
//				this.gameObject.transform.rotation.w * 1.0f
//			));
//			Destroy (this.gameObject);
		}

		// Check tag of collided object.
		if (go.tag == "Player") {
			if (!go.GetComponent<PlayerMovement> ().IsInvincible () && 
				((this.name == "BlueBullet(Clone)" && go.name != "Player (1)") || (this.name == "RedBullet(Clone)" && go.name != "Player (2)"))
			) {
				go.GetComponent<PlayerMovement> ().StartStun (2);
			}
			Destroy (this.gameObject);
		} else if (go.tag == "Wall") {
			Destroy (this.gameObject);
		}
	}
}