using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Plane : MonoBehaviour {

	public Vector3 velocity = new Vector3(0, 0, 1);
	public float rotateSpeed = 10.0f;
	public float rotateResetSpeed = 1.0f;
	public Quaternion originalRotationValue;

	// Use this for initialization
	void Start () {
		originalRotationValue = transform.rotation;
		GetComponent<Rigidbody> ().velocity = velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float rotateAmount = rotateSpeed * Time.deltaTime;

		if (Input.anyKey) { 
			if (Input.GetKey ("w"))
				transform.Rotate (-rotateAmount, 0f, 0f);

			if (Input.GetKey ("s"))
				transform.Rotate (rotateAmount, 0f, 0f);

			if (Input.GetKey ("a"))
				transform.Rotate (0f, 0f, rotateAmount);

			if (Input.GetKey ("d"))
				transform.Rotate (0f, 0f, -rotateAmount);
		} else
			transform.rotation = Quaternion.Slerp (transform.rotation, originalRotationValue, Time.time * rotateResetSpeed);
		
		transform.Translate(Vector3.forward);
	}

	// Die by collision
	void OnCollisionEnter(Collision other)
	{
		GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0);
		Die();
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
