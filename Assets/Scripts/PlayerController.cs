using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody playerRigidBody;
	Animation anim;
	public float jumpSpeed = 5f;
	float moveSpeed = 3f; 
	bool isFalling = false;
	public bool isDead = false;

	public GameObject gameStatus;

	public AudioSource jumpSound;
	public AudioSource deathSound;
	public AudioSource powerupSound;
	public AudioSource attackSound;
	public AudioSource obstacleSound;

	// Use this for initialization
	void Start () {
		gameStatus = GameObject.Find ("GameController");
		playerRigidBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead) {

			if (!isFalling) {
				gameObject.GetComponent<AudioSource> ().enabled = true;

				if (Input.GetKeyDown ("space") && !isFalling) {
					playerRigidBody.velocity = jumpSpeed * Vector3.up;
					jumpSound.Play ();
					gameObject.GetComponent<AudioSource> ().enabled = false;
					isFalling = true;
				}
			}

			if (!anim.IsPlaying ("Attack"))
				anim.Play ("Walk");

			if (Input.GetKey ("a"))
				playerRigidBody.transform.Translate (Vector3.left * moveSpeed * Time.deltaTime); 

			if (Input.GetKey ("d"))
				playerRigidBody.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);

			if (Input.GetKeyDown ("w")) {
				anim.Play ("Attack");
				attackSound.Play ();
			}
				
		} else if (isFalling || isDead) {
			gameObject.GetComponent<AudioSource> ().enabled = false;
		}
	}

	void OnCollisionEnter(Collision target) {
		if ((target.gameObject.tag == "Obstacle" || target.gameObject.tag == "Enemy") && !isDead) {
			if (anim.IsPlaying ("Attack") && target.gameObject.tag == "Enemy") {
				obstacleSound.Play ();
				AddScore (10);
				Destroy (target.gameObject);
			} else {
				isDead = true;
				anim.Stop ("Walk");
				anim.Play ("Dead");
				deathSound.Play ();
				gameStatus.GetComponent<GameStatus> ().isGameOver = true;
			}
		} else if (target.gameObject.tag == "Powerup" && !isDead) {
			Vector3 position = target.gameObject.GetComponent<Rigidbody> ().position;
			GameObject explosion = target.gameObject.GetComponent<EnemyController> ().explosionEffect;
			GameObject explode = (GameObject)Instantiate (explosion, position, Quaternion.identity);
			Destroy (target.gameObject);
			powerupSound.Play ();
			AddScore (20);
			Destroy (explode, 2);
		} else if (target.gameObject.name == "Ground") {
			isFalling = false;
		}
	}

	void AddScore(int extraScore) {
		gameStatus.GetComponent<GameStatus> ().score += extraScore;
	}
		
}
