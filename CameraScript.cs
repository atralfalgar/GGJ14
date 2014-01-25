using UnityEngine;
using System.Collections;
using System;

public class CameraScript : MonoBehaviour
{
    // Constantes :
    private Vector3 speedScrolling;
    private float seuilEloignementJoueur = 2.0f;

    private int etat = 0;
    public GameObject joueur;
    public float speed = 0.05f;

    void Start()
    {
        speedScrolling = new Vector3(speed, 0.0f, 0.0f);
    }
	
	void Update ()
    {
        // Etats :
        // - Ne rien faire      0
        // - Suivre personnage  1
        switch (etat)
        {
            case 0:
                etat = doNothing();
                break;
            case 1:
                etat = followCharacter();
                break;
        }
	}

    private int doNothing()
    {
        if (transform.position.x + seuilEloignementJoueur < joueur.transform.position.x || transform.position.x - seuilEloignementJoueur > joueur.transform.position.x)
            return 1;
        else
            return 0;
    }

    private int followCharacter()
    {
        if (transform.position.x + seuilEloignementJoueur < joueur.transform.position.x)
        {
            if (joueur.renderer.isVisible)
                transform.Translate(speedScrolling);
            else
                transform.Translate(5 * speedScrolling);
            return 1;
        }
        else if (transform.position.x - seuilEloignementJoueur > joueur.transform.position.x)
        {
            if (joueur.renderer.isVisible)
                transform.Translate(-speedScrolling);
            else
                transform.Translate(5 * -speedScrolling);
            return 1;
        }
        else
            return 0;
    }
}
