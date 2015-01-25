using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class winPlatform : MonoBehaviour {

	public Transform win_shower_whiskey;
	public Transform win_shower_banana;
	public bool has_won;

	public TimerControl timer_control;
	public string nextScene;

	// Use this for initialization
	void Start () {
		has_won = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D( Collider2D other ) {
		if ( !has_won && other.gameObject.name == "player_monkey" ) {
			if ( other.rigidbody2D.velocity.magnitude <= 0.3 ) {
				timer_control.Stop ();
				Instantiate( win_shower_whiskey, new Vector3( 0, 12, -0.003F ),  Quaternion.identity );
				Instantiate( win_shower_banana, new Vector3( 0, 12, -0.003F ),  Quaternion.identity );
				has_won = true;
				StartCoroutine(NextLevel());
			}
		}
	}

	IEnumerator NextLevel() {
		yield return new WaitForSeconds(4f);
		Application.LoadLevel(nextScene);
	}
}
