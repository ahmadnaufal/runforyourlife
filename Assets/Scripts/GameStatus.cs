using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStatus : MonoBehaviour {

	public bool isGameOver = false;
	public int score;

	public GameObject gameOverDialog;
	public GameObject statusInterface;
	GameObject myStatus;

	float updateScore = 0.3f;
	float timeElapsed = 0;
	bool showDialog;

	// Use this for initialization
	void Start () {
		score = 0;
		showDialog = false;
		myStatus = (GameObject)Instantiate (statusInterface);
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			int bestScore = PlayerPrefs.GetInt ("BestScore");
			if (score > bestScore)
				PlayerPrefs.SetInt ("BestScore", score);

			if (!showDialog) {
				GameObject temp = (GameObject)Instantiate (gameOverDialog);
				Text scoreText = temp.transform.GetChild (1).gameObject.GetComponent<Text> ();
				scoreText.text = "Your Score: " + score;
				Destroy (myStatus);

				showDialog = true;
			}
		} else {
			timeElapsed += Time.deltaTime;
			if (timeElapsed > updateScore) {
				score++;
				timeElapsed -= updateScore;
			}
		}
	}
		
}
