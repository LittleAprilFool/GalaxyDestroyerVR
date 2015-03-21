// README
// 
// after been attacked
// public void loselife()

using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {
	public int lifenumber;
	public float delta;

//	void Update(){
//		if (Input.GetMouseButtonDown(1))
//			loselife();
//	}

	public void loselife(){
		if (lifenumber > 0) {
			transform.localScale += new Vector3 (delta, 0, 0);
			lifenumber --;
			if(lifenumber == 0) Application.LoadLevel(1);
		}
	}
}
