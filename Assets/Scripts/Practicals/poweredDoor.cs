using UnityEngine;
using System.Collections;

public class poweredDoor : powered {

	public float open_theta; // Theta is the angular position
	public float open_omega; // Omega is the angular velocity. PHYSICS.

	public SliderJoint2D line_joint;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	protected new void Update () {
		base.Update();

		if (is_powered && open_theta < 1) {
			open_theta += open_omega;
		}
		if (!is_powered && open_theta > 0) {
			open_theta -= open_omega;
		}
		if (open_theta < 0) { open_theta = 0; }
		if (open_theta > 1) { open_theta = 1; }

		//line_joint.jointTranslation = open_theta * (line_joint.limits.max - 
		//line_joint.limits.min) + line_joint.limits.min;

		if (is_powered) {
			rigidbody2D.AddForce(10 * Vector2.up);
		}
		else {
			rigidbody2D.AddForce(10 * -Vector2.up);
		}
	}
}
