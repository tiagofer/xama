﻿using UnityEngine;
using System.Collections;

public class DestroyInstrument : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 3.01f);
	}
	
}