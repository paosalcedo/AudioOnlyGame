using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	
	AudioSource basicAttack;
	// Use this for initialization
	void Start () {
		basicAttack = GetComponent<AudioSource>();	
		basicAttack.volume = 0; 	
	}
	
	// Update is called once per frame
	void Update () {
		BasicAttack();
		print(MouseLook.instance.mouseLookX);
		basicAttack.panStereo = AudioDirector.remapRange(MouseLook.instance.mouseLookX, -90f, 90f, -1f, 1f);
	}

	private void BasicAttack ()
	{
		if (Input.GetMouseButton (0)) {
			basicAttack.volume += 0.5f * Time.deltaTime;
		} else {
			basicAttack.volume -= 0.5f * Time.deltaTime;
		}
	}
}
