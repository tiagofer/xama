using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class North : MonoBehaviour {

	public GameObject printWaterLevel;

	private float _waterLevel;
	private float _rate;
	private float _actualTime;

	//constantes
	private float CONSUMPTION = 173.75f;
	private float INDEXLOSS = 56.3f;
	private float RATEPOPULATION = 0.08f;

	public float waterLevel {
		get { return _waterLevel;}
	}

	// Use this for initialization
	void Start () {
		_waterLevel = 100.0f;
		printWaterLevel.GetComponent<Slider> ().value = _waterLevel;
		_rate = (CONSUMPTION / 60.0f) * RATEPOPULATION + INDEXLOSS / 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//_rate = (CONSUMPTION / 60.0f) * RATEPOPULATION + INDEXLOSS / 100.0f;
		_actualTime += Time.deltaTime;

		if (_actualTime >= 1.0f) {
			UpdateWaterLeve ();
			_actualTime = 0.0f;
		}

	
	}

	void LateUpdate () {
		Debug.Log ("North " + _waterLevel);
		printWaterLevel.GetComponent<Slider> ().value = _waterLevel;

	}

	void UpdateWaterLeve () {
		_waterLevel -= _rate;
	}


}
