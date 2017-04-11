using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVoiceScript : MonoBehaviour {

	public static TutorialVoiceScript instance;

	AudioSource tutorialVO;
	// Use this for initialization
	void Start () {
		tutorialVO = GetComponent<AudioSource>();
		tutorialVO.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
