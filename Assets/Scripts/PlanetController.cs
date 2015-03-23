using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	public bool hasPlanet {
		get { return transform.childCount > 0; }
	}

}
