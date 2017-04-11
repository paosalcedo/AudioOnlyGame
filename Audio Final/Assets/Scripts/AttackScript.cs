using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	
	public AudioSource basicAttack;
	public float attackPan; 
	public float aimLockTimeReset; 
	bool aimLockOn;
	float aimLockTime;
	public float attackVolume;
	// Use this for initialization
	
	public static AttackScript instance;

	void Start () {
		basicAttack = GetComponent<AudioSource>();	
//		basicAttack.volume = 0;
		aimLockOn = false;
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		BasicAttack ();

		if (!aimLockOn) {
			basicAttack.panStereo = AudioDirector.remapRange (MouseLook.instance.mouseLookX, -90f, 90f, -1f, 1f);
		} else { // only happens for one frame.
			basicAttack.panStereo = attackPan;
		} 

		attackVolume = basicAttack.volume;

		LockAim();
	}

	public bool isFiring;
	bool aimCountdownOn;	

	private void BasicAttack ()
	{
		if (Input.GetMouseButton (0) && !isFiring) {
			basicAttack.Play();
			basicAttack.volume = 1;
			aimLockOn = true;
			aimCountdownOn = true;
			attackPan = basicAttack.panStereo;
			isFiring = true;

			//start aim lock function with a bool.
		} else {
			basicAttack.volume -= 0.5f * Time.deltaTime;
			aimLockOn = false;
		}
	}

//	this bool "projectileIsOut" is an attempt to make the sonic gun sound more like a projectile going farther and farther away from the player. 
	bool projectileIsOut;

	private void LockAim ()
	{
		if (aimCountdownOn == true) {		
			aimLockTime -= Time.deltaTime;
//			projectileIsOut = true;
		}

//		if (projectileIsOut == true) {
//			basicAttack.volume -= 0.10f * Time.deltaTime;
//		} 

//			if (basicAttack.volume <= 0.10f) {
//			projectileIsOut = false; 
////			basicAttack.volume = 0f;
//		}

		if (aimLockTime > 0 && aimCountdownOn) {
			basicAttack.panStereo = Mathf.Clamp(basicAttack.panStereo, attackPan, attackPan);
		} else if (aimLockTime <= 0) {
			aimLockOn = false;
			aimCountdownOn = false;
			isFiring = false;
			aimLockTime = aimLockTimeReset;
		}
	}

	public void PlayEnemyDeath(){
		GameObject.Find("EnemyHitSoundHolder").SendMessage("PlayHitSound");
		basicAttack.Stop();
	}
}
