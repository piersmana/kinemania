using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool stage_complete;
	public TimerControl timer_control;
	private GameObject player;

	// Use this for initialization
	void Start () {
		timer_control.TimerStart();
		stage_complete = false;
		player = GameObject.Find("player_monkey");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < -20) {
			player.transform.position = new Vector3(0,0,0);
		}
		rigidbody2D.velocity = new Vector2( (player.transform.position.x - transform.position.x) , 0F);

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void youWin() {
		stage_complete = true;
	}
}
