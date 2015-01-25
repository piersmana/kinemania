using UnityEngine;
using System.Collections;

public class LockPosition : MonoBehaviour {

	public Transform parent;
	public MonkeyInput monkeyInput;

	private Vector3 offset;

	private SpringJoint2D stabilizingJoint;

	void Awake() {
		stabilizingJoint = monkeyInput.GetComponent<SpringJoint2D>();
	}

	// Use this for initialization
	void Start () {
		offset = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Disable floating when not grounded
		stabilizingJoint.enabled = monkeyInput.IsGrounded();

		transform.position = parent.transform.position + offset;
	}
}
