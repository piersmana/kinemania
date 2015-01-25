using UnityEngine;
using System.Collections;

public class handie : MonoBehaviour {

	private Vector3 mousePosition;
	public grabbable grabbed;
	private DistanceJoint2D joint_latch;
	private int lift_max = 20;
	// Use this for initialization
	void Start () {
		
		joint_latch = gameObject.AddComponent("DistanceJoint2D") as DistanceJoint2D;
		joint_latch.maxDistanceOnly = true;
		joint_latch.distance = 0.2F;
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		mousePosition.z = 0;

		Vector2 leash_force = mousePosition - transform.position;
		leash_force =  30 * Mathf.Sqrt( leash_force.magnitude ) * leash_force.normalized;
		transform.rigidbody2D.AddForce( leash_force );
		//transform.position = mousePosition - grabbed.transform.position;

		if (!Input.GetMouseButton( 0 )) {
			grabbed = null;
			joint_latch.enabled = false;
			joint_latch.connectedBody = null;
		}
		if (grabbed != null) {
			joint_latch.enabled = true;
			Vector2 hooke = 20 * (mousePosition - grabbed.transform.position);
			Vector2 damp = - grabbed.rigidbody2D.velocity * grabbed.rigidbody2D.velocity.magnitude * 0.1F;
			grabbed.rigidbody2D.AddForce( hooke + damp );
			joint_latch.connectedBody = grabbed.GetComponent<Rigidbody2D>();
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
