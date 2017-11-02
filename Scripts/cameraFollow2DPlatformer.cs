using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour {

	//Object the camera is following
	public Transform target;	

	//Dampening effect for camera
	public float smoothing;

	//Distance between character and camera
	private Vector3 offset;

	//Lowest point camera will go if character falls
	private float lowY;

	// Use this for initialization
	void Start () {
		
		//Based off the current camera position
		offset = transform.position - target.position;

		//Current position of the camera
		lowY = transform.position.y;



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Current target position
		Vector3 targetCamPos = target.position + offset;

		//Allows to move from one position to another position smoothly at the difference in the time since the last frame
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);

		//Prevents camera from following falling player
		if (transform.position.y < lowY) {

			//If our position y goes below the lowY value it sets back to lowY
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}
}
