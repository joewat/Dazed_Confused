using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, yMin, yMax;
}

public class Movement2D : MonoBehaviour {
	
	private Rigidbody2D rigidbody2d;

	public float speed;
	public Boundary boundary;

	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;

	private float nextFire;

	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2d.velocity = movement * speed;

		rigidbody2d.position = new Vector2
		(
			Mathf.Clamp (rigidbody2d.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody2d.position.y, boundary.yMin, boundary.yMax)
		);
	}
}
