using UnityEngine;
using System.Collections;
using System;
public class GameController : MonoBehaviour {

	// Use this for initialization



	public float distanceBetweenBarGroups; 

	Transform playerTransform;



 
	void Start () {
		
		playerTransform= GameObject.FindGameObjectWithTag("Player").transform;



	}
	
	// Update is called once per frame
	float lastPlayerPosition;
	void Update () {
	

		//if player player somes 6 units distance from its last distance ,then we will create new bar group
		if( playerTransform != null && playerTransform.position.y - lastPlayerPosition > 6)
		{

			lastPlayerPosition = playerTransform.transform.position.y; // to store the present ball position y .
		}

		 


	}





}
