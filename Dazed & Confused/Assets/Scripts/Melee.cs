using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
	
	public GameObject melee;
	public bool active;
	public float activeTime;
	public float cooldown;

	private float activeEnd;
	private float nextActive;

	void Start ()
	{
		// Set melee object to inactive.
		melee.SetActive (false);
	}

	void Update ()
	{

		// Activate melee on button press.
		if (Input.GetAxis (this.GetComponent<PlayerControls> ().melee) > 0 && Time.time > nextActive) { 
			active = true;
			activeEnd = Time.time + activeTime;
			nextActive = Time.time + cooldown;
		}

		// Melee cooldown.
		if (active == true) {
			melee.SetActive (true);
		}
        
		// Set melee object to inactive after certain amount of time.
		if (Time.time > activeEnd) {
			melee.SetActive (false);
			active = false;
		}
	}

}
