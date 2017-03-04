using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour
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
		if (Input.GetAxis (this.GetComponent<PlayerControls> ().melee) > 0 && Time.time > nextActive && !this.GetComponent<PlayerMovement>().IsStunned()) {
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

	void OnTriggerEnter2D (Collider2D coll) {
		// Get collided game object.
		GameObject go = coll.gameObject;

		// Check tag of collided object.
		if (go.tag == "Player") {
			if (go.GetComponent<PlayerMovement> ().IsStunned()) {
				go.GetComponent<PlayerRespawn> ().Respawn ();
				this.gameObject.GetComponent<PlayerData> ().incrementScore();
			}
		}
	}


}