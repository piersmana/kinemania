using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class powered : MonoBehaviour {

	public List<powerSource> powered_by;
	public bool is_powered;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
		bool power_check = true;
		foreach ( powerSource power_source in powered_by ) {
			if (!power_source.is_on) {
				power_check = false;
			}
		}
		is_powered = power_check;
	}
}
