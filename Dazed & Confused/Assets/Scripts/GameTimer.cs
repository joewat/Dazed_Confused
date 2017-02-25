using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		// Timer
		this.time -= Time.deltaTime;

		print (string.Format ("{0:0}:{1:00}", Mathf.Floor(this.time/60) , Mathf.Floor(this.time)%60) + " " + this.time );
	}
}