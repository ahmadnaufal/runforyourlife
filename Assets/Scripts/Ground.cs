using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	//Material texture offset rate
	float speed = .1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Offset the material texture at a constant rate
		float offset = Time.time * speed;                             
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset); 
	}
}
