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
			GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal, vertical) * force);
		}
	}
}
