using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    /// Speed
    public float runSpeed = 5f;

    /// mouvement
	private float movement = 0f;

    private bool grounded;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 500f;

	public float pounceForce = 100f;
	public bool active = true;
	public bool hover = false;

	public string type = "normal";

    // Death :
    public GameObject seuilTrou;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y <= seuilTrou.transform.position.y)
        {
            // Gérer le fait que le joueur a chuté !
            if (type.Equals("normal"))
            {
                // Die Spieler ist ein grosse she***e !
                // 'Test' pour la première salle :
                transform.position = new Vector3(0.02f, 0.047f, 0.0f);
                if (active)
                    GameObject.Find("Main Camera").transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            }
        }

		if(hover)
			gameObject.renderer.material.color = Color.yellow;
		else
			gameObject.renderer.material.color = Color.white;
		hover = false;

        

		if(active){

		    //Retrieve the input
			float inputX = Input.GetAxis("L_XAxis_2")-Input.GetAxis("L_YAxis_2");


	        movement = inputX * runSpeed/5f;

			//Check grounded
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

			if (Input.GetButtonDown("A_2") && grounded && jumpForce > 0)
			{
				grounded = false;
				// We make sure we are not on the ground on the next frame
				transform.position = new Vector2(transform.position.x, transform.position.y + groundRadius*2);
				rigidbody2D.AddForce(new Vector2(pounceForce, jumpForce));
			}
	        
		}
	}

    void FixedUpdate()
    {


		if(active && grounded){
			float xSpeed = rigidbody2D.velocity.x + movement;
			xSpeed = xSpeed > runSpeed ? runSpeed : xSpeed;
			xSpeed = xSpeed < -runSpeed ? -runSpeed : xSpeed;
			rigidbody2D.velocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
		}
    }
}
