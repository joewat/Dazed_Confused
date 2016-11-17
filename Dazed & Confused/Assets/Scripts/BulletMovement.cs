using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float speed;
	public int playerID;

	void Start ()
	{
		// Initialize bullet movement speed.
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = transform.up * speed;	
	}

}