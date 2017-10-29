﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    //public string levelToLoad;  //this is so you can just drag and drop the level to load in the inspector
	public int scene;
    bool loaded;  //used to load scene if not loaded


	// Use this for initialization
	void Start () {

     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if player collider runs into door collider, the next scene will load
        if (other.gameObject.CompareTag("Player"))
        {
			Debug.Log ("collides " + loaded);
            if(!loaded)
            {   
                //load next scene
				SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }

        }

    }
}
