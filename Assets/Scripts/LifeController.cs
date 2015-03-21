// README
// 
// after been attacked
// public void loselife()

using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {
	public int initLife = 6;
	public float delta;

	private int lifenumber;

	public void Start() {
		lifenumber = initLife;
	}

	public int Life {
		get { return lifenumber; }
	}

//	void Update(){
//		if (Input.GetMouseButtonDown(1))
//			loselife();
//	}

	public void loseLife(){
		if (lifenumber > 0) {
			transform.localScale += new Vector3 (delta, 0, 0);
			lifenumber --;
			if(lifenumber == 0) Application.LoadLevel(1);
		}
	}
}
