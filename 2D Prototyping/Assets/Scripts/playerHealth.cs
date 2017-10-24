using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playerHealth : MonoBehaviour {




	//player maxHealth
	public float maxHealth;


	//create gameobject that can instantiate death effects game object
	public GameObject deathFX;

	//player current health
	public float currentHealth;

	//Stop movement of player upon death
	playerController controlMovement;

	//HUD variables
	public Slider healthSlider;

//	public void minusTimer() {
//		if (countdown == 0) {
//			countdown = timer;
//			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//
//		} else {
//			countdown -= 1;
//
//		}
//	}

	void Awake(){
		
	}
	 

	// Use this for initialization
	void Start () {
		


		//Set button to invisible


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



	
//	IEnumerator playerDeathWait()
//	{
//		Debug.Log("running");
//
//		yield return new WaitForSeconds(5.0f);
//		Debug.Log("after wait");
//		yield break;
//	}


	void makeDead(){
		//Instantiate deathFX on GameObject
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy(gameObject);



	}






}
