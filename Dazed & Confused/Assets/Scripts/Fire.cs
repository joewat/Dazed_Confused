using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		// Fire on button press.
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}
}
