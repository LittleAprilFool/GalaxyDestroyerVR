using UnityEngine;
using System.Collections;

public class IntroText : MonoBehaviour {
	public float showingSeconds = 3;

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= showingSeconds)
			gameObject.SetActive (false);
	}
}
