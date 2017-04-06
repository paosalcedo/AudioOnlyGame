using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	float spawnInterval;
 	List<GameObject> enemies = new List<GameObject>();
	// Use this for initialization
	void Start () {
		spawnInterval = Random.Range(0, 5);
//		enemies.Add(Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
//		enemies[0].transform.position = GameObject.Find("Player").transform.position;
//		
//		enemies.Add(Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
//		enemies[1].transform.position = GameObject.Find("Player").transform.position;
		
	}

	void Update(){
		SpawnRandomizer();
	}
	
	private void SpawnEnemy (float randomizer)
	{
		Debug.Log(randomizer);
		//spawn both
		if (randomizer >= 0.75f) {
			Debug.Log("75th percentile!");
			enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
			enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
		} 
		//only spawn Lvl 2 enemy
		else if (randomizer < 0.75f && randomizer >= 0.5f) {
			Debug.Log("50th percentile!");
			enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
		} else if (randomizer < 0.5f && randomizer >= 0.25f) {
			Debug.Log("25th percentile!");
			enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
		} else if (randomizer < 0.25f && randomizer >= 0.125f) {
			Debug.Log("12.5th percentile!");
			enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
			enemies.Add (Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
		} else if (randomizer < 0.125f && randomizer >= 0) {
			Debug.Log("Bottom percentile!");
			enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
			enemies.Add (Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
		}

		//make sure enemies spawn exactly where the player is. 
		GameObject[] spawnedEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in spawnedEnemies) {
			enemy.transform.position = GameObject.Find("Player").transform.position;
		}
	}

	private void SpawnRandomizer ()
	{
		spawnInterval -= Time.deltaTime;
		if (spawnInterval <= 0) {
			SpawnEnemy(Random.Range(0f, 1f));
			spawnInterval = Random.Range(0, 10);
		}
	}
}
