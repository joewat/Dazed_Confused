using UnityEngine;
using System.Collections;

public class Movement2D : MonoBehaviour {
	
	private Rigidbody2D rigidbody;

	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody.velocity = movement * speed;
	}
}
