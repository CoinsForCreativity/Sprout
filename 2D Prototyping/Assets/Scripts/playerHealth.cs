using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

	//player maxHealth
	public float maxHealth;

	public float timer;

	//create gameobject that can instantiate death effects game object
	public GameObject deathFX;

	//player current health
	private float currentHealth;

	//Stop movement of player upon death
	playerController controlMovement;

	//HUD variables
	public Slider healthSlider;

	bool playerAlive;



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

		playerAlive = true;
		timer = 20000f;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (playerAlive);

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
		playerAlive = false;
		//Destroy player
		while(timer >= 0) {
			timer -= Time.deltaTime;
			if (!playerAlive) {
				if (timer <= 0) {
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

				}
			}
		}
		Destroy(gameObject);



	}


}
