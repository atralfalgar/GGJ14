using UnityEngine;
using System.Collections;
using System;

public class CameraScript : MonoBehaviour
{
    // Constantes :
    private Vector3 speedScrolling;
    private float seuilEloignementJoueur = 2.0f;
    //private float seuilEgalite = 0.05f;

    private int etat = 0;
    private bool salleEntierementVisible;
    public GameObject finSalle;
    public GameObject joueur;

	// Use this for initialization
    void Start()
    {
        speedScrolling = new Vector3(0.1f, 0.0f, 0.0f);
        if (finSalle != null)
            salleEntierementVisible = finSalle.renderer.isVisible;
        else
            salleEntierementVisible = false;
    }
	
	// Update is called once per frame
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

    /*void oldUpdate()
    {
        // Etats :
        // - Ne rien faire                      0
        // - Changer de salle                   1
        // - Suivre personnage (grandes salles) 2
        switch (etat)
        {
            case 0:
                if (joueur.transform.position.x == finSalle.transform.position.x)
                    etat = 1;
                else if (!salleEntierementVisible && Math.Abs(joueur.transform.position.x - transform.position.x) > seuilEloignementJoueur)
                    etat = 2;
                break;
            case 1:
                // Insuffisant : on ne fait qu'amener la caméra à la fin de la salle. Il faudrait l'envoyer au début de la suivante (pareil ?)
                if (this.transform.position.x == finSalle.transform.position.x)
                {
                    etat = 0;
                    salleEntierementVisible = finSalle.renderer.isVisible;
                }
                else
                    transform.Translate(speedScrolling);
                break;
            case 2:
                if (Math.Abs(this.transform.position.x - joueur.transform.position.x) < seuilEgalite)
                    etat = 0;
                else if (this.transform.position.x < joueur.transform.position.x)
                    transform.Translate(speedScrolling);
                else
                    transform.Translate(-speedScrolling);
                break;
        }
    }*/
}
