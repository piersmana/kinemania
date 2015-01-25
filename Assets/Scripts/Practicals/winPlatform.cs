using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class winPlatform : powered {

	public Transform win_shower_whiskey;
	public Transform win_shower_banana;
	public bool has_won;

	public TimerControl timer_control;

	// Use this for initialization
	void Start () {
		has_won = false;
	}
	
	// Update is called once per frame
	protected new void Update () {
		base.Update();
	
	}

	void OnTriggerStay2D( Collider2D other ) {
		if ( !has_won && other.gameObject.name == "player_monkey" ) {
			if ( other.rigidbody2D.velocity.magnitude <= 0.3 && is_powered ) {
				timer_control.Stop ();
				Instantiate( win_shower_whiskey, new Vector3( transform.position.x, 12, -0.003F ),  Quaternion.identity );
				Instantiate( win_shower_banana, new Vector3( transform.position.x, 12, -0.003F ),  Quaternion.identity );
				has_won = true;
			}
		}
	}
}
