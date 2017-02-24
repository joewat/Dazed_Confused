using UnityEngine;
using System.Collections;

public class GrenadeMovement : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float speed;
	public float waitTime;
	public float expandTime;
	public float expandScale;

	public Transform grenadePrefab;

	void Start ()
	{
		// Initialize bullet movement speed and Timer
		this.rigidbody2d = GetComponent<Rigidbody2D> ();
		this.rigidbody2d.velocity = transform.up * this.speed;
	}

	void Update ()
	{
		// UpdateTimer
		this.waitTime -= Time.deltaTime;

		// Start expanding after waiting.
		if (this.waitTime < 0) {
			this.rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
			this.rigidbody2d.velocity = transform.up * 0;
			this.expandTime -= Time.deltaTime;
			transform.localScale = new Vector3 (expandScale, expandScale, expandScale);
		}

		// Destroy after expanding.
		if (this.expandTime < 0) {
			Destroy (this.gameObject);
		}
	}

	public void OnTriggerEnter2D (Collider2D coll)
	{
		// Get collided game object.
		GameObject go = coll.gameObject;

		// Check tag of collided object.
		if (go.tag == "Player") {
			go.GetComponent<PlayerMovement> ().StartStun (4);
			this.waitTime = 0;
		} else if (go.tag == "Wall") {
			this.rigidbody2d.velocity = transform.up * 0;
		}
	}
}