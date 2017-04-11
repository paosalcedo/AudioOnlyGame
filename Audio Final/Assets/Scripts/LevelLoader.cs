using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	float playerMoveTime;
	float timeToWin = 60f;
	// Use this for initialization
	void Start () {
		playerMoveTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerIsMoving == true) {
			playerMoveTime += Time.deltaTime;
		} 
		LoadNextLevel();
//		Stopwatch();
		Debug.Log(playerMoveTime);
	}

	void LoadNextLevel ()
	{
		if (Input.GetKeyDown (KeyCode.Return) || playerMoveTime > timeToWin) {
			SceneManager.LoadScene ("main");
		}
	}
	
	bool playerIsMoving;
	void Stopwatch ()
	{
//		float currentPlayerMoveTime;
		if (playerIsMoving == true) {
			playerMoveTime += Time.deltaTime;
//			currentPlayerMoveTime = playerMoveTime;
			Debug.Log("Player is moving! " + playerMoveTime);
		} else if (!playerIsMoving) {
//			currentPlayerMoveTime = playerMoveTime;
//			Debug.Log(playerMoveTime); 
		}
	}

	void PlayerIsMoving ()
	{
		playerIsMoving = true;
		Debug.Log("player is moving!");
	}

	void PlayerIsNotMoving(){
		playerIsMoving = false;
		Debug.Log("player is not moving!");
	}
}
