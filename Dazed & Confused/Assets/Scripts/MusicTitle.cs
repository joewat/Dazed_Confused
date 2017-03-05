using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTitle : MonoBehaviour {

	public AudioClip Music;
	AudioSource audio; 

	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.Play (Music, 1f);
	}
}