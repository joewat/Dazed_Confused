using UnityEngine;
using System.Collections;

public class BulletFire : MonoBehaviour
{

	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		// Update timer.
		this.nextFire -= Time.deltaTime;

		// Fire on button press.
		if (Input.GetAxis (this.GetComponent<PlayerControls> ().shoot) > 0 && nextFire < 0 && !this.GetComponent<PlayerMovement>().IsStunned()) {
			this.nextFire = this.fireRate;
			Instantiate (this.bullet, this.bulletSpawn.position, this.bulletSpawn.rotation);
			this.GetComponent<PlayerSFX> ().PlayFire ();
		}
	}
}
