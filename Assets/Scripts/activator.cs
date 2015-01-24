using UnityEngine;
using System.Collections;

public class activator : MonoBehaviour {

	private bool is_active;

	// Use this for initialization
	void Start () {
		is_active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onOffToggle () {
		is_active = !is_active;
	}

	void turnOn () {
		is_active = true;
	}

	void turnOff () {
		is_active = false;
	}

	bool isActive() {
		return is_active;
	}
}
