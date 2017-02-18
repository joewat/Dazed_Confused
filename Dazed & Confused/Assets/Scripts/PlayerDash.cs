using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float dashSpeed;
	public float dashCooldown;

	private float nextDash;

	void Start ()
	{
		// Initialize variables.
		this.rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		// Update timers.
		this.nextDash -= Time.deltaTime;

		// Get dash direction.
		float moveHorizontal = Input.GetAxis (this.GetComponent<PlayerControls> ().leftH);
		float moveVertical = Input.GetAxis (this.GetComponent<PlayerControls> ().leftV);
		moveHorizontal = moveHorizontal > 0 ? 1 : moveHorizontal < 0 ? -1 : 0;
		moveVertical = moveVertical > 0 ? 1 : moveVertical < 0 ? -1 : 0;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		// Dash assignment and cooldown.
		if (Input.GetButton (this.GetComponent<PlayerControls> ().dash) && (moveHorizontal != 0 || moveVertical != 0) &&
		    this.nextDash < 0 && !this.GetComponent<PlayerMovement> ().IsStunned ()) {
			this.nextDash = dashCooldown;
			this.GetComponent<PlayerSFX> ().PlayDash ();
			this.rigidbody2d.AddForce (movement * dashSpeed);
		}

       
	}
}