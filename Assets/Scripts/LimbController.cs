using UnityEngine;
using System.Collections;

public class LimbController : MonoBehaviour {

	public string horizontalInput;
	public string verticalInput;
	public float force = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		// Apply input force
		float horizontal = Input.GetAxis(horizontalInput);
		float vertical = Input.GetAxis(verticalInput);

		if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0) {
			float angle = Mathf.Rad2Deg * ( Mathf.Atan2(-vertical, -horizontal) ) - 90;
			//Debug.Log("input angle: " + angle);

			float currentAngle = transform.rotation.eulerAngles.z;
			//Debug.Log("current angle: " + currentAngle);

			float maxDelta= force * Time.deltaTime;
			float dAngle = Mathf.DeltaAngle(currentAngle, angle); // Mathf.MoveTowardsAngle(currentAngle, angle, maxDelta);
			dAngle = Mathf.Clamp(dAngle, dAngle - maxDelta, dAngle + maxDelta);
			//Debug.Log("dAngle: " + dAngle + " maxDelta: " + maxDelta);
			rigidbody2D.AddTorque(dAngle);

			// Clamp angular velocity as we approach the target vector to avoid overswing
			if (dAngle < 5)
				rigidbody2D.angularVelocity = dAngle;
		}
	}
}
