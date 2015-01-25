using UnityEngine;
using System.Collections;

public class EndEffectorInput : MonoBehaviour {

	enum FlingState {
		None,
		InFling,
		Cooldown,
	}

	public string horizontalInput;
	public string verticalInput;
	public float radius = 1;
	public float cooldownTime = .5f;

	private FlingState flingState = FlingState.None;

	private float flingTimeRemaining = 0;
	private float cooldownRemaining = 0;

	private float previousMagnitude = 0;

	// Update is called once per frame
	void Update () {
	
		float horizontal = Input.GetAxis(horizontalInput);
		float vertical = Input.GetAxis(verticalInput);

		Vector3 offset = new Vector3(horizontal, vertical, 0);
		float magnitude = offset.magnitude;

		if (magnitude > .5f && flingTimeRemaining <= 0) {
			// Clamp magnitude to 50% after the cooldown period has ended
			offset = offset.normalized * .5f;
		}

		// Update position from parent, ignoring rotation
		transform.position = transform.parent.position + offset * radius;

		cooldownRemaining -= Time.deltaTime;
		if (cooldownRemaining < 0)
			cooldownRemaining = 0;
		flingTimeRemaining -= Time.deltaTime;
		if (flingTimeRemaining < 0)
			flingTimeRemaining = 0;

		if (cooldownRemaining <= 0 && magnitude > .75f && previousMagnitude < .75f) {
			// Count it as a fling
			flingTimeRemaining = cooldownTime;
			cooldownRemaining = cooldownTime * 5;
		}

		previousMagnitude = magnitude;
	}

}
