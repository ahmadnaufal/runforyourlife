using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayBestScore : MonoBehaviour {

	Text scoretext;

	// Use this for initialization
	void Start () {
		scoretext = gameObject.GetComponent<Text> ();
		int bestScore = PlayerPrefs.GetInt ("BestScore");
		scoretext.text = "Best Score\n" + bestScore;
	}

}
