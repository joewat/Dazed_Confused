using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float dashSpeed;

	void Start ()
	{
		// Initialize variables.
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		// Dash on button press.
		if (Input.GetButton ("Fire3")) {
			rigidbody2d.AddForce (rigidbody2d.velocity * dashSpeed);
		}
	}
}
