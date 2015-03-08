using UnityEngine;
using System.Collections;

public class AutoMoving : MonoBehaviour {
	public Vector3 endPoint;
	public float time;
	// Use this for initialization
	IEnumerator Start () {
		Vector3 startPoint = transform.position;
		while (true) {
			yield return StartCoroutine( MoveObject(transform, startPoint, endPoint, time));
			transform.position = startPoint;
		}
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPoint, Vector3 endPoint, float time) {
		float i = 0;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPoint, endPoint, i);
			yield return null;		
		}
	}
}
