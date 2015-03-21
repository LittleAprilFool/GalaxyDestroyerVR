using UnityEngine;
using System.Collections;

public class EnemyAppear : MonoBehaviour {

	public GameObject Alien1;
	public GameObject Alien2;
	public GameObject lifeBar;

	public int maxNumber = 5;
	public float secondsPerNewAlien = 5;
	public float secondsPerAttack = 2;

	private LifeController lifeController;
	private int alienNum = 0;
	private float timer1;
	private float timer2;
	private bool hasEnemey = false;

	public bool HasEnemy(){
		return hasEnemey;
	}

	// Use this for initialization
	void Start () {
		timer1 = 0;
		timer2 = 0;
		lifeController = lifeBar.GetComponent<LifeController>();
	}

	public void destroyEnemy () {
		alienNum--;
		if (alienNum == 0) hasEnemey = false;
	}

	void FixedUpdate () {
		timer2 += Time.deltaTime;
		if (timer2 >= secondsPerAttack) {
			timer2 = 0;
			if (hasEnemey) {
				Debug.Log("attacked");
				lifeController.loseLife();
			}
		}

		timer1 += Time.deltaTime;
		if (timer1 >= secondsPerNewAlien) {
			timer1 = 0;
			if (alienNum == maxNumber) return;
			Debug.Log("new enemy");

			float seed = Random.Range(-1,2);
			GameObject newAlien;
			if (seed <= 0)
				newAlien = Instantiate(Alien1, transform.position,Quaternion.identity) as GameObject;
			else
				newAlien = Instantiate(Alien2, transform.position,Quaternion.identity) as GameObject;

			alienNum ++;
			if (!hasEnemey) timer2 = 0;
			hasEnemey = true;
		}
	}
}
