using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	
	private Rigidbody2D rigidbody2d;

	public float speed;

	private float stunned;
	private float invincible;

	void Start ()
	{
		// Freeze rotation caused by physics.
		this.rigidbody2d = GetComponent<Rigidbody2D> ();
		this.rigidbody2d.freezeRotation = true;
	}

	void Update ()
	{
		// Update timers.
		this.stunned -= Time.deltaTime;
		this.invincible -= Time.deltaTime;

		// Move player only if not stunned.
		if (!this.IsStunned()) {
			float moveHorizontal = Input.GetAxis (this.GetComponent<PlayerControls> ().leftH);
			float moveVertical = Input.GetAxis (this.GetComponent<PlayerControls> ().leftV);
			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
			this.rigidbody2d.velocity = movement * speed;
		} else {
			this.rigidbody2d.velocity = new Vector2 (0, 0);
		}

		// Start invincibility.
		if (this.stunned < 0 && this.stunned + Time.deltaTime > 0) {
			StartInvincible (1);
		}
	}
		
	public void StartStun(int seconds) {
		if (!this.IsStunned() && !this.IsInvincible()) {
			this.stunned = seconds;
		}
	}

	public bool IsStunned() {
		return this.stunned > 0;
	}

	public void StartInvincible(int seconds) {
		this.invincible = seconds;
	}

	public bool IsInvincible() {
		return this.invincible > 0;
	}
}
