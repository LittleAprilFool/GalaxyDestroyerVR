using UnityEngine;
using System.Collections;

public class SelfScale : MonoBehaviour {

	public Vector3 finalscale;
	private Vector3 originscale;
	private Vector3 scalespeed;
	public int time;
	private bool way;
	void Start(){
		originscale = transform.localScale;
		scalespeed = finalscale / time;
		way = true;
	}

	void Update(){
		if (way) {
			transform.localScale += scalespeed;
			if (transform.localScale.x > finalscale.x) {
				transform.localScale = finalscale;
				way = false;
			}
		} else {
			transform.localScale -= scalespeed;
			if (transform.localScale.x < originscale.x) {
				transform.localScale = originscale;
				way = true;
			}
		}

	}


}
