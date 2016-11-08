using UnityEngine;
using System.Collections;

public class DummyCollision : MonoBehaviour
{
	public bool stun;
	public float stunTime;

	private float stunEnd;
    public int playerID;
    public Boundary boundary;
	private Rigidbody2D rigidbody2d;

	void Start ()
	{
		stun = false;
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		foreach (ContactPoint2D c in coll.contacts) {
			if (c.collider.name == "Bullet(Clone)") {
				Destroy (coll.gameObject);
				if (!stun) {
					stun = true;
					stunEnd = Time.time + stunTime;
				}
				;
			}

			if (c.collider.name == "Melee" + playerID) {
				Destroy (this.gameObject);
			}
		}
	}

	void Update ()
	{
		if (Time.time > stunEnd) {
			stun = false;
		}
	}

	void FixedUpdate ()
	{
		rigidbody2d.position = new Vector2 (
			Mathf.Clamp (rigidbody2d.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody2d.position.y, boundary.yMin, boundary.yMax)
		);
	}
}