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

	private Vector3 deltaRecover, deltaFire, initScale;

	public float power {
		get { return 1 - transform.localScale.x / maxScale; }
	}
	
	public bool available {
		get { return transform.localScale.x < throttleScale; }
	}

	void Start() {
		deltaRecover = new Vector3(maxScale * recoverSpeed, 0f, 0f);
		deltaFire = new Vector3(maxScale * fireUsage, 0f, 0f);
		initScale = transform.localScale;
	}

	void FixedUpdate() {
		if (transform.localScale.x > 0)
			transform.localScale -= deltaRecover;
		if (transform.localScale.x < 0)
			transform.localScale = initScale;
	}

	public void Fire() {
		if (available) 
			transform.localScale += deltaFire;
	}

}
