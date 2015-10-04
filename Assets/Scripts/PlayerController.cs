using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	public bool grounded = false;
	[SerializeField]
	Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public bool facingRight = true;

	float horizontal;

	// internal reference
	Rigidbody2D rb2D;

	void Awake(){
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Update(){
		horizontal = Input.GetAxis("Horizontal");
		// should create keymap instead of hard coding J
		if(grounded && Input.GetKeyDown(KeyCode.J)){
			rb2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	void FixedUpdate(){
		// checking is grounded
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		// movement
		rb2D.velocity = new Vector2(horizontal * maxSpeed, rb2D.velocity.y);

		// should use keymapping
		// starfing, when firing, don't change direction
		if(!Input.GetKey(KeyCode.K)){
			if (horizontal > 0 && !facingRight){
				Flip();
			}
			else if (horizontal < 0 && facingRight){
				Flip();
			}
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x  *= -1;
		transform.localScale = theScale;
	}
}
