using UnityEngine;
using System.Collections;

public class RevolveSpin : MonoBehaviour {

	public Vector3 roundness;
	public float radius;
	public bool randomScale = false;

	private Vector3 thisposition;
	private Vector3 up;
	private float theta;
	private float alpha;
	private float speed;
	private float size;
	

	// Use this for initialization
	void Start () {
		theta = Random.Range(-1,1);
		alpha = Random.Range(-180,180);

		theta = theta / 10;

		radius = radius * 1.5f;

		up.y = Mathf.Cos (theta);

		up.z = 0;

		up.x = -Mathf.Sin (theta);

		speed = 0;

		while(speed < 0.1f && speed > -0.1f)speed = Random.Range(-0.8f,0.8f);

		thisposition.y = radius * Mathf.Sin (theta);
		thisposition.x = radius * Mathf.Cos (theta);
		thisposition.z = 0;

		thisposition = thisposition + roundness;
		transform.position = thisposition;
		transform.RotateAround (roundness, up, alpha);

		size = Random.Range (1.0f, 1.5f);
		if (randomScale) transform.localScale *= size;
	}

	void FixedUpdate () {
		transform.RotateAround (roundness, up, speed);
	}
}
