using UnityEngine;
using System.Collections;

public class winPlatform : MonoBehaviour {

	public Transform win_shower_whiskey;
	public Transform win_shower_banana;
	public bool has_won;

	// Use this for initialization
	void Start () {
		has_won = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D( Collider2D other ) {
		if ( !has_won && other.gameObject.name == "Body" ) {
			if ( other.rigidbody2D.velocity.magnitude <= 0.3 ) {
				Instantiate( win_shower_whiskey, new Vector3( 0, 12, -0.003F ),  Quaternion.identity );
				Instantiate( win_shower_banana, new Vector3( 0, 12, -0.003F ),  Quaternion.identity );
				has_won = true;
			}
		}
	}
}
