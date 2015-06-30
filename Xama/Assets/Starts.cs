using UnityEngine;
using System.Collections;

public class Starts : MonoBehaviour {

	public GameObject star;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("star") < 3) {
			Instantiate(star, new Vector3(0.27f, 2.38f, -10f), new Quaternion(0f,0f,0f,0f));
			Instantiate(star, new Vector3(2.81f, 1.25f, -10f), new Quaternion(0f,0f,0f,0f));
			Instantiate(star, new Vector3(-2.45f, 1.25f, -10f), new Quaternion(0f,0f,0f,0f));
		} else if (PlayerPrefs.GetInt("star") < 5) {
			Instantiate(star, new Vector3(2.81f, 1.25f, -10f), new Quaternion(0f,0f,0f,0f));
			Instantiate(star, new Vector3(-2.45f, 1.25f, -10f), new Quaternion(0f,0f,0f,0f));
		} else {
			Instantiate(star, new Vector3(0.27f, 2.38f, -10f), new Quaternion(0f,0f,0f,0f));
		}
	}

}
