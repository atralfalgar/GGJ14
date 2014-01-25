using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    private float seuilEloignementJoueur = 2.0f;
    private int etat = 0;

    public GameObject joueur;
    public float speed = 0.05f;

    void Start()
    {
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
        if (transform.position.x + seuilEloignementJoueur < joueur.transform.position.x || transform.position.x - seuilEloignementJoueur > joueur.transform.position.x
            || transform.position.y + seuilEloignementJoueur < joueur.transform.position.y || transform.position.y - seuilEloignementJoueur > joueur.transform.position.y)
            return 1;
        else
            return 0;
    }

    private int followCharacter()
    {
        Vector3 speedScrollingX = new Vector3(speed, 0.0f, 0.0f);
        Vector3 speedScrollingY = new Vector3(0.0f, speed, 0.0f);

        if (!joueur.renderer.isVisible)
        {
            speedScrollingX *= 5.0f;
            speedScrollingY *= 5.0f;
        }

        bool movX = false;

        if (transform.position.x + seuilEloignementJoueur < joueur.transform.position.x)
        {
            transform.Translate(speedScrollingX);
            movX = true;
        }
        else if (transform.position.x - seuilEloignementJoueur > joueur.transform.position.x)
        {
            transform.Translate(-speedScrollingX);
            movX = true;
        }
        if (transform.position.y + seuilEloignementJoueur < joueur.transform.position.y)
        {
            transform.Translate(speedScrollingY);
            return 1;
        }
        else if (transform.position.y - seuilEloignementJoueur > joueur.transform.position.y)
        {
            transform.Translate(-speedScrollingY);
            return 1;
        }
        else if (movX)
            return 1;
        else
            return 0;
    }
}
