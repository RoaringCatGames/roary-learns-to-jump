using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public Transform groundCheck;
	public float jumpForce = 500f;
	public float moveForce = 400f;
	public float maxSpeed = 5f;
	

	private bool isGrounded = false;
	private bool shouldJump = false;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		foreach(string name in Input.GetJoystickNames()){
			Debug.Log("Joystick Button: " + name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer(Layer.Platform));
		if(isGrounded && Input.GetButtonDown(Action.Jump)){
			shouldJump = true;
		}

		for(int i = 0;i < 20; i++) {
				if(Input.GetKeyDown("joystick 1 button " + i)){
						print("joystick 1 button " + i);
				}
		}
	}

	void FixedUpdate(){

		float h = Input.GetAxis(Action.Move);

		if (h * rigidBody.velocity.x < maxSpeed)
				rigidBody.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rigidBody.velocity.x) > maxSpeed)
				rigidBody.velocity = new Vector2(Mathf.Sign (rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);

		if(shouldJump) {
			rigidBody.AddForce(new Vector2(0f, jumpForce));
			shouldJump = false;
		}		
	}
}
