using UnityEngine;
using System.Collections;

public class EndEffectorInput : MonoBehaviour {

	public string horizontalInput;
	public string verticalInput;
	public float radius = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		float horizontal = Input.GetAxis(horizontalInput);
		float vertical = Input.GetAxis(verticalInput);

		Vector3 offset = new Vector3(horizontal, vertical, 0);

		// Update position from parent, ignoring rotation
		transform.position = transform.parent.position + offset * radius;
	}
}
