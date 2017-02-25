using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	private float time;
	public float initialTime;

	// Use this for initialization
	void Start () {
		this.time = initialTime;
	}

	void Update () {

		// Timer
		this.time -= Time.deltaTime;
		GameObject.Find ("Timer").GetComponent<Text> ().text = "Time: " + string.Format ("{0:0}:{1:00}", Mathf.Floor (this.time / 60), Mathf.Floor (this.time) % 60);

		// Player Score
		GameObject.Find ("Player 1").GetComponent<Text> ().text = "Player 1: " + GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score.ToString();
		GameObject.Find ("Player 2").GetComponent<Text> ().text = "Player 2: " + GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score.ToString();


		if (this.time < 0) {
			this.time = initialTime;
			GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score = 0;
			GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score = 0;
		}
	}
}