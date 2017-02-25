using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public bool death;
	GameObject Player;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		death = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (Player == null && death == false) {
			death = true;
			Instantiate (playerPrefab, new Vector3(-8,3,0), Quaternion.Euler(new Vector3(0, 0, 0)));
		}
	}
}