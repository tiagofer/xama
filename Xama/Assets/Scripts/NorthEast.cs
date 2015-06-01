﻿using UnityEngine;
using System.Collections;

public class NorthEast : MonoBehaviour {

	
	private float _waterLevel;
	private float _rate;
	private float _actualTime;
	
	//constantes
	private float CONSUMPTION = 111f;
	private float INDEXLOSS = 41.45f;
	private float RATEPOPULATION = 0.4f;
	
	// Use this for initialization
	void Start () {
		_waterLevel = 100.0f;
		_rate = (CONSUMPTION / 60.0f) * RATEPOPULATION + INDEXLOSS / 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_actualTime += Time.deltaTime;
		
		if (_actualTime >= 5.0f) {
			UpdateWaterLeve ();
			_actualTime = 0.0f;
		}
		
		Debug.Log ("NorthEast" + _waterLevel);
		
	}
	
	void UpdateWaterLeve () {
		_waterLevel -= _rate;
	}
}
