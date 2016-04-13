using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMyScore : MonoBehaviour {

	Text scoretext;

	// Use this for initialization
	void Start () {
		scoretext = gameObject.GetComponent<Text> ();
		scoretext.text = "Your Score\n0";
	}
	
	// Update is called once per frame
	void Update () {
		int currentScore = GameObject.Find ("GameController").GetComponentInParent<GameStatus> ().score;
		scoretext.text = "Your Score\n" + currentScore;
	}
}
