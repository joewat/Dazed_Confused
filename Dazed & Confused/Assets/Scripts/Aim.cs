using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour
{

	private Vector3 mouse_pos;
	public Transform target;
	private Vector3 object_pos;
	private float angle;
	float sensitivityX;
	float sensitivityY;
	public float angH;
	public float angV;


	void Update ()
	{
		angH = Input.GetAxis ("RightH") * -1;
		angV = Input.GetAxis ("RightV") * -1;
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