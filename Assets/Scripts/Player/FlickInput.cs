using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FlickInput : MonoBehaviour {

	public int PlayerNumber; //Input source
	public float FlickCooldown = .5f;
	public float ForceMagnitude = 10f;

	public float _flickForce = 1f;
	public Vector2 direction = new Vector2(0,-1);
	public Vector2 jointpos;
	private Rigidbody2D _hand;
	private Rigidbody2D _body;

	void Awake() {
		_hand = GetComponent<Rigidbody2D>();
		_body = this.transform.parent.parent.FindChild("Body").GetComponent<Rigidbody2D>();
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

		Vector2 impulse = ForceMagnitude * direction * _flickForce;
		Vector2 handtobody = transform.position - _body.transform.position * ForceMagnitude * _flickForce;

		//Apply force to hand
		_hand.AddForce(impulse, ForceMode2D.Impulse);
		_body.AddForceAtPosition(-impulse, (Vector2)_body.transform.position + jointpos, ForceMode2D.Impulse);
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
