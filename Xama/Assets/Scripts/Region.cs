using UnityEngine;
using System.Collections;

public class Region : MonoBehaviour {

	private float _waterLevel;
	private float _rate;
	private float _actualTime;
	private float _CONSUMPTION;
	private float _INDEXLOSS;
	private float _RATEPOPULATION;
	private Vector3 _position;

	public Transform regionPosition;

	public Vector3 position {

		get {return _position;}
		set {_position = value;}
	}

	public float CONSUMPTION {

		get {return _CONSUMPTION;}
		set {_CONSUMPTION = value;}
	}

	public float INDEXLOSS {
		
		get {return _INDEXLOSS;}
		set {_INDEXLOSS = value;}
	}

	public float RATEPOPULATION {
		
		get {return _RATEPOPULATION;}
		set {_RATEPOPULATION = value;}
	}

	public float waterLevel {
		get {return _waterLevel;}
		set {_waterLevel = value;}
	
	}

	public Region(){
		_waterLevel = 100.0f;
	}

	public void rateCalculate (float CONSUMPTION, float INDEXLOSS, float RATEPOPULATION) {
		  _rate = (CONSUMPTION / 60.0f) * RATEPOPULATION + INDEXLOSS / 100.0f;
	}

	public void updateWaterLevel(){
		_waterLevel= (_waterLevel - _rate);
	}

	public void addWaterLevel(float ratePlayer){
		_waterLevel += ratePlayer;
	}


}
