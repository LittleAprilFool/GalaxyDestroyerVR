using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {
	public int lifenumber;
	public float delta;

	public void loselife(){
		if (lifenumber > 0) {
			transform.localScale += new Vector3 (0, delta, 0);
			lifenumber --;
			if(lifenumber == 0) Application.LoadLevel(1);
		}
	}
}
