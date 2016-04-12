using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	public GameObject gameStatus;

	//Material texture offset rate
	float speed = .2f;

	// Use this for initialization
	void Start () {
		gameStatus = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		bool isGameOver = gameStatus.GetComponent<GameStatus> ().isGameOver;
		if (!isGameOver) {

			//Offset the material texture at a constant rate
			float offset = Time.time * speed;                             
			GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, -offset); 
		}
	}
}
