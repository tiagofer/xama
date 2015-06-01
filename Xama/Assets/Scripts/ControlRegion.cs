using UnityEngine;
using System.Collections;

public class ControlRegion : Region {

	Region regionNorth = new Region();
	public float _rate;

	public ControlRegion () {
		_rate = regionNorth.Rate;
	}

	// Use this for initialization
	void Start () {
		regionNorth.WaterLevel = 100.0f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
