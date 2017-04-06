using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	float spawnInterval = 5f;
	[SerializeField] float spawnIntervalReset;
	List<GameObject> enemies = new List<GameObject>();
	// Use this for initialization
	void Start () {
		enemies.Add(Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
		enemies[0].transform.position = GameObject.Find("Player").transform.position;
		
		enemies.Add(Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
		enemies[1].transform.position = GameObject.Find("Player").transform.position;

	}

	void Update(){
		
	}
	
	private void SpawnEnemy(){
		enemies.Add(Instantiate (Resources.Load ("Prefabs/EnemyLvl2") as GameObject));
		enemies[0].transform.position = GameObject.Find("Player").transform.position;
		
		enemies.Add(Instantiate (Resources.Load ("Prefabs/BasicEnemy") as GameObject));
		enemies[1].transform.position = GameObject.Find("Player").transform.position;
	}

	private void SpawnRandomizer(){
		spawnInterval -= Time.deltaTime;
		
	}
}
