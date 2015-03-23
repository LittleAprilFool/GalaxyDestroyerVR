using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject Alien1;
	public GameObject Alien2;
	public GameObject lifeBar;
	public GameObject dangerSign;

	public int maxNumber = 3;
	public float secondsPerNewAlien = 5;
	public float secondsPerAttack = 3;

	private LifeController lifeController;
	private int alienNum;
	private float timerNewAlien;
	private float timerAttack;
	private bool _hasEnemy;

	public bool hasEnemy {
		get { return _hasEnemy; }
		private set {
			if (_hasEnemy == value) return;
			if (!_hasEnemy && value) timerAttack = 0;
			_hasEnemy = value;
			dangerSign.SetActive(_hasEnemy);
		}
	}

	// Use this for initialization
	void Start () {
		_hasEnemy = false;	// don't use setter here
		alienNum = 0;
		timerNewAlien = 0;
		timerAttack = 0;
		lifeController = lifeBar.GetComponent<LifeController>();

		// preload prefabs
		GameObject p = Instantiate(Alien1, transform.position, Quaternion.identity) as GameObject;
		Destroy(p);
		p = Instantiate(Alien2, transform.position, Quaternion.identity) as GameObject;
		Destroy(p);
		p = null;
	}

	public void DestroyEnemy () {
		if (alienNum == 0) return;
		alienNum--;
		if (alienNum == 0) _hasEnemy = false;
	}

	void Update () {
		if (hasEnemy) {
			timerAttack += Time.deltaTime;
			if (timerAttack >= secondsPerAttack) {
				timerAttack = 0;
				if (Debug.isDebugBuild)
					Debug.Log("Attacked by enemy");
				lifeController.LoseLife();
			}
		}

		timerNewAlien += Time.deltaTime;
		if (timerNewAlien >= secondsPerNewAlien) {
			timerNewAlien = 0;
			if (alienNum == maxNumber) return;
			if (Debug.isDebugBuild)
				Debug.Log("New enemy");
			float seed = Random.Range(-1, 2);
			if (seed <= 0)
				Instantiate(Alien1, transform.position, Quaternion.identity);
			else
				Instantiate(Alien2, transform.position, Quaternion.identity);

			alienNum ++;
			hasEnemy = true;
		}
	}
}
