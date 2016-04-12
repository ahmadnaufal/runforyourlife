using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody playerRigidBody;
	Animation anim;
	float jumpSpeed = 6f;
	float moveSpeed = 3f; 
	bool isFalling = false;
	public bool isDead = false;

	public GameObject gameStatus;

	// Use this for initialization
	void Start () {
		gameStatus = GameObject.Find ("GameController");
		playerRigidBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isFalling && !isDead) {
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
		if ((target.gameObject.tag == "Obstacle" || target.gameObject.tag == "Enemy") && !isDead) {
			if (anim.IsPlaying ("Attack") && target.gameObject.tag == "Enemy")
				Destroy (target.gameObject);
			else {
				isDead = true;
				anim.Stop ("Walk");
				anim.Play ("Dead");
				gameStatus.GetComponent<GameStatus> ().isGameOver = true;
			}
		} else if (target.gameObject.tag == "Powerup" && !isDead) {
			Vector3 position = target.gameObject.GetComponent<Rigidbody> ().position;
			GameObject explosion = target.gameObject.GetComponent<EnemyController> ().explosionEffect;
			GameObject explode = (GameObject) Instantiate(explosion, position, Quaternion.identity);
			Destroy (target.gameObject);
			Destroy (explode, 2);
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		isFalling = false;
	}
		
}
