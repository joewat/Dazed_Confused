using UnityEngine;
using System.Collections;

public class GrenadeFire : MonoBehaviour
{

	public GameObject grenade;
	public Transform bulletSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		// Update timer.
		this.nextFire -= Time.deltaTime;

		// Fire on button press.
		if (Input.GetButton (this.GetComponent<PlayerControls> ().special) && nextFire < 0 && !this.GetComponent<PlayerMovement>().IsStunned()) {
			this.nextFire = this.fireRate;
			Instantiate (grenade, bulletSpawn.position, bulletSpawn.rotation);
		}
	}
}
