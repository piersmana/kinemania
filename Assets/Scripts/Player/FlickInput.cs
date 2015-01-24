using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FlickInput : MonoBehaviour {

	public int PlayerNumber; //Input source
	public float FlickCooldown = .2f;
	
	private Rigidbody2D hand;

	void Awake() {
		hand = GetComponent<Rigidbody2D>();
	}

	void Start () {
		StartCoroutine(DetectInput ());
	}

	IEnumerator DetectInput() {
		while (true) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				yield return StartCoroutine(DetectInputEnd());
			}
			yield return null;
		}
	}

	IEnumerator DetectInputEnd() {
		while (true) {
			if (Input.GetKeyUp (KeyCode.Space)) {
				break;
			}
			yield return null;
		}
		//Apply force to hand
		hand.AddForce(new Vector2(5,5), ForceMode2D.Impulse);
		
		yield return new WaitForSeconds(FlickCooldown);
	}
}
