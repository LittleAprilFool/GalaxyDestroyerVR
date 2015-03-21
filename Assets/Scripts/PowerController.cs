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
	public Vector3 scaleEnd;
	public float time;
	public float power;
	private float morethan;
	public Vector3 limitx;
	public Vector3 maxx;
	public Vector3 gap;
	public Vector3 speed;

	public float Power {
		get { return power; }
	}

	void Start(){
		power = 1;
	}
	
	void Update(){
		if(transform.localScale.x > 0f) transform.localScale -= speed;
		if (transform.localScale.x < 0f)
			transform.localScale = scaleEnd;
		power = 1 - transform.localScale.x / maxx.x;
//		if (Input.GetMouseButtonDown(0))
//			Active();
	}

	public void Active(){
		if (transform.localScale.x < maxx.x) 
			transform.localScale += gap;
		if (transform.localScale.x > maxx.x) 
			transform.localScale = maxx;
	}

	public bool Avaliable(){
		if (transform.localScale.x > limitx.x)
			return false;
		else
			return true;
	}
}
