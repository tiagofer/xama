using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SouthEast : MonoBehaviour {

	public GameObject printWaterLevel;

	private float _waterLevel;
	private float _rate;
	private float _actualTime;
	
	//constantes
	private float CONSUMPTION = 197.75f;
	private float INDEXLOSS = 33.25f;
	private float RATEPOPULATION = 0.4f;
	
	// Use this for initialization
	void Start () {
		_waterLevel = 100.0f;
		printWaterLevel.GetComponent<Slider> ().value = _waterLevel;
		_rate = (CONSUMPTION / 60.0f) * RATEPOPULATION + INDEXLOSS / 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_actualTime += Time.deltaTime;
		
		if (_actualTime >= 1.0f) {
			UpdateWaterLeve ();
			_actualTime = 0.0f;
		}
		
		Debug.Log ("SouthEast" + _waterLevel);
		printWaterLevel.GetComponent<Slider> ().value = _waterLevel;
		
	}
	
	void UpdateWaterLeve () {
		_waterLevel -= _rate;
	}
}
