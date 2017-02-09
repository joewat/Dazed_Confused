using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour {

	public AudioClip Placeholder_Gunfire;
	public AudioClip Placeholder_Dash;
	AudioSource audio;


	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	public void Play_fire () {
		audio.PlayOneShot (Placeholder_Gunfire, 1f);
	}

	public void Play_dash () {
		audio.PlayOneShot (Placeholder_Dash, 1f);
	}
}