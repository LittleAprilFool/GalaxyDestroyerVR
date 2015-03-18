using UnityEngine;
using System.Collections;

public class ThrowingControl : MonoBehaviour {

	public GameObject bomb;
	public Vector3 speed;
	public GameObject powerController;
	private CardboardHead head;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {
			Debug.Log ("Throw!");
			GameObject newbomb = Instantiate(bomb, transform.position, head.transform.rotation) as GameObject;
			Rigidbody rigidbody = newbomb.GetComponent<Rigidbody>();
			rigidbody.isKinematic = false;
			rigidbody.velocity = newbomb.transform.TransformVector(speed * powerController.GetComponent<PowerController>().Power);
		}
	}

}
