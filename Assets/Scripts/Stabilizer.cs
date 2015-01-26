using UnityEngine;
using System.Collections;

public class Stabilizer : MonoBehaviour {


	private Vector3[] stableTransforms;
	private Quaternion[] stableOrientations;

	public float strength = 1;

	void Start() {

		// Grab initial (stable) transforms
		Transform[] xforms = transform.GetComponentsInChildren<Transform>();
		stableTransforms = new Vector3[xforms.Length];
		stableOrientations = new Quaternion[xforms.Length];

		for (int i = 0; i < xforms.Length; i++) {
			stableTransforms[i] = xforms[i].transform.localPosition;
			stableOrientations[i] = xforms[i].transform.localRotation;
		}
	}

	// Update is called once per frame
	void Update () {

		Transform[] xforms = transform.GetComponentsInChildren<Transform>();
		for (int i = 0; i < xforms.Length; i++)
		{
			// Apply stabilizing force to all rigid bodies
			Vector3 d = stableTransforms[i] - xforms[i].localPosition;
			//Quaternion dq = stableOrientations[i] - xforms[i].localRotation;

			float maxDelta = strength * Time.deltaTime;
			float dAngle = Mathf.DeltaAngle(xforms[i].localRotation.eulerAngles.z, stableOrientations[i].eulerAngles.z);
			dAngle = Mathf.Clamp(dAngle, dAngle - maxDelta, dAngle + maxDelta);
			//Debug.Log("dAngle: " + dAngle + " maxDelta: " + maxDelta);
			rigidbody2D.AddTorque(dAngle);
			
			// Clamp angular velocity as we approach the target vector to avoid overswing
			//if (dAngle < 5)
			//	rigidbody2D.angularVelocity = dAngle;

			//if (Vector3.SqrMagnitude(d) > 0.001f) {
				//xforms[i].rigidbody2D.AddForce(new Vector2(d.x, d.y) * Time.deltaTime * strength);


			//}
		}

		// Stabilize root position
	}
}
