using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {
	
	public GameObject melee;
	public bool active;
	public float activeTime;

	private float activeEnd;

	void Start () {
		// Set melee object to inactive.
		melee.SetActive(false);
	}

	void Update() {

		// Activate melee on button press.
		if (Input.GetButton ("Fire2") && Time.time > activeTime) {
			melee.SetActive (true);
			active = true;
			activeEnd = Time.time + activeTime;
		}

		// Set melee object to inactive after certain amount of time.
		if (Time.time > activeEnd)
		{
			melee.SetActive(false);
			active = false;
		}
	}

}
