using UnityEngine;
using System.Collections;

public class SelfSpin : MonoBehaviour {
	public Vector3 rate;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (rate);
	}
}
