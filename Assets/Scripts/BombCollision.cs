using UnityEngine;
using System.Collections;
 
public class BombCollision : MonoBehaviour {

	public GameObject explosion;
	public string[] targetLayers;

	private bool[] isTargetLayer = new bool[32];
	private EnemyAppear enemyControl;

	public void setEnemyControl(EnemyAppear e) {
		enemyControl = e;
	}

	// Use this for initialization
	void Start () {
		foreach (string layer in targetLayers) {
			isTargetLayer[LayerMask.NameToLayer(layer)] = true;
		}
	}

	IEnumerator DestroyParticleSystems(GameObject explosionInstance) {
		Debug.Log(1);
		yield return new WaitForSeconds(10);
		Debug.Log(2);
		var systems = explosionInstance.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem system in systems) system.Clear();
		Destroy(explosionInstance);
		yield return null;
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("Hit: " + collision.gameObject.name);
		if (isTargetLayer[collision.gameObject.layer] || collision.gameObject.GetType() == gameObject.GetType()) {
			if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
				enemyControl.destroyEnemy();
			}
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
