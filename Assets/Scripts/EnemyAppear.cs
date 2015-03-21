using UnityEngine;
using System.Collections;

public class EnemyAppear : MonoBehaviour {

	public GameObject Alien1;
	public GameObject Alien2;

	public int number;
	public int gap_time;
	public int status;
	public int aliennum;
	//0 normal
	//1 been attacked

	private int timer;

	// Use this for initialization
	void Start () {
		timer = 0;
		status = 0;
		aliennum = 0;
	}

	// Update is called once per frame
	void Update () {
		timer ++;
		if (aliennum == 0)
			status = 0;
		if (timer == 100 * gap_time) {
			timer = 0;
			int i;
			for(i = 0; i < number;i++)
			{
				float seed=0;
				while(seed==0) seed = Random.Range(-1,2);
				GameObject newAlien;
				if(seed < 0) newAlien = Instantiate(Alien1, transform.position,Quaternion.identity) as GameObject;
				else newAlien = Instantiate(Alien2, transform.position,Quaternion.identity) as GameObject;
			}
			aliennum = aliennum + number;
			status = 1;
		}
	}
}
