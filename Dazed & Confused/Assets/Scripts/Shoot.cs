using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private Rigidbody2D rigidbody2d;

	public float speed;

    public Boundary boundary;

    void Start () {
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = transform.up * speed;	
	}

    void Update() {
        if (rigidbody2d.position.x < boundary.xMin || rigidbody2d.position.x > boundary.xMax || rigidbody2d.position.y < boundary.yMin || rigidbody2d.position.y > boundary.yMax) {
            Destroy(this.gameObject);
        }
    }
}