﻿using UnityEngine;
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
		if (Input.GetAxis (this.GetComponent<PlayerControls> ().shoot) > 0 && Time.time > nextFire) { 
			nextFire = Time.time + fireRate;
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
			this.gameObject.GetComponent<PlayerSFX> ().Play_fire ();
		}
	}
}