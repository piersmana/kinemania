using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FlickInput : MonoBehaviour {

	public int PlayerNumber; //Input source
	public float FlickCooldown = .5f;

	public float _flickForce = 1f;
	private Rigidbody2D _hand;

	void Awake() {
		_hand = GetComponent<Rigidbody2D>();
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
		_hand.AddForce(new Vector2(5,5) * _flickForce, ForceMode2D.Impulse);
		StopCoroutine("RechargeFlickPower");
		StartCoroutine("RechargeFlickPower");
	}

	IEnumerator RechargeFlickPower() {
		_flickForce = 0f;
		while (_flickForce <= 1f) {
			_flickForce += Time.deltaTime / FlickCooldown;
			yield return null;
		}
		_flickForce = 1f;
	}
}
