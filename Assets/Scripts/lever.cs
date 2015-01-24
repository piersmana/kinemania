using UnityEngine;
using System.Collections;

public class lever : powerSource {

	public GameObject lever_base;

	// Use this for initialization
	void Start () {
		if ( is_on ) {
			lever_base.GetComponent<SpriteRenderer>().sprite = lever_base.GetComponent<leverBase>().onState;
		}
		else {
			lever_base.GetComponent<SpriteRenderer>().sprite = lever_base.GetComponent<leverBase>().offState;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( gameObject.GetComponent<HingeJoint2D>().jointAngle < -80 && !is_on) {
			is_on = true;
			lever_base.GetComponent<SpriteRenderer>().sprite = lever_base.GetComponent<leverBase>().onState;
		}
		if ( gameObject.GetComponent<HingeJoint2D>().jointAngle > -80 && is_on) {
			is_on = false;
			lever_base.GetComponent<SpriteRenderer>().sprite = lever_base.GetComponent<leverBase>().offState;
		}
	}
}
