using UnityEngine;
using System.Collections;

public class FullWidthObstacleSpawn : MonoBehaviour {

	public GameObject obstacle;
	public GameObject gameStatus;

	float timeElapsed = 0;
	float spawnCycle;

	// Use this for initialization
	void Start () {
		gameStatus = GameObject.Find ("GameController");
	}

	// Update is called once per frame
	void Update () {
		bool isGameOver = gameStatus.GetComponent<GameStatus> ().isGameOver;
		if (isGameOver)
			return;

		spawnCycle = Random.Range (5, 8);
		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle) {
			GameObject temp;

			temp = (GameObject)Instantiate (obstacle);
			Vector3 position = temp.transform.position;
			temp.transform.position = new Vector3 (0, position.y, position.z);

			timeElapsed -= spawnCycle;
		}
	}
}
