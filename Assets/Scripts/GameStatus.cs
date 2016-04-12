using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStatus : MonoBehaviour {

	public bool isGameOver = false;
	public int score;
	float updateScore = 0.3f;
	float timeElapsed = 0;

	// Use this for initialization
	void Start () {
		score = 0;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			int bestScore = PlayerPrefs.GetInt ("BestScore");
			if (score > bestScore)
				PlayerPrefs.SetInt ("BestScore", score);
		} else {
			timeElapsed += Time.deltaTime;
			if (timeElapsed > updateScore) {
				score++;
				timeElapsed -= updateScore;
			}
		}
	}

	void OnGUI() {
		if (isGameOver) {

			//display the final score
			GUI.Box (new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "GAME OVER\nYOUR SCORE: " + (int)score);

			//restart the game on click
			if (GUI.Button (new Rect (Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "RESTART")) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

			//load the main menu, which as of now has not been created
			if (GUI.Button (new Rect (Screen.width / 4 + 10, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "MAIN MENU")) {
				SceneManager.LoadScene(0);
			}

			//exit the game
			if (GUI.Button (new Rect (Screen.width / 4 + 10, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "EXIT GAME")) {
				Application.Quit ();
			}

		}
	}
}
