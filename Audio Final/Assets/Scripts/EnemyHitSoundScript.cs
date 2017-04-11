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
	}
}
