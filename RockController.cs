using UnityEngine;
using System.Collections;
using System;
public class RockController : MonoBehaviour {

	public float strength = 1.0f;
	public Transform boulder;
	public float speed;
	public float distanceDivider;
	float originalXPosition;
	void OnEnable(){
		playerController.PlayerDead += OnPlayerDead;
		originalXPosition = boulder.localPosition.x;

		//To increase boulders moving speed at random 

		if (UnityEngine.Random.Range (-5, 5) > 3) {
	
				speed = UnityEngine.Random.Range (3.0f, 5.0f);
		}

	}
	void OnDisable(){
		
		playerController.PlayerDead -= OnPlayerDead;
	}
	// Use this for initialization
	void Start () {

		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Border"),LayerMask.NameToLayer("Floor"));

	}
	
	// Update is called once per frame
	void Update () {

		boulder.localPosition = new Vector3( originalXPosition +  (Mathf.Sin ( Time.timeSinceLevelLoad * speed ) )/ distanceDivider ,boulder.localPosition.y,0  );


	}

		void OnPlayerDead(System.Object obj,EventArgs args)
	{

		boulder.collider2D.isTrigger = true;

	}

}
