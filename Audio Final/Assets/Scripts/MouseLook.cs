using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	Vector3 playerPos;
	Vector2 mouseLook;
	Vector2 smoothV;
	public AudioSource playerDir;

	public float mouseLookX;
	public float sensitivity = 1.0f;
	public float smoothing = 2.0f;
	float xDisplacement;

	GameObject character;

	public static MouseLook instance;

	void Start () {
		player = GameObject.Find("Player");
		playerPos = player.transform.position;		
		playerDir = player.GetComponent<AudioSource>();
		xDisplacement = 0f;
		
		character = this.transform.parent.gameObject;
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy(gameObject);
		}
 	}
	
	// Update is called once per frame
	void Update () {
		mouseLookX = mouseLook.x;
//	Remapped volume to mouseY.
//		player.GetComponent<AudioSource>().volume = remapRange(mouseLook.y, -90, 90, 0f, 1f);

// 	Pan stereo signal based on mouseX.
//		playerDir.panStereo = remapRange(mouseLook.x, -90, 90, -1f, 1f);
 		
		Vector2 mousePos = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		player.transform.position = new Vector3 (mouseLook.x, playerPos.y, playerPos.z); 

		mousePos = Vector2.Scale (mousePos, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, mousePos.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mousePos.y, 1f / smoothing);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp (mouseLook.y, -90f, 90f);
		mouseLook.x = Mathf.Clamp (mouseLook.x, -90f, 90f);


		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);

	}

	float remapRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax )
	   	{
		     float newValue = 0;
		     float oldRange = (oldMax - oldMin);
		     float newRange = (newMax - newMin);
		     newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
		     return newValue;
	   	}
}
