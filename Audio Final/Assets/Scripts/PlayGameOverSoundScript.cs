using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameOverSoundScript : MonoBehaviour {
	AudioSource gameOverVO;
	// Use this for initialization
	void Start () {
		gameOverVO = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayGameOverVO ()
	{
		gameOverVO.Play ();
		Debug.Log("Game over VO should be playing!");
//		if (!gameOverVO.isPlaying) {
//			SceneManager.LoadScene("main");
//		}
	}
}
