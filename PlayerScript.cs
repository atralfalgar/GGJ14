using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    /// <summary>
    /// Speed
    /// </summary>
    public float speedRun = 10f;


    /// <summary>
    /// mouvement
    /// </summary>
    private Vector2 movement;

    private bool grounded;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private float jumpForce = 1500f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //Check grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

	    //Retrieve the input
        float inputX = Input.GetAxis("Horizontal");

        movement = new Vector2(
            inputX * speedRun,
            0);

        if (Input.GetKey("up") && grounded)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }

}
