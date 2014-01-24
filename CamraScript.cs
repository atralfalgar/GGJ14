using UnityEngine;
using System.Collections;
using System;

public class CamraScript : MonoBehaviour
{
    // Constantes :
    private Vector3 speedScrolling;
    private float seuilEloignementJoueur;
    private float seuilEgalite;

    private int etat;
    private bool salleEntierementVisible;
    public GameObject finSalle;
    public GameObject joueur;

	// Use this for initialization
    void Start()
    {
        speedScrolling = new Vector3(0.1f, 0.0f, 0.0f);
        etat = 0;
        seuilEloignementJoueur = 2.0f;
        this.enabled = true;
        if (finSalle != null)
            salleEntierementVisible = finSalle.renderer.isVisible;
        else
            salleEntierementVisible = false;
        Debug.Log(salleEntierementVisible);
        seuilEgalite = 0.05f;
    }
	
	// Update is called once per frame
	void Update ()
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
                {
                    
                    etat = 2;
                }
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
	}
}
