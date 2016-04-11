using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody playerRigidBody;
	Animation anim;
	float jumpSpeed = 6f;
	float moveSpeed = 3f; 
	bool isFalling = false;
	bool animSwitch = false;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isFalling && !animSwitch) {
			if (!anim.IsPlaying ("Attack"))
				anim.Play ("Walk");
			
			if (Input.GetKeyDown ("space")) {
				playerRigidBody.velocity = jumpSpeed * Vector3.up;
				isFalling = true;
			}

			if (Input.GetKey ("a"))
				playerRigidBody.transform.Translate (Vector3.left * moveSpeed * Time.deltaTime); 

			if (Input.GetKey ("d"))
				playerRigidBody.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);

			if (Input.GetKey ("w")) {
				anim.Play ("Attack");
			}
				
		}
	}

	void OnCollisionEnter(Collision target) {
		if (target.gameObject.tag == "Obstacle" && !animSwitch) {
			animSwitch = true;
			anim.Stop ("Walk");
			anim.Play ("Dead");
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		isFalling = false;
	}
		
}
