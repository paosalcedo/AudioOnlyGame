using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	
	AudioSource basicAttack;
	float attackPan; 
	public float aimLockTimeReset; 
	bool aimLockOn;
	float aimLockTime;
	// Use this for initialization
	void Start () {
		basicAttack = GetComponent<AudioSource>();	
		basicAttack.volume = 0;
		aimLockOn = false;
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

		LockAim();
	}

	bool aimCountdownOn;
	
	private void BasicAttack ()
	{
		if (Input.GetMouseButton (0)) {
			basicAttack.volume = 1;
			aimLockOn = true;
			aimCountdownOn = true;
			attackPan = basicAttack.panStereo;

			//start aim lock function with a bool.
		} else {
			basicAttack.volume -= 0.5f * Time.deltaTime;
			aimLockOn = false;
		}
	}

	
	private void LockAim ()
	{
		if (aimCountdownOn == true) {		
			aimLockTime -= Time.deltaTime;
			Debug.Log("Aim counting down!");
		}

		if (aimLockTime > 0 && aimCountdownOn) {
			basicAttack.panStereo = Mathf.Clamp(basicAttack.panStereo, attackPan, attackPan);
		} else if (aimLockTime <= 0) {
			aimLockOn = false;
			aimCountdownOn = false;
			aimLockTime = aimLockTimeReset;
		}
	}
}
