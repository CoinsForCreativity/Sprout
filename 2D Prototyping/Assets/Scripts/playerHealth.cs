using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	//player maxHealth
	public float maxHealth;

	//create gameobject that can instantiate death effects game object
	public GameObject deathFX;

	//player current health
	private float currentHealth;

	//Stop movement of player upon death
	playerController controlMovement;

	//HUD variables
	public Slider healthSlider;


	// Use this for initialization
	void Start () {
		//Sets playes current health to max health
		currentHealth = maxHealth;

		//Get player controller object
		controlMovement = GetComponent<playerController> ();

		//HUD Initialization
		healthSlider.maxValue=maxHealth;

		//HUD Slider health value
		healthSlider.value=maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){
		if (damage <= 0) {
			return;
		}
		currentHealth -= damage;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			makeDead ();
		}
			
	}

	public void makeDead(){
		//Instantiate deathFX on GameObject
		Instantiate (deathFX, transform.position, transform.rotation);

		//Destroy player
		Destroy(gameObject);
	}
}
