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

//	public void OnCollisionEnter2D(Collision2D coll) {
//		Debug.Log ("1");
//
//		if (coll.gameObject.CompareTag("Projectile")) {
//			Debug.Log ("2");
//
//			if (coll.gameObject.comp
//				GetComponent<aoeBullet>().expand == true) {
//				Debug.Log ("3");
//
//				Physics2D.IgnoreCollision (GetComponent<Collider2D> (), coll.gameObject.GetComponent<Collider2D>());
//			}
//		}
//	}

}