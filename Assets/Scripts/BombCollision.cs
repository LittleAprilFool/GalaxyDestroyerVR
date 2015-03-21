using UnityEngine;
using System.Collections;

public class BombCollision : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0) Destroy(gameObject);
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer("Target")) {
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
