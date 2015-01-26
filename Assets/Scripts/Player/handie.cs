using UnityEngine;
using System.Collections;

public class handie : MonoBehaviour {

	public Rigidbody2D mainBody;

	private Vector3 mousePosition;
	public grabbable grabbed;
	public string grip_button;
	public Rigidbody2D fixedGrip;

	private DistanceJoint2D joint_latch;
	private int lift_max = 20;

	//private GameObject currentCollider;
	private bool isGrounded = false;

	// Use this for initialization
	void Start () {
		
		joint_latch = gameObject.AddComponent("DistanceJoint2D") as DistanceJoint2D;
		joint_latch.maxDistanceOnly = true;
		joint_latch.distance = 0.2F;
	}
	
	// Update is called once per frame
	void Update () {
		//mousePosition = Input.mousePosition;
		//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		//mousePosition.z = 0;

		//Vector2 leash_force = mousePosition - transform.position;
		//leash_force =  30 * Mathf.Sqrt( leash_force.magnitude ) * leash_force.normalized;

		// NO LONGER MOUSEFOLLOW
		//transform.rigidbody2D.AddForce( leash_force );

		//transform.position = mousePosition - grabbed.transform.position;



		if (!Input.GetButton( grip_button )) {
			fixedGrip.gameObject.SetActive(false);
			grabbed = null;
			joint_latch.enabled = false;
			joint_latch.connectedBody = null;
		} else if (!joint_latch.enabled && IsGrounded()) {

			Debug.Log(gameObject + " is grounded");
			// Nothing grabbed, but we received grab input.
			// Latch onto the ground using our fixed object, if we're grounded
			fixedGrip.transform.parent = null;
			fixedGrip.transform.position = transform.position;
			fixedGrip.gameObject.SetActive(true);

			joint_latch.enabled = true;
			//Vector2 hooke = 0; // 20 * (mousePosition - fixedGrip.transform.position);
			//Vector2 damp = - fixedGrip.velocity * fixedGrip.velocity.magnitude * 0.1F;
			//grabbed.rigidbody2D.AddForce( hooke + damp );
			joint_latch.connectedBody = fixedGrip;
		}

		if (grabbed != null) {
			joint_latch.enabled = true;
			Vector2 hooke = 20 * (mousePosition - grabbed.transform.position);
			Vector2 damp = - grabbed.rigidbody2D.velocity * grabbed.rigidbody2D.velocity.magnitude * 0.1F;
			//grabbed.rigidbody2D.AddForce( hooke + damp );
			joint_latch.connectedBody = grabbed.GetComponent<Rigidbody2D>();
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		//Debug.Log("Some kind of collision");
		Debug.Log(other);
		if (other.gameObject.GetComponent<grabbable>() != null && Input.GetButton( grip_button )){
			//Debug.Log("COLLIDER!!!");
			grabbed = other.gameObject.GetComponent<grabbable>();
		}
	}

	public bool IsGrounded() {
		int mask = 1 << LayerMask.NameToLayer("Ground");
		float radius = Mathf.Max(collider2D.bounds.size.x, collider2D.bounds.size.y);
		Collider2D colliders = Physics2D.OverlapCircle(transform.position, 
               radius, mask);
		return colliders != null;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
			isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
			isGrounded = false;
	}
}
