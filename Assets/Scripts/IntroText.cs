using UnityEngine;
using System.Collections;

public class IntroText : MonoBehaviour {
	public int timer;
	private GameObject text;
	// Use this for initialization
	void Start () {
		text = GameObject.Find("Introduction");
		text.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer != 0)
			timer--;
		if (timer == 0)
			text.SetActive (false);
	}
}
