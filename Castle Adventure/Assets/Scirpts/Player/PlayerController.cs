using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed, jumpSpeed;
	public LayerMask whatToHit;
	public Transform groundCheck;
	public bool canControl = true;
	public bool grounded = true;

	private Rigidbody2D player;
	private Animator anim;
	private bool doubleJump = true;
	void Awake()
	{
		player = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		CheckGrounded ();

		if (player.velocity.y < -16) {
			Vector3 temp = player.velocity;
			temp.y = -16;
			player.velocity = temp;
		}

		if (canControl) {
			Move ();
			Jump ();
			setAnimator ();
		}
	}

	void CheckGrounded()
	{
		bool ground1, ground2, ground3;

		Vector3 newPos = transform.position + new Vector3 (0, -0.5f, 0);
		Vector3 newPos2 = transform.position + new Vector3 (0.15f, -0.5f, 0);
		Vector3 newPos3 = transform.position + new Vector3 (-0.15f, -0.5f, 0);

		ground1 = Physics2D.Linecast (this.transform.position, newPos, 1<<LayerMask.NameToLayer("ground"));
		ground2 = Physics2D.Linecast (this.transform.position, newPos2, 1<<LayerMask.NameToLayer("ground"));
		ground3 = Physics2D.Linecast (this.transform.position, newPos3, 1<<LayerMask.NameToLayer("ground"));

		Debug.DrawLine (transform.position, newPos, Color.green);
		Debug.DrawLine (transform.position, newPos2, Color.green);
		Debug.DrawLine (transform.position, newPos3, Color.green);

		grounded = ground1 || ground2 || ground3;
	}

	void Move()
	{
		float dir = Input.GetAxisRaw ("Horizontal");
		player.velocity = new Vector2 (dir * speed, player.velocity.y);

		if (dir < 0) {
			Vector3 temp = transform.localScale;
			temp.x = 1;
			transform.localScale = temp;
		}

		if (dir > 0) {
			Vector3 temp = transform.localScale;
			temp.x = -1;
			transform.localScale = temp;
		}
	}

	void Jump()
	{
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			//grounded = false;
			player.velocity = new Vector2 (player.velocity.x, jumpSpeed);
			doubleJump = false;
		}

		if (!grounded && !doubleJump) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				player.velocity = new Vector2 (player.velocity.x, jumpSpeed);
				doubleJump = true;
			}
		}
	}
	/*
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			grounded = false;
		}
	}
*/
	public void setDefault()
	{
		player.velocity = new Vector2(0, 0);
	}

	void setAnimator()
	{
		anim.SetFloat ("speed", Mathf.Abs(player.velocity.x));
		anim.SetFloat ("speed y", player.velocity.y);
		anim.SetBool ("grounded", grounded);

	}
}
