using UnityEngine;
using System.Collections;
 
public class RocketCollision : MonoBehaviour {

	public GameObject explosion;
	public string[] targetLayers;

	private bool[] isTargetLayer = new bool[32];
	private EnemyController enemyControl;
	private PlanetController planetControl;

	// Use this for initialization
	void Start () {
		foreach (string layer in targetLayers) {
			isTargetLayer[LayerMask.NameToLayer(layer)] = true;
		}
		enemyControl = GameObject.Find("/Enemy").GetComponent<EnemyController>();
		planetControl = GameObject.Find("/Planets").GetComponent<PlanetController>();
	}

	void OnCollisionEnter (Collision collision) {
		if (Debug.isDebugBuild)
			Debug.Log ("Hit: " + collision.gameObject.name);
		if (isTargetLayer[collision.gameObject.layer] || collision.gameObject.GetType() == gameObject.GetType()) {
			GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy(explosionInstance, 10);

			if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
				enemyControl.DestroyEnemy();
				Destroy(collision.gameObject);
			}

			if (collision.gameObject.layer == LayerMask.NameToLayer("Planet")) {
				// planet collider is inside a parent planet object
				Destroy(collision.gameObject.transform.parent.gameObject);
			}

			if (!enemyControl.hasEnemy && !planetControl.hasPlanet)
				Application.LoadLevel("WinScene");

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
