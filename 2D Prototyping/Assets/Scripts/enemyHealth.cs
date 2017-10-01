using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

	//enemies max health
	public float enemyMaxHealth;
	 
	//Enemy DeathFX
	public GameObject deathFX;

	//enemies current health
	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	void makeDead(){

		//Instantiate deathFX on GameObject
		Instantiate (deathFX, transform.position, transform.rotation);

		Destroy (gameObject);
	}
}
