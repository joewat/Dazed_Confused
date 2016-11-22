using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour
{

	public Transform target;

	void Update ()
	{
		float angH = Input.GetAxis (this.GetComponent<PlayerControls> ().rightH) * -1;
		float angV = Input.GetAxis (this.GetComponent<PlayerControls> ().rightV) * -1;
		if (angH != 0 || angV != 0) {
			target.eulerAngles = new Vector3 (0, 0, ((Mathf.Atan2 (angH, angV) * (180 / Mathf.PI))));
		}
			
		float deadzone = 0.25f;
		Vector2 stickInput = new Vector2 (angH, angV);
		if (stickInput.magnitude < deadzone)
			stickInput = Vector2.zero;
		else
			stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));

	}
}