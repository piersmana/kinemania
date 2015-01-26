using UnityEngine;
using UnityEngine.UI;

using System.Collections;

// UGLY HACKED UP SHIT INCOMING
public class StartScreen : MonoBehaviour {

	public SpriteRenderer startButton;
	public SpriteRenderer quitButton;
	public SpriteRenderer creditsButton;

	private SpriteRenderer[] buttons;

	int current = 0;

	// Use this for initialization
	void Start () {
		buttons = new SpriteRenderer[] {
			startButton,
			creditsButton,
			quitButton
		};
	}

	float nextTime = 0;
	int previous = -1;

	public GameObject creditsImage;

	private float prevHoriz = 0;

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Action Button")) {
			if (current == 0) {
				Application.LoadLevel("level_1");
			} else if (current == 1) {
				creditsImage.SetActive(!creditsImage.activeSelf);
			} else if (current == 2) {
				Application.Quit();
			}
		}

		if (creditsImage.activeSelf)
			return;

	
		float horizontal = Input.GetAxis("Left Hand X") + Input.GetAxis("Left Foot X");
		float vertical = Input.GetAxis("Left Hand Y") + Input.GetAxis("Right Foot Y");

		if ((prevHoriz < -.5f || prevHoriz > .5f) && Time.time < nextTime)
			return;

		prevHoriz = horizontal;

		if (horizontal > .5f) {
			current++;
			if (current >= buttons.Length)
				current = 0;
		}
		else if (horizontal < -.5f) {
			current--;
			if (current < 0)
				current = buttons.Length - 1;
		}

		if (previous != current) {

			if (previous >= 0) {
				buttons[previous].color = Color.white;
			}
			buttons[current].color = new Color(.6f, .6f, 1f);

			previous = current;
		}

		nextTime = Time.time + .3f;
	}
}
