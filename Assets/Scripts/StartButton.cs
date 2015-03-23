using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class StartButton : MonoBehaviour {
	public GameObject ButtonTexture;
	public float glazeSeconds = 2;
	public bool flag;

	private CardboardHead head;
	private float timer;
	private Color blue = new Vector4 (0.3f, 1f, 0.8f, 1f);

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		timer = 0;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

		flag = false;
		if (Input.GetMouseButtonDown (0))
			flag = true;

		if (isLookedAt) {
			timer += Time.deltaTime;
			ButtonTexture.GetComponent<RawImage>().color = blue;
			if (timer >= glazeSeconds) {
				Application.LoadLevel("UniverseScene");
			}
		} else {
			ButtonTexture.GetComponent<RawImage>().color = Color.white;
			timer = 0;
		}

		if (Cardboard.SDK.CardboardTriggered || flag) {
			Application.LoadLevel("UniverseScene");
		}
	}
}