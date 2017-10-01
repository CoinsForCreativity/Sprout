using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float aliveTime;



	//On awake run timer to destroy item
	void Awake () {
		Destroy (gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
