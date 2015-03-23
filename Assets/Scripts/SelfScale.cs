using UnityEngine;
using System.Collections;

public class SelfScale : MonoBehaviour {

	public Vector3 finalscale;
	private Vector3 originscale;
	private Vector3 scalespeed;
	public int time;
	private bool direction;

	void Start(){
		originscale = transform.localScale;
		scalespeed = finalscale / time;
		direction = true;
	}

	void FixedUpdate(){
		if (direction) {
			transform.localScale += scalespeed;
			if (transform.localScale.x > finalscale.x) {
				transform.localScale = finalscale;
				direction = false;
			}
		} else {
			transform.localScale -= scalespeed;
			if (transform.localScale.x < originscale.x) {
				transform.localScale = originscale;
				direction = true;
			}
		}
	}

}
