using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public float timeout = 10;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(timeout);
		var systems = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem system in systems) system.Clear();
		Destroy(gameObject);
	}

}
