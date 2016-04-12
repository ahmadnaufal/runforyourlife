using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {

	public GameObject enemy;
	public GameObject powerUp;
	public GameObject gameStatus;

	float timeElapsed = 0;
	float spawnCycle = 1f;

	// Use this for initialization
	void Start () {
		gameStatus = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		bool isGameOver = gameStatus.GetComponent<GameStatus> ().isGameOver;
		if (isGameOver)
			return;

		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle) {
			GameObject temp;
			int spawnReady = Random.Range (0, 6);
			if (spawnReady > 0) {
				temp = (GameObject)Instantiate (enemy);
				Vector3 position = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), position.y, position.z);
			} else {
				temp = (GameObject)Instantiate (powerUp);
				Vector3 position = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), position.y, position.z);
			}

			timeElapsed -= spawnCycle;
		}
	}
}
