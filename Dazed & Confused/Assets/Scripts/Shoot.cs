using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private Rigidbody2D rigidbody2d;

	public float speed;

	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = transform.up * speed;	
	}
}
