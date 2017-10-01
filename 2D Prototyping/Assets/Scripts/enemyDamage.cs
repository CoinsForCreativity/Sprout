using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	//Enemy Damage
	public float damage;

	//Damage rate
	public float damageRate;

	//Force that pushes character back
	public float pushBackForce;

	//next time character can take damage
	private float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay2D(Collider2D other){
		//If the player is being collided with and next damage is less than current time
		if(other.tag == "Player" && nextDamage<Time.time){
			//get player health
			playerHealth playersHealth = other.gameObject.GetComponent<playerHealth>();

			//Add damage to the player
			playersHealth.addDamage(damage);

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
}
