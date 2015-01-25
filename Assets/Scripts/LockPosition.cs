using UnityEngine;
using System.Collections;

public class LockPosition : MonoBehaviour {

	public Transform parent;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = parent.transform.position + offset;
	}
}
