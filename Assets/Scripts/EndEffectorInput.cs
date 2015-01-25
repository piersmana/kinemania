using UnityEngine;
using System.Collections;

public class EndEffectorInput : MonoBehaviour {

	public string horizontalInput;
	public string verticalInput;
	public float radius = 1;
	public float cooldownTime = 3;

	private float cooldownRemaining = 0;
	
	// Update is called once per frame
	void Update () {
	
		float horizontal = Input.GetAxis(horizontalInput);
		float vertical = Input.GetAxis(verticalInput);

		Vector3 offset = new Vector3(horizontal, vertical, 0);
		float magnitude = offset.magnitude;

		if (magnitude > .5f) {
			// Incur a larger penalty for bigger flings
			cooldownRemaining = cooldownTime * magnitude;
		}
		float cooldownPenalty = cooldownRemaining / cooldownTime;

		// Update position from parent, ignoring rotation
		transform.position = transform.parent.position + offset * radius * (1 - cooldownPenalty);

		cooldownRemaining -= Time.deltaTime;
		if (cooldownRemaining < 0)
			cooldownRemaining = 0;
	}
}
