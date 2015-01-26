using UnityEngine;
using System.Collections;

public class EndEffectorInput : MonoBehaviour {

	public string horizontalInput;
	public string verticalInput;
	public float radius = 1;
	public float cooldownTime = .5f;

	private float flingTimeRemaining = 0;
	private float cooldownRemaining = 0;

	private float previousMagnitude = 0;

	private handie mHandie;

	// CRAZY SPRING PHYSICS HACKING
	// attempting to stabilize forces tumbling through the air
	private Rigidbody2D opposingSpring;

	void Start() {
		mHandie = transform.parent.GetComponent<handie>();

		GameObject obj = new GameObject("OposingSpring");
		opposingSpring = obj.AddComponent<Rigidbody2D>();
		opposingSpring.mass = rigidbody2D.mass;
		opposingSpring.isKinematic = true;
		opposingSpring.fixedAngle = true;

		opposingSpring.transform.parent = transform.parent;
		opposingSpring.gameObject.SetActive(false);

		SpringJoint2D counterSpring = mHandie.mainBody.gameObject.AddComponent<SpringJoint2D>();
		counterSpring.connectedBody = opposingSpring;
		counterSpring.dampingRatio = mHandie.GetComponent<SpringJoint2D>().dampingRatio;// / 2;
		counterSpring.frequency = .01f;// mHandie.GetComponent<SpringJoint2D>().frequency / 10;
		counterSpring.distance = mHandie.GetComponent<SpringJoint2D>().distance;
	}

	// Update is called once per frame
	void Update () {
	
		cooldownRemaining -= Time.deltaTime;
		if (cooldownRemaining < 0)
			cooldownRemaining = 0;
		flingTimeRemaining -= Time.deltaTime;
		if (flingTimeRemaining < 0)
			flingTimeRemaining = 0;

		// Update input
		float horizontal = Input.GetAxis(horizontalInput);
		float vertical = Input.GetAxis(verticalInput);

		if (mHandie.IsGrounded()) {
			//horizontal = 0;
		} else {
			opposingSpring.gameObject.SetActive(true);

			Vector3 dbody = mHandie.transform.position /* mHandie.mainBody.transform.position */ - transform.position;
			opposingSpring.transform.position = mHandie.mainBody.transform.position + dbody;
		}

		Vector3 offset = new Vector3(horizontal, vertical, 0);
		float magnitude = offset.magnitude;

		if (magnitude > .5f && flingTimeRemaining <= 0) {
			// Clamp magnitude to 50% after the cooldown period has ended
			offset = offset.normalized * .5f;
		} else if (flingTimeRemaining > 0) {
			//offset = offset.normalized * 2;
		}

		if (magnitude > .5f && mHandie.IsGrounded()) { // cooldownRemaining <= 0 && magnitude > .75f && previousMagnitude < .75f) {
			// Count it as a fling
			Debug.Log("Fling! " + gameObject + ":" + transform.parent.gameObject + " " + offset);
			mHandie.mainBody.AddForce(new Vector2(offset.x * 2, offset.y * 500)); // allow some jumping off the ground without crazy dragging along x

			flingTimeRemaining = cooldownTime;
			cooldownRemaining = cooldownTime * 5;
		}

		previousMagnitude = magnitude;

		// Update position from parent, ignoring rotation
		transform.position = transform.parent.position + offset * radius;
	}

}
