using UnityEngine;
using System.Collections;

public class RandomForces : MonoBehaviour {

	private float force = 100;

	// Use this for initialization
	IEnumerator Start () {
	
		while (true) {
			rigidbody2D.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * force);
			yield return new WaitForSeconds(Random.Range(1, 4));
		}
	}
}
