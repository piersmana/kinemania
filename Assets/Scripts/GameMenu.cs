using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMenu : MonoBehaviour {

	public float loadup;
	public Transform the_credits;
	public Transform the_menu;
	public List<Transform> menu_buttons;

	public string first_level_name;

	// Use this for initialization
	void Start () {
		loadup = 0F;
		the_menu.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (the_menu.GetComponent<SpriteRenderer>().enabled == true) {

			if ( loadup > 0 ) {
				loadup -= 0.005F;
				the_menu.GetComponent<SpriteRenderer>().color = new Color( 1F, 1F, 1F, 1F - loadup );
				the_credits.GetComponent<SpriteRenderer>().color = new Color( 1F, 1F, 1F, loadup );
			}
		}
		else {
			loadup += 0.015F;
			the_credits.GetComponent<SpriteRenderer>().color = new Color( 1F, 1F, 1F, loadup );
			if (loadup >= 1F) {
				
				the_menu.GetComponent<SpriteRenderer>().enabled = true;
				StartCoroutine("PressAButton");
				the_menu.GetComponent<SpriteRenderer>().color = new Color( 1F, 1F, 1F, 0 );
			}
		}
	}

	IEnumerator PressAButton() {

		SpriteRenderer press_a_indicator = menu_buttons[0].GetComponent<SpriteRenderer>();
		press_a_indicator.enabled = true;
		while ( !Input.GetButton("Action Button")  && !Input.GetKey( "return" )) {
			float fade_factor = Mathf.Cos( 0.3F * Time.time * Mathf.PI );
			fade_factor = fade_factor * fade_factor;
			press_a_indicator.color = new Color(1F, 1F, 1F, fade_factor);
			yield return null;
		}
		Application.LoadLevel (first_level_name);
	}
}
