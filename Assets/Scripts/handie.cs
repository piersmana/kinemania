using UnityEngine;
using System.Collections;

public class handie : MonoBehaviour {

	private Vector3 mousePosition;
	public grabbable grabbed;
	private int lift_max = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		mousePosition.z = 0;
		transform.position = mousePosition;

		if (!Input.GetMouseButton( 0 )) {
			grabbed = null;
		}
		if (grabbed != null) {
			Vector2 hooke = 20 * (mousePosition - grabbed.transform.position);
			Vector2 damp = - grabbed.rigidbody2D.velocity * grabbed.rigidbody2D.velocity.magnitude * 0.1F;
			grabbed.rigidbody2D.AddForce( hooke + damp );
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		Debug.Log("Some kind of collision");
		if (other.gameObject.GetComponent<grabbable>() != null && Input.GetMouseButton( 0 )){
			Debug.Log("COLLIDER!!!");
			grabbed = other.gameObject.GetComponent<grabbable>();
		}
	}
}
