using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour {

	private float time = 0f;
	private Text _t;

	void Awake() {
		_t = GetComponent<Text>();
	}

	public float TimerStart() {
		StopCoroutine("IncrementTimer");
		StartCoroutine("IncrementTimer");
		return time;
	}
	
	public float TimerStart(float startAt) {
		time = startAt;
		StopCoroutine("IncrementTimer");
		StartCoroutine("IncrementTimer");
		return time;
	}

	public float Pause() {
		StopCoroutine("IncrementTimer");
		return time;
	}

	public float Stop() {
		StopCoroutine("IncrementTimer");
		BlinkTimer();
		_t.color = Color.red;
		return time;
	}

	void Update() {
		_t.text = time.ToString();
	}

	IEnumerator IncrementTimer() {
		while (true) {
			time += Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator BlinkTimer() {
		while (true) {
			_t.enabled = !_t.enabled;
			yield return new WaitForSeconds(.5f);
		}
	}
}
