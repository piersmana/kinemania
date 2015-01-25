using UnityEngine;
using System.Collections;

public class vine : MonoBehaviour {

	public int vine_length;
	// Use this for initialization
	void Start () {
		int i = 0;
		Transform vine_prime = transform.Find("vine_segment");
		Debug.Log(vine_prime);
		vine_prime.gameObject.GetComponent<HingeJoint2D>().connectedAnchor = (Vector2)transform.position;
		Transform vine_pointer = vine_prime;
		Transform vine_new = vine_prime;
		SpriteRenderer prime_image = vine_prime.GetComponent<SpriteRenderer>();
		float segment_length = ((prime_image.bounds.max - prime_image.bounds.min).y)*1.15F;
		for (i =0; i< vine_length; i ++) {
			Debug.Log("New vine segment");
			vine_pointer.position = new Vector3( 0, i * segment_length, 0 );
			vine_pointer = vine_new;
			vine_new = Instantiate( vine_prime, new Vector3( 0F,0F,0F ), Quaternion.identity ) as Transform;
			HingeJoint2D new_hinge = vine_new.GetComponent<HingeJoint2D>();
			new_hinge.anchor = new Vector2(0, segment_length );
			new_hinge.connectedAnchor = new Vector2(0, -segment_length);
			new_hinge.connectedBody = vine_pointer.rigidbody2D;
			vine_new.parent = transform;
			vine_new.name = "vine_segment"+i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
