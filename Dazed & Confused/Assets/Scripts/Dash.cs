using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public bool dash;
	public float dashSpeed;
	public float dashTime;
	public float cooldown;

	private float dashEnd;
	private float nextDash;

	void Start ()
	{
		// Initialize variables.
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxis (this.GetComponent<PlayerControls> ().leftH);
		float moveVertical = Input.GetAxis (this.GetComponent<PlayerControls> ().leftV);
		moveHorizontal = moveHorizontal > 0 ? 1 : moveHorizontal < 0 ? -1 : 0;
		moveVertical = moveVertical > 0 ? 1 : moveVertical < 0 ? -1 : 0;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		// Dash assignment and cooldown.
		if (Input.GetButton (this.GetComponent<PlayerControls> ().dash) && (moveHorizontal != 0 || moveVertical != 0) && Time.time > nextDash && !this.gameObject.GetComponent<PlayerMovement> ().stun) {
			dash = true;
			dashEnd = Time.time + dashTime;
			nextDash = Time.time + cooldown;
			this.gameObject.GetComponent<PlayerSFX> ().Play_dash ();
			rigidbody2d.AddForce (movement * dashSpeed);
		}

		// Dashing state.
		if (dash == true) {
			
		}

		// Set dash to inactive after certain amount of time.
		if (Time.time > dashEnd) {
			dash = false;
		}        
	}
}