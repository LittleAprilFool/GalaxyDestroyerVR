// README
//
// return power
// public float Power()
//
// return avaliable or not
// public bool Avaliable()
//
// after shoot something
// public void Active()

using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {
	public float maxScale;
	public float throttleScale;

	public float fireUsage;
	public float recoverSpeed;

	public float Power {
		get { return 1 - transform.localScale.x / maxScale; }
	}

	void Update() {
		//if (Input.GetMouseButtonDown(0))
		//	Fire();
	}

	void FixedUpdate(){
		if (transform.localScale.x > 0) transform.localScale -= new Vector3(maxScale * recoverSpeed, 0, 0);
	}

	public void Fire(){
		if (Available()) 
			transform.localScale += new Vector3(maxScale * fireUsage, 0, 0);
	}

	public bool Available(){
		return transform.localScale.x < throttleScale;
	}
}
