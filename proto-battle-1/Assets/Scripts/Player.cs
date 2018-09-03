using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim; // TODO: Add animation

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // TODO: Create custom jump button in input manager.
		if(grounded && Input.GetKeyDown(KeyCode.Space)) {
            // anim.SetBool("Grounded", false); // uncomment after animation is added.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
	}

    void FixedUpdate () {
        // Do groundcheck first.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        print(grounded);
        //anim.SetBool("Ground", grounded); // Uncomment after animations are setup.
        


        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight) {
            Flip();
        } else if (move < 0 && facingRight){
            Flip();
        }
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
