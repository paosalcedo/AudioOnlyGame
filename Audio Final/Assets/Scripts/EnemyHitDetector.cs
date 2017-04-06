﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetector : MonoBehaviour {

	[SerializeField] float enemyVolume;
	float enemyPan;
	[SerializeField] float precision;
	AudioSource enemySound;

	// Use this for initialization
	void Start () {
		enemyPan = Random.Range(-1f, 1f);
		enemyVolume = Random.Range(0f, 1f);	
		enemySound = GetComponent<AudioSource>();
		enemySound.panStereo = enemyPan;
		enemySound.volume = enemyVolume;
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckForHit();
	}

	void CheckForHit ()
	{
		if ((AttackScript.instance.attackPan - enemySound.panStereo) < precision && Input.GetMouseButtonDown(0)) {
			//Destroy an enemy sound.
			EnemySpawner.instance.killCount += 1;
			EnemySpawner.instance.enemies.Remove(gameObject);
			Destroy(gameObject);
		}
	}

}
