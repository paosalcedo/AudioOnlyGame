using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	AudioSource enemySound;

	// Use this for initialization
	void Start () {
		enemySound = GetComponent<AudioSource>();
		enemySound.panStereo = -0.5f;
		enemySound.volume = 0.25f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		enemySound.panStereo += 0.1f * Time.deltaTime;
	}

}
