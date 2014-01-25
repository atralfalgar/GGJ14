﻿using UnityEngine;
using System.Collections;

/*
 * Cercle de portée de possession
 */ 
public class TargetingRangeBehaviourScript : MonoBehaviour {

	public GameObject currentPlayer;
	public LayerMask controllableCharacters;
	GameObject currentlySelected;
	GameObject cursor;
	bool targeting = false;
	// Use this for initialization
	void Start () {
		cursor = GameObject.Find("Cursor");
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.renderer.enabled = targeting;
		this.gameObject.transform.position = currentPlayer.transform.position;


		if(Input.GetButtonDown("Y_2") || Input.GetButtonDown("Y_1"))
        {
            if (!targeting)
            {
                targeting = true;
                cursor.renderer.enabled = true;
                cursor.transform.position = new Vector2(this.gameObject.transform.position.x, this.transform.position.y);

            }
            Collider2D[] selectedBodies = Physics2D.OverlapCircleAll(this.gameObject.transform.position, 2, controllableCharacters);
            // Check to remove our player from selectedBodies
            int index = -1;
            for (int i = 0; i < selectedBodies.Length; i++)
            {
                if (selectedBodies[i] == this) selectedBodies[i] = null;
            }


            if (selectedBodies.Length > 0)
            {
                Collider2D closest = selectedBodies[0];
                foreach (Collider2D c in selectedBodies)
                {
                    if (Vector2.Distance(c.gameObject.transform.position, cursor.transform.position) < Vector2.Distance(closest.gameObject.transform.position, cursor.transform.position))
                    {
                        closest = c;
                    }
                }
                currentlySelected = closest.gameObject;
                currentlySelected.GetComponent<PlayerScript>().hover = true;
            }
            else
            {
                currentlySelected = currentPlayer;
            }
		}
        else if(Input.GetButtonUp("Y_2") ||Input.GetButtonUp("Y_1"))
        {
            if (targeting)
            {
                targeting = false;
                cursor.renderer.enabled = false;
                if (currentlySelected != null)
                {
                    currentPlayer.GetComponent<PlayerScript>().active = false;
                    currentPlayer.layer = LayerMask.NameToLayer("ControllableBodies");
                    currentlySelected.GetComponent<PlayerScript>().active = true;

                    currentPlayer = currentlySelected;
                    currentPlayer.layer = LayerMask.NameToLayer("Player");

                    GameObject.Find("Main Camera").GetComponent<CameraScript>().joueur = currentPlayer;
                }
            }
		}
	}
}
