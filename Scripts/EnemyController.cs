using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    //needed to move enemy back and forth
    public enum OccilationFuntion { Sine, Cosine }

 
    bool dirLeft;
	public GameObject character;
	float distance = 7;
	public float playerDistance;
	float negativeScale;
	float positiveScale;
    public float moveSpeed;

    private void Awake()
    {
		
    }

    // Use this for initialization
    void Start () {

		negativeScale = -this.transform.localScale.x;
		positiveScale = this.transform.localScale.x;

		character = GameObject.FindGameObjectWithTag ("Player");
        dirLeft = true; //enemy starts moving left
  		
    }

    // Update is called once per frame
    void Update () {
		//Script to make enemy follow player, increas speed and change directions
		playerDistance = this.transform.position.x - character.transform.position.x;
		if ((playerDistance >= 0 && playerDistance < distance)) {
			transform.Translate(-Vector2.right * (moveSpeed + 2) * Time.deltaTime); //keep moving left
			Vector3 theScale = transform.localScale;
			theScale.x = negativeScale;
			transform.localScale = theScale;

		} else if((playerDistance <= 0 && playerDistance > (-1*distance))){
			transform.Translate(Vector2.right * (moveSpeed + 2) * Time.deltaTime);
			Vector3 theScale = transform.localScale;
			theScale.x = positiveScale;
			transform.localScale = theScale;
		}
        //script to make enemy move back and forth
		else if((!dirLeft && (playerDistance > distance)) || (!dirLeft && (playerDistance < (-1*distance))))//if headed right
		{
			transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
			Vector3 theScale = transform.localScale;
			theScale.x = negativeScale;
			transform.localScale = theScale;
		}
		else if((dirLeft && (playerDistance > distance)) || (dirLeft && (playerDistance < (-1*distance))))//if headed left
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); //keep moving left
			Vector3 theScale = transform.localScale;
			theScale.x = positiveScale;
			transform.localScale = theScale;

        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		
		if (collision.gameObject.tag != "Player") { //if collide with anything other than player
			dirLeft = !dirLeft; //if enemy runs into something not the player, change from false to true or vice versa
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

    }




}
