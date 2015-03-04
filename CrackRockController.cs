using UnityEngine;
using System.Collections;

public class CrackRockController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		HitByBeam(collider);
	}
	
	void HitByBeam(Collider2D beamCollider)
	{
		animation.Play("rockSmash");
	}
}
