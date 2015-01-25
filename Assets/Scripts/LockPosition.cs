using UnityEngine;
using System.Collections;

public class LockPosition : MonoBehaviour {

	public Transform parent;
	public MonkeyInput monkeyInput;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Disable floating when not grounded
		monkeyInput.GetComponent<SpringJoint2D>().enabled = monkeyInput.IsGrounded();

		transform.position = parent.transform.position + offset;
	}
}
