using UnityEngine;
using System.Collections;

public class ThrowingControl : MonoBehaviour {

	private Rigidbody cube;

	// Use this for initialization
	void Start () {
		cube = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {
			Debug.Log ("Throw!");
			cube.isKinematic = false;
			cube.velocity = new Vector3(0,0,10);
		}
	}

	void OnCollisionEnter () {
		Debug.Log ("Hit");
	}
}
