 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

	//movement variables
	public float maxSpeed; //max speed of character
	 
	//jumping vars
	bool grounded = false;
	float groundCheckRadius = 0.2f; //radius that checks if player is grounded
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	Rigidbody2D myRB; 			//characters rigid body
	Animator myAnim;  			//characters animation
	bool facingRight = true;	//initial facing direction

	//For Shooting
	public Transform gunTip;
	public GameObject missle;
	public float fireRate; 	//Player fire rate
	public float nextFire;	//next fire opportunity

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> (); //gets character rigid body
		myAnim = GetComponent<Animator> ();	 //gets character animation
	}
	
	// Update is called once per frame
	void Update(){
		if (grounded && Input.GetButtonDown("Jump")) {
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded); //set to false because player will no longer be on the ground
			myRB.AddForce(new Vector2(0, jumpHeight)); //adds force to push character up
		}


		//checks if player has fallen off a platform and resets the stage
		if(this.transform.position.y <= -20)
		{
			//will reload current scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		// Player shooting
		if (Input.GetAxisRaw ("Fire1") > 0) {
			fireMissle ();
		}


	}




	void FixedUpdate () {
		//Check if character is grounded if not then character is falling
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //If circle is intersecting then grounded
		myAnim.SetBool("isGrounded", grounded);

		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y); //sets vertical velocity

		float move = Input.GetAxis ("Horizontal");		//gets A and D key command (A is negative, D is positive)
		myAnim.SetFloat ("speed", Mathf.Abs (move));	//sets the animation based on horizontal speed

		myRB.velocity = new Vector2 (move*maxSpeed, myRB.velocity.y);	//Sets the rigid body velocity

		if (move > 0 && !facingRight) { //flips characters direction
			flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}
	}

	void flip(){ //flip character function
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void fireMissle(){
		if (Time.time > nextFire) {			//If current time is greater than next fire then fire and add time + fire rate to get next fire
			nextFire = Time.time + fireRate;	
			if (facingRight) {
				//Instantiate - Create an instance of the rocket in a specific position
				Instantiate (missle, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else if (!facingRight) {
				//Instantiate - Create an instance of the rocket in a specific position
				Instantiate(missle, gunTip.position, Quaternion.Euler (new Vector3(0,0,180f)));
			}
		}
	}
}
