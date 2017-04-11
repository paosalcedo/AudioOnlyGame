using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitSoundScript : MonoBehaviour {
	AudioSource hitSound;
	
 	// Use this for initialization
	
	
//	public static EnemyHitSoundScript instance;

	void Start () {
		hitSound = GetComponent<AudioSource>();
//		if (instance == null) {
//			instance = this;
//			DontDestroyOnLoad (this);
//		} else {
//			Destroy(gameObject);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayHitSound(){
		hitSound.panStereo = AttackScript.instance.attackPan;
		hitSound.Play();

//		  int n = Random.Range(1, collideSounds.Length);
//            hitSound.clip = collideSounds[n];
//            hitSound.PlayOneShot(hitSound.clip);
//            // move picked sound to index 0 so it's not picked next time
//            collideSounds[n] = collideSounds[0];
//            collideSounds[0] = collide.clip;
	}
}
