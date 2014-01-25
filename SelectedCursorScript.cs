using UnityEngine;
using System.Collections;

/**
 * Un petit curseur/icon au dessus du corps actif
 */ 
public class SelectedCursorScript : MonoBehaviour {

	GameObject range;

	// Use this for initialization
	void Start () {
		range = GameObject.Find("TargetingRange");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (Vector2)range.transform.position + new Vector2(0,1);
	}
}
