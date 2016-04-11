using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//Material texture offset rate
	float speed = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().transform.Translate (Vector3.back * speed * Time.deltaTime);
	}

}
