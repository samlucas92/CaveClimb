using UnityEngine;
using System.Collections;

public class ListFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.renderer.sortingLayerName = "MenuItems";
		this.renderer.sortingOrder = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
