using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	public float timetojumpApex = .4f;
	public float jumpHeight = 4;
	float moveSpeed = 6;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityxsmoothing;
	float acceleratonTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	Controller2D controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow(timetojumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timetojumpApex;
	}

	void Update () {

		if (controller.Collisions.above || controller.Collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space) && controller.Collisions.below) {
			velocity.y = jumpVelocity;
		}



		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityxsmoothing, (controller.Collisions.below) ? accelerationTimeGrounded : acceleratonTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}

}
