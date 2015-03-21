using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	private CardboardHead head;
	// Use this for initialization
	
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
			
		}
	}
}
