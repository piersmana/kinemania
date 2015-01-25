using UnityEngine;
using System.Collections;

public class lever : powerSource {

	public GameObject lever_base;
	public int id;
	static public int max_id;

	// Use this for initialization
	void Start () {
		if ( is_on ) {
			lever_base.GetComponent<SpriteRenderer>().sprite = lever_base.GetComponent<leverBase>().onState;
		}
		else {
			lever_base.GetComponent<SpriteRenderer>().sprite = lever_base.GetComponent<leverBase>().offState;
		}
		if (id > max_id) {
			max_id = id;
		}
		if (id <= 0) {
			id = max_id + 1;
			max_id += 1;
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
