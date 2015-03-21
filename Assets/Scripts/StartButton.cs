using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
	public class StartButton : MonoBehaviour {
	private CardboardHead head;
	private Vector3 startingPosition;
	public GameObject ButtonTexture;
	private int timer;
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		ButtonTexture = GameObject.Find("Texture");
		timer = 0;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt) {
			timer ++;
			Color blue = new Vector4 (0.3f, 1f, 0.8f, 1f);
			Debug.Log (blue);
			ButtonTexture.GetComponent<RawImage> ().color = blue;
			if (timer == 100) {
				Application.LoadLevel(1);
			}
		} else {
			ButtonTexture.GetComponent<RawImage> ().color = Color.white;
			timer = 0;
		}

		if (Cardboard.SDK.CardboardTriggered) {
			Application.LoadLevel(1);
		}
	}
}