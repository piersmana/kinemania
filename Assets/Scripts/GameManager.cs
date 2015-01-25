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
		player = GameObject.Find("MonkeyPrefab");
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2( (player.transform.position.x - transform.position.x) / 4 , 0F);
	}

	void youWin() {
		stage_complete = true;
	}
}
