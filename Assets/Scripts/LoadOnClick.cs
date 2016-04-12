using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(string level) {
		SceneManager.LoadScene(level);
	}

	public void QuitScene() {
		Application.Quit ();
	}

}
