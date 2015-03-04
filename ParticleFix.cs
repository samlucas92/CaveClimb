using UnityEngine;
using System.Collections;

public class ParticleFix : MonoBehaviour {

	public string layer;
	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = layer;
		particleSystem.renderer.sortingOrder = -1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
