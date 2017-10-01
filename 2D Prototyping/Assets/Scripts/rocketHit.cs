using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour {

	//Damage caused by missle
	public float weaponDamage;	

	//references projectile parent object
	projectileController myPC;	


	public GameObject explosionEffect;

	// Awake function is used when the object is interacted with
	void Awake () {
		
		//Call from child to get parent component
		myPC = GetComponentInParent<projectileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//When one collider interacts with another collider this function will return that information
	void OnTrigger2D(Collider2D other){
		
		//if object is shootable then make missle stop
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {	

			//Call to remove force function to set velocity of missle to 0
			myPC.removeForce();	

			//Creates explosion on impact at objects position
			Instantiate (explosionEffect, transform.position, transform.rotation);	

			//Destroyed the child object missle but leaves parent object Projectile to continue showing smoke
			Destroy(gameObject);	

			//If the object collided with is an enemy 
			if(other.tag == "Enemy"){
				//Get the enemies health
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				//Add damage to enemy
				hurtEnemy.addDamage (weaponDamage);
			}
		}
	}

	//Safe guard just in case first on trigger fails due to objects moving too quickly
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {	
			myPC.removeForce();	
			Instantiate (explosionEffect, transform.position, transform.rotation);	
			Destroy(gameObject);	
			//If the object collided with is an enemy 
			if (other.tag == "Enemy") {
				//Get the enemies health
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				//Add damage to enemy
				hurtEnemy.addDamage (weaponDamage);
			}

		}
	}





}
