using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour {

	public AudioClip Fire;
	public AudioClip Dash;
	public AudioClip MeleeMiss;
	public AudioClip MeleeHit;
	public AudioClip Footsteps;
	AudioSource audio;


	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	public void PlayFire () {
		audio.PlayOneShot (Fire, 1f);
	}

	public void PlayDash () {
		audio.PlayOneShot (Dash, 1f);
	}

	public void PlayMeleeMiss () {
		audio.PlayOneShot (MeleeMiss, 1f);
	}

	public void PlayMeleeHit () {
		audio.PlayOneShot (MeleeHit, 1f);
	}

	public void PlayFootsteps () {
		audio.PlayOneShot (Footsteps, 5f);
	}
}