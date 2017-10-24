using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class enemyDamage : MonoBehaviour {

	//public Button restBtn;
	public GameObject restartButton;
	//Enemy Damage
	public float damage;
	public GameObject player;

	//public bool playerDead;

	//Damage rate
	public float damageRate;

	//Force that pushes character back
	public float pushBackForce;

	//next time character can take damage
	private float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;

		//restBtn.interactable = false;
	}


	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		restartButton = GameObject.Find ("RestartButton");
		restartButton.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		if (player == null || player.transform.position.y <= -20) {
			//Debug.Log("player is dead");
			restartButton.gameObject.SetActive(true);
		}
	}

	

	void OnTriggerStay2D(Collider2D other){
		//If the player is being collided with and next damage is less than current time
		if(other.tag == "Player" && nextDamage<Time.time){
			//get player health
			playerHealth playersHealth = other.gameObject.GetComponent<playerHealth>();


			//Add damage to the player
			playersHealth.addDamage(damage);
//			
			//Updates the next time the player can take damage
			nextDamage = Time.time + damageRate;


			//Push the player back after taking damage
			pushBack(other.transform);
		}


	}



	//Push the player back after taking damage
	void pushBack(Transform pushedObject){

		//Push in the direction opposite the object at a force greater than 1
		Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;

		//push direction is multiplied by push force
		pushDirection *= pushBackForce;

		//Get our rigid body
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();

		//Set Push RB velocity to vector 2 x=0 and y=0 so the RB doesn't move
		pushRB.velocity = Vector2.zero;

		//Add explosive force to the rigid body
		pushRB.AddForce(pushDirection, ForceMode2D.Impulse);

	}

	public void reset(){
		//Debug.Log ("Button is clicked");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


}
