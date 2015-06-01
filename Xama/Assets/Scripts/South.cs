using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class South : MonoBehaviour {

	public GameObject printWaterLevel;

	private float _waterLevel;
	private float _rate;
	private float _actualTime;
	
	//constantes
	private float CONSUMPTION = 113.25f;
	private float INDEXLOSS = 26.07f;
	private float RATEPOPULATION = 0.14f;
	
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
		
		Debug.Log ("South " + _waterLevel);
		
	}

	void LateUpdate(){
		printWaterLevel.GetComponent<Slider> ().value = _waterLevel;
	}
	
	void UpdateWaterLeve () {
		_waterLevel -= _rate;
	}
}
