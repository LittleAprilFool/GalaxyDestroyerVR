using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {
	public Vector3 scaleEnd;
	public float time;
	// Use this for initialization
	IEnumerator Start () {
		Vector3 scaleStart = transform.localScale; 
		while (true) {
			yield return StartCoroutine( ScaleObject(transform, scaleStart, scaleEnd, time));
			yield return StartCoroutine( ScaleObject(transform, scaleEnd, scaleStart, time));
		}
	}

	IEnumerator ScaleObject (Transform thisTransform, Vector3 scaleStart, Vector3 scaleEnd, float time){
		float i = 0;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.localScale = Vector3.Lerp (scaleStart, scaleEnd, i);
			yield return null;	
		}
	}

}
