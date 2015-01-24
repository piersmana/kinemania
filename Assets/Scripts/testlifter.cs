using UnityEngine;
using System.Collections; 

public class testlifter : MonoBehaviour {

	public int lift_force;
	public grabbable grabbed;

	// Use this for initialization
	void Start () {
		lift_force = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey("u")) {
			lift_force = 20;
			Debug.Log( "Big force" );
		}
		else if ( Input.GetKey("j")) {
			lift_force = 10;
		}
		else if ( Input.GetKey("m")) {
			lift_force = 5;
		}
		else {
			lift_force = 0;
		}

		if (grabbed != null) {
			grabbed.rigidbody2D.AddForce( Vector2.up * lift_force);
		}
	}
}
