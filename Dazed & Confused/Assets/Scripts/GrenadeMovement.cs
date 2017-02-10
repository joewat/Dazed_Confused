using UnityEngine;
using System.Collections;

public class GrenadeMovement : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float speed;
	public int playerID;

	public float cooldown;
	public bool expand;
	public float expandTime;
	public float expandScale;

	private float nextBullet;
	private float expandEnd;

	public Transform bulletPrefab;

	void Start ()
	{
		// Initialize bullet movement speed and Timer
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = transform.up * speed;
		nextBullet = Time.time + cooldown;
	}

	void Update ()
	{
		// aoeBullet assignment and cooldown.
		if (Time.time > nextBullet && !expand) {
			startExpand ();
		}

		// AOE Expansion
		if (expand) {
			transform.localScale = new Vector3 (expandScale, expandScale, expandScale);
		}

		// Post Explosion
		if (expand && Time.time > expandEnd) {
			Destroy (this.gameObject);
		}
	}

	public void OnTriggerEnter2D (Collider2D coll)
	{

		switch (coll.gameObject.layer) {
		case 8: // Player Layer
			coll.gameObject.GetComponent<PlayerMovement> ().startStun ();
			startExpand ();
			break;
		case 10: // Wall Layer
			rigidbody2d.velocity = transform.up * 0;
			break;
		}

	}

	public void startExpand ()
	{
		expand = true;
		rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
		rigidbody2d.velocity = transform.up * 0;
		expandEnd = Time.time + expandTime;
	}
}