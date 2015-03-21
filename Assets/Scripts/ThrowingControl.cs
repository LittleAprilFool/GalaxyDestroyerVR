using UnityEngine;
using System.Collections;

public class ThrowingControl : MonoBehaviour {

	public GameObject bomb;
	public Vector3 speed;
	private CardboardHead head;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		/*localRotation = Quaternion.identity *
			Quaternion.FromToRotation(transform.up, transform.right) *
			Quaternion.FromToRotation(transform.right, transform.forward);*/
	}
	
	// Update is called once per frame
	void Update () {
		GameObject powerbar = GameObject.Find ("Power");
		bool avail = powerbar.GetComponent<PowerController> ().Avaliable ();
		if (Cardboard.SDK.CardboardTriggered && avail) {
			Debug.Log ("Throw!");
			GameObject newbomb = Instantiate(bomb, transform.position, head.transform.rotation * transform.rotation) as GameObject;
			Rigidbody rigidbody = newbomb.GetComponent<Rigidbody>();
			rigidbody.velocity = newbomb.transform.TransformVector(speed);
			powerbar.GetComponent<PowerController> ().Active ();
		}
	}

}
