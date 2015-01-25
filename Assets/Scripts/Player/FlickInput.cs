using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FlickInput : MonoBehaviour {

	public string LimbName;
	public float FlickCooldown = .5f;
	public float ForceMagnitude = 10f;

	private float _flickForce = 1f;
	public Vector2 jointpos;

	private float prevmagnitude = 0;
	private float currmagnitude = 0;
	private Vector2 laststickpos = Vector2.zero;
	private Vector2 currstickpos = Vector2.zero;

	private string _XAxis;
	private string _YAxis;

	private Rigidbody2D _hand;
	private Rigidbody2D _body;

	void Awake() {
		_hand = GetComponent<Rigidbody2D>();
		_body = this.transform.parent.parent.FindChild("Body").GetComponent<Rigidbody2D>();

		_XAxis = LimbName + " X";
		_YAxis = LimbName + " Y";
	}

	void Start () {
		StartCoroutine(DetectAcceleration());
	}

	IEnumerator DetectAcceleration() {
		while (true) {
			laststickpos = currstickpos;
			prevmagnitude = currmagnitude;
			currstickpos = new Vector2(Input.GetAxis(_XAxis), Input.GetAxis(_YAxis));
			currmagnitude = (currstickpos - laststickpos).magnitude;
			if (prevmagnitude > currmagnitude) {
				
				Vector2 impulse = ForceMagnitude * (currstickpos - laststickpos).normalized * _flickForce;
				Vector2 handtobody = transform.position - _body.transform.position * ForceMagnitude * _flickForce;
				
				//Apply force to hand
				_hand.AddForce(impulse, ForceMode2D.Impulse);
				_body.AddForceAtPosition(-impulse, (Vector2)_body.transform.position + jointpos, ForceMode2D.Impulse);
				StopCoroutine("RechargeFlickPower");
				StartCoroutine("RechargeFlickPower");
			}
			yield return null;
		}
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
