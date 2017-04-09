using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	
	public float enemyDist;
	public float enemyDir;
	public float enemyVolume;
	AudioSource enemySound;
	
	// Use this for initialization
	void Start () {
		enemySound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
