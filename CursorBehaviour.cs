using UnityEngine;
using System.Collections;

/**
 * Curseur lors de la possession
 */ 
public class CursorBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(this.gameObject.renderer.enabled){
			float xAxis = Input.GetAxis("L_XAxis_2");
			float yAxis = -Input.GetAxis("L_YAxis_2");

			Vector2 pos = this.gameObject.transform.position;
			pos.x = pos.x + xAxis*0.2f;
			pos.y = pos.y + yAxis*0.2f;
			this.gameObject.transform.position = pos;
		}
	}
}
