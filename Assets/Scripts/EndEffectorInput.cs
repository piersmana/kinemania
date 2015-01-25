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

	void Start() {
		mHandie = transform.parent.GetComponent<handie>();
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
