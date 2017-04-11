using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSoundScript : MonoBehaviour {

	AudioSource collide;
	// Use this for initialization

	[SerializeField] private AudioClip[] collideSounds;

	void Start () {
		collide = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayCollideSound ()
	{
		  int n = Random.Range(1, collideSounds.Length);
            collide.clip = collideSounds[n];
            collide.PlayOneShot(collide.clip);
            // move picked sound to index 0 so it's not picked next time
            collideSounds[n] = collideSounds[0];
            collideSounds[0] = collide.clip;
	}
}
