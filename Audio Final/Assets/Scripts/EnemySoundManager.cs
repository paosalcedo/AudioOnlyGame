using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour {

	AudioSource voiceOver;

	[SerializeField] private AudioClip[] voiceClips;

	void Start () {
		voiceOver = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponentInParent<AudioSource>().volume > 0.5f && !voiceOver.isPlaying) {
			PlayVoiceOver(); 
		}
	}


	void PlayVoiceOver(){
		int n = Random.Range(1, voiceClips.Length);
		voiceOver.clip = voiceClips[n];
		voiceOver.PlayOneShot(voiceOver.clip);
		
		voiceClips[n] = voiceClips[0];
		voiceClips[0] = voiceOver.clip;
	}

}
