using UnityEngine;
using System.Collections;

public class aoeBullet : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;

	public float speed;
	public int playerID;

    public float cooldown;
    public bool expand;
    public float expandTime;
    public float expandScale;

    private float nextBullet;
    private float expandEnd;

	void Start ()
	{
		// Initialize bullet movement speed and Timer
		rigidbody2d = GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = transform.up * speed;
        nextBullet = Time.time + cooldown;
    }

    void Update() {
        // aoeBullet assignment and cooldown.
        if (Input.GetButton("test") && Time.time > nextBullet)
        {
            expand = true;
            rigidbody2d.velocity = transform.up * 0;
            expandEnd = Time.time + expandTime;
        }

        // AOE Expansion
        if (expand == true) {
            transform.localScale = new Vector3(expandScale, expandScale, expandScale);
        }

        // Post Explosion
        if (Time.time > expandEnd) {
            expand = false;
            Destroy(this);
        }
    }
}