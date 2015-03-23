// README
// 
// after been attacked
// public void loselife()

using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {
	public int initLife = 6;
	public float delta;

	private Vector3 _delta;
	private int lifeNumber;

	public int life {
		get { return lifeNumber; }
	}

//	void Update(){
//		if (Input.GetMouseButtonDown(1))
//			loselife();
//	}

	void Start() {
		lifeNumber = initLife;
		_delta = new Vector3 (delta, 0f, 0f);
	}

	public void LoseLife() {
		if (Debug.isDebugBuild)
			Debug.Log ("Lost a life");

		if (lifeNumber > 0) {
			transform.localScale += _delta;
			lifeNumber --;
			if(lifeNumber == 0) Application.LoadLevel("FailScene");
		}
	}
}
