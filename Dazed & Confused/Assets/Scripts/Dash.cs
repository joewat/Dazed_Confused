using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public bool dash;
	public float dashSpeed;
	public float dashTime;
	public float cooldown;
	public int playerID;

	private float dashEnd;
	private float nextDash;

	void Start ()
	{
		// Initialize variables.
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		// Dash assignment and cooldown.
		if (Input.GetButton (this.GetComponent<PlayerControls> ().dash) && Time.time > nextDash) {
			dash = true;
			dashEnd = Time.time + dashTime;
			nextDash = Time.time + cooldown;
		}

		// Dashing state.
		if (dash == true) {
			rigidbody2d.AddForce (rigidbody2d.velocity * dashSpeed);
		}

		// Set dash to inactive after certain amount of time.
		if (Time.time > dashEnd) {
			dash = false;
		}        
	}
}