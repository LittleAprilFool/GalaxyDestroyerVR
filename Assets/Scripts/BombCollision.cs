using UnityEngine;
using System.Collections;
 
public class BombCollision : MonoBehaviour {

	public GameObject explosion;
	public string[] targetLayers;
	private bool[] isTargetLayer = new bool[32];

	// Use this for initialization
	void Start () {
		foreach (string layer in targetLayers) {
			isTargetLayer[LayerMask.NameToLayer(layer)] = true;
		}
	}
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log ("Hit: " + collision.gameObject.name);
		if (isTargetLayer[collision.gameObject.layer] || collision.gameObject.GetType() == gameObject.GetType()) {
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}

	void OnTriggerExit (Collider collision) {
		if (collision.gameObject.tag == "Boundary") {
			Destroy(gameObject);
			return;
		}
	}
}
