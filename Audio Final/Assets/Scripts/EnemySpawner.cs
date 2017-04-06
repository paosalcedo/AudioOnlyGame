using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public int killCount;
//	public GameObject[] spawnedEnemies;
	public float spawnInterval;
 	public List<GameObject> enemies = new List<GameObject>();
//	public GameObject[] enemies;
	// Use this for initialization

	public static EnemySpawner instance;

	void Start () {
		//add enemies at start to get SpawnRandomizer rolling.
//		enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
//		enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
		//Add all spawned enemies to an array "spawned enemies" for counting later.
//		SpawnFirstWave();
		spawnInterval = 1f;
 		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy(gameObject);
		}
	}

	void Update ()
	{
		SpawnWave();
//		SpawnRandomizer ();
//		spawnedEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}

	int waveCount;

	void SpawnWave ()
	{
		spawnInterval -= Time.deltaTime; //count down spawn timer
//		
		if (spawnInterval <= 0 && killCount == waveCount) { //if spawn timer hits ZERO, spawn enemies.
			for (int i = 0; i < Random.Range (1, 2); i++) {
				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
//				enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
				killCount = 0;
			}
			spawnInterval = 1f;
			waveCount = enemies.Count;
		}	
	}

//	void SpawnFirstWave (){
//		for (int i = 0; i < Random.Range(1, 5); i++) {
//			print("Random enemy spawned");
//				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
//			}
//	}






	
//	bool spawnIsAllowed;

 
//	void SpawnEnemy ()
//	{
//		enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
////		enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
//		
//		//make sure each enemy spawns on the player position.
//		foreach (GameObject enemy in enemies) {
//			enemy.transform.position = GameObject.Find("Player").transform.position;
//		}
//// POORLY FUNCTIONING RANDOMIZER			
////		if (spawnIsAllowed) { // Only spawn enemies if there are 0 or less enemies in-game.
//// 			Debug.Log("SpawnEnemy() called!");
//			//spawn both enemy types
////			if (randomizer >= 0.75f) {
////				Debug.Log ("75th percentile!");
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
////			} 
////		//only spawn Lvl 2 enemy
////			else if (randomizer < 0.75f && randomizer >= 0.5f) {
////				Debug.Log ("50th percentile!");
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
////			} else if (randomizer < 0.5f && randomizer >= 0.25f) {
////				Debug.Log ("25th percentile!");
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
////			} else if (randomizer < 0.25f && randomizer >= 0.125f) {
////				Debug.Log ("12.5th percentile!");
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
////			} else if (randomizer < 0.125f && randomizer >= 0) {
////				Debug.Log ("Bottom percentile!");
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
////				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
////			}
////		}
//	}

//	void SpawnRandomizer ()
//	{
//		spawnInterval -= Time.deltaTime; //count down spawn timer
//
//		if (spawnInterval <= 0) { //if spawn timer hits ZERO, spawn enemies.
//			Debug.Log ("Enemies: " + enemies.Count);
////			SpawnEnemy ();
//			spawnInterval = 1f;
//			if (enemies.Count <= 0) {
//				enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
//			}
//			//enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
//		
//			//make sure each enemy spawns on the player position.
//			foreach (GameObject enemy in enemies) {
//				enemy.transform.position = GameObject.Find("Player").transform.position;
//			}
////			if (enemies.Count == 0) {
////				spawnIsAllowed = true;
//////				SpawnEnemy (Random.Range (0f, 1f)); //spawn enemy with randomizer
////				Debug.Log ("Spawn Is Allowed!");
////			} 
//		}
//			
////		else {
////				spawnIsAllowed = false;
////		}
//	
//	}
}
