using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
	
	public GameObject melee;
	public bool active;
	public float activeTime;
	public float cooldown;
	public int playerID;

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
		if (Input.GetButton (this.GetComponent<PlayerControls> ().melee) && Time.time > nextActive) {
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
