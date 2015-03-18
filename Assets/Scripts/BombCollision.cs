using UnityEngine;
using System.Collections;

public class BombCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0) Destroy(gameObject);
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer("Target")) {
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
