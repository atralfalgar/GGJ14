using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    /// <summary>
    /// Speed
    /// </summary>
    public float speedRun = 10f;
    public float speedJump = 10f;

    /// <summary>
    /// mouvement
    /// </summary>
    private Vector2 movement;

    private bool grounded;
    private Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

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
            transform.position += Vector3.up * speedJump * Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }

}
