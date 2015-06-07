using UnityEngine;
using System.Collections;

public class DestroyCloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 2.01f);
	}

}
