using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetector : MonoBehaviour {

	public float enemyVolume;
	public float enemyPan;
	[SerializeField] float precision;
	AudioSource enemySound;
	public static EnemyHitDetector instance;

	// Use this for initialization
	void Start () {
		enemyPan = Random.Range(-1f, 1f);
		enemyVolume = 0f;	
		enemySound = GetComponent<AudioSource>();
		enemySound.panStereo = enemyPan;
		enemySound.volume = enemyVolume;
//		SINGLETON
//		if (instance == null) {
//			instance = this;
//			DontDestroyOnLoad (this);
//		} else {
//			Destroy(gameObject);
//		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckForHit();
		MoveEnemy();
	}
	
	float panDifference;
	void CheckForHit ()
//**** NEW MOTORCYCLE VERSION *****
//	{
//		panDifference = MouseLook.instance.playerDir.panStereo - enemySound.panStereo;
//		if (panDifference < 0) {
//			panDifference *= -1f;
//		} 
//		
//		Debug.Log(panDifference);
//		
//		if (panDifference < precision && 
//		    enemySound.volume >= 1f) {
//	
//			AttackScript.instance.PlayEnemyDeath ();
//			EnemySpawner.instance.killCount += 1;
//			EnemySpawner.instance.enemies.Remove (gameObject);
//	
//			Destroy (gameObject);
//		} 

//		if (enemySound.volume >= 1f &&  
//					panDifference > precision) {
//			Debug.Log("Hit a wall!");
//			GameObject.Find("ObstacleSoundHolder").SendMessage("PlayCollideSound");
////			GameObject.Find("Player").SendMessage("KillVolume");
//		}
//	}
//**** OLD CHECK FOR HIT *****
	{
		if ((AttackScript.instance.attackPan - enemySound.panStereo) < precision &&
		    AttackScript.instance.basicAttack.volume < enemySound.volume 
			&& AttackScript.instance.isFiring == true) 
		{
			//Destroy an enemy sound.
			AttackScript.instance.PlayEnemyDeath();
			AttackScript.instance.attackVolume = 0f;
			EnemySpawner.instance.killCount += 1;
			EnemySpawner.instance.enemies.Remove (gameObject);
			
			Destroy (gameObject);
		} 
	}

	void MoveEnemy (){
		enemySound.volume += 0.05f * Time.deltaTime;	
	}

	

}
