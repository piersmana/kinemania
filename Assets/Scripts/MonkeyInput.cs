using UnityEngine;
using System.Collections;

public class MonkeyInput : MonoBehaviour {

	public handie leftHand;
	public handie rightHand;
	public handie leftFoot;
	public handie rightFoot;

	private EndEffectorInput leftHandEnd;
	private EndEffectorInput rightHandEnd;
	private EndEffectorInput leftFootEnd;
	private EndEffectorInput rightFootEnd;

	// Use this for initialization
	void Start () {
		leftHandEnd = leftHand.GetComponentInChildren<EndEffectorInput>();
		rightHandEnd = rightHand.GetComponentInChildren<EndEffectorInput>();
		leftFootEnd = leftFoot.GetComponentInChildren<EndEffectorInput>();
		rightFootEnd = rightFoot.GetComponentInChildren<EndEffectorInput>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Swap Input"))
		{
			// Swap feet and hand input controls
			Swap(ref leftHand.grip_button, ref leftFoot.grip_button);
			Swap(ref rightHand.grip_button, ref rightFoot.grip_button);

			Swap(ref leftHandEnd.horizontalInput, ref leftFootEnd.horizontalInput);
			Swap(ref leftHandEnd.verticalInput, ref leftFootEnd.verticalInput);

			Swap(ref rightHandEnd.horizontalInput, ref rightFootEnd.horizontalInput);
			Swap(ref rightHandEnd.verticalInput, ref rightFootEnd.verticalInput);
		}
	}

	void Swap(ref string a, ref string b) {
		string temp = a;
		a = b;
		b = temp;
	}
}
