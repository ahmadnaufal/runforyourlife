using UnityEngine;
using System.Collections;

public class DestroySpawned : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		Destroy (collider.gameObject);
	}
}
