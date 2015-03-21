using UnityEngine;
using System.Collections;

public class ThrowingControl : MonoBehaviour {

	public GameObject bomb;
	public GameObject power;
	public GameObject enemy;

	public Vector3 speed;
	private CardboardHead head;
	private PowerController _power;
	private EnemyAppear enemyControl;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		_power = power.GetComponent<PowerController>();
		enemyControl = enemy.GetComponent<EnemyAppear>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {
			if (!_power.Available()) {
				Debug.Log ("Not enough power.");
				return;
			}
			Debug.Log ("Fire!");
			_power.Fire();
			GameObject newbomb = Instantiate(bomb, transform.position, head.transform.rotation * transform.rotation) as GameObject;
			Rigidbody rigidbody = newbomb.GetComponent<Rigidbody>();
			rigidbody.velocity = newbomb.transform.TransformVector(speed);
			BombCollision bombcollision = newbomb.GetComponent<BombCollision>();
			bombcollision.setEnemyControl(enemyControl);
		}
	}

}
