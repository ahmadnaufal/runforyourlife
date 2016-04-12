using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//Material texture offset rate
	float speed = 6f;

	public GameObject explosionEffect;
	public GameObject gameStatus;

	// Use this for initialization
	void Start () {
		gameStatus = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		bool isGameOver = gameStatus.GetComponent<GameStatus> ().isGameOver;
		if (!isGameOver)
			GetComponent<Rigidbody>().transform.Translate (Vector3.back * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision target) {
		
	}

}
