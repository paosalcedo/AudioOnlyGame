using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetector : MonoBehaviour {

	[SerializeField] float enemyVolume;
	[SerializeField] float enemyPan;
	[SerializeField] float precision;
	AudioSource enemySound;

	// Use this for initialization
	void Start () {
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
		if ((AttackScript.instance.attackPan - enemySound.panStereo) < precision) {
			//Destroy an enemy sound.
			Destroy(gameObject);
		}
	}

}
