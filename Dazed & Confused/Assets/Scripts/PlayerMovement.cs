﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	
	private Rigidbody2D rigidbody2d;

	public float speed;

	public bool stun;
	public float stunTime;

	private float stunEnd;

	void Start ()
	{
		// Initialize variables.
		stun = false;
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.freezeRotation = true;
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Loop through all the collisions that happened.
		foreach (ContactPoint2D c in coll.contacts) {

			// If collided with bullet, then stun.
			if (c.collider.tag == "Projectile") {
				if (c.collider.name == "Bullet(Clone)") {
					Destroy (coll.gameObject);
				} else {
					print ("hello");
					coll.gameObject.GetComponent<aoeBullet> ().startExpand ();
				}
				if (!stun) {
					stun = true;
					stunEnd = Time.time + stunTime;
				}
			}

			// If collided with melee, then destroy.
			if (c.collider.name == "Melee" && stun == true) {
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
			float moveHorizontal = Input.GetAxis (this.GetComponent<PlayerControls> ().leftH);
			float moveVertical = Input.GetAxis (this.GetComponent<PlayerControls> ().leftV);
			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
			rigidbody2d.velocity = movement * speed;
		} else {
			rigidbody2d.velocity = new Vector2 (0, 0);
		}
	}
}
