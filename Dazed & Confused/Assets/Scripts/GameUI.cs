using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	private float time;
	public float initialTime;

	public GameObject gameOverUI;

	public AudioClip bgm;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		this.time = initialTime;
		gameOverUI.SetActive (false);
		audio = GetComponent<AudioSource> ();
		audio.PlayOneShot (bgm, 1f);
	}

	void Update () {

		// Timer
		this.time -= Time.deltaTime;
		GameObject.Find ("Timer").GetComponent<Text> ().text = "Time: " + string.Format ("{0:0}:{1:00}", Mathf.Floor (this.time / 60), Mathf.Floor (this.time) % 60);

		// Player Score
		GameObject.Find ("Player 1").GetComponent<Text> ().text = "Player 1: " + GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score.ToString();
		GameObject.Find ("Player 2").GetComponent<Text> ().text = "Player 2: " + GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score.ToString();


		if (this.time <= 1) {
			this.time = 1;
			this.GameOver ();
			//GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score = GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score.ToString();
			//GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score = GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score.ToString();
		}
	}

	private void GameOver() {
		gameOverUI.SetActive (true);
		//players are stunned when timer ends
		GameObject.Find ("Player (1)").GetComponent<PlayerMovement> ().StartStun (999);
		GameObject.Find ("Player (2)").GetComponent<PlayerMovement> ().StartStun (999);

		//update player scores
		GameObject.Find ("Player 1 Score").GetComponent<Text> ().text = GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score.ToString ();
		GameObject.Find ("Player 2 Score").GetComponent<Text> ().text = GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score.ToString ();

		//if player 2 is the winner
		if (GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score < GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score) {
			GameObject.Find ("Player 1 Results").GetComponent<Text> ().text = "LOSER";
			GameObject.Find ("Player 2 Results").GetComponent<Text> ().text = "WINNER";

		//if game is a draw
		} else if (GameObject.Find ("Player (1)").GetComponent<PlayerData> ().score == GameObject.Find ("Player (2)").GetComponent<PlayerData> ().score) {
			GameObject.Find ("Player 1 Results").GetComponent<Text> ().text = "DRAW";
			GameObject.Find ("Player 2 Results").GetComponent<Text> ().text = "DRAW";
		}
	}
}