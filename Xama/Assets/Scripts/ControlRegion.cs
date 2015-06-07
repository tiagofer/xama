using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlRegion : MonoBehaviour {

	public GameObject rainPrefab;
	public Transform prefabRotation;

	private bool _activate;
	private int _region;

	//regions object
//	private  North north;
//	private South south;
//	private CenterEast centerEast;
//	private SouthEast southEast;
//	private NorthEast northEast;

	public GameObject north;
	public GameObject south;
	public GameObject centerEast;
	public GameObject southEast;
	public GameObject northEast;

	//calculate time to refresh waterlevel
	private float _actualTime;

	void Awake () {
		//instantiate regions object
//		north = gameObject.AddComponent<North>();
//		south = gameObject.AddComponent<South>();
//		centerEast = gameObject.AddComponent<CenterEast>();
//		southEast = gameObject.AddComponent<SouthEast>();
//		northEast = gameObject.AddComponent<NorthEast>();
		//north = north.GetComponent<North>();
	}

	void Start() {
		rainPrefab.CreatePool();
		StartCoroutine("RefreshWaterLevel");
		StartCoroutine(RainPosition());
		//_activate = true;
		//StartCoroutine("GenerateInstruments");
	}

	IEnumerator RefreshWaterLevel() {

		while (true) {
			north.GetComponent<North>().updateWaterLevel();
			south.GetComponent<South>().updateWaterLevel();
			southEast.GetComponent<SouthEast>().updateWaterLevel();
			northEast.GetComponent<NorthEast>().updateWaterLevel();
			centerEast.GetComponent<CenterEast>().updateWaterLevel();
			
			gameObject.SendMessage("UpdateSliderNorth", north.GetComponent<North>().waterLevel);
			gameObject.SendMessage("UpdateSliderNorthEast", northEast.GetComponent<NorthEast>().waterLevel);
			gameObject.SendMessage("UpdateSliderSouth", south.GetComponent<South>().waterLevel);
			gameObject.SendMessage("UpdateSliderSouthEast", southEast.GetComponent<SouthEast>().waterLevel);		
			gameObject.SendMessage("UpdateSliderCenterEast", centerEast.GetComponent<CenterEast>().waterLevel);

			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator RainPosition () {

		while (true) {
			//if (_activate) {

			_region = Random.Range (1, 6);
			if (!rainPrefab.CompareTag("north") && _region == 1) {
				rainPrefab.Spawn( north.GetComponent<North>().position, prefabRotation.rotation);
				rainPrefab.tag = "north";
				Debug.Log(rainPrefab.tag);
				yield return new WaitForSeconds(2.0f);
			}
			if (!rainPrefab.CompareTag("south") && _region == 2) {
				rainPrefab.Spawn( south.GetComponent<South>().position, prefabRotation.rotation);
				rainPrefab.tag = "south";
				Debug.Log(rainPrefab.tag);
				yield return new WaitForSeconds(2.0f);
			}
			if (!rainPrefab.CompareTag("southEast") && _region == 3) {
				rainPrefab.Spawn( southEast.GetComponent<SouthEast>().position, prefabRotation.rotation);
				rainPrefab.tag = "southEast";
				Debug.Log(rainPrefab.tag);
				yield return new WaitForSeconds(2.0f);
			}
			if (!rainPrefab.CompareTag("northEast") && _region == 4) {
				rainPrefab.Spawn( northEast.GetComponent<NorthEast>().position, prefabRotation.rotation);
				rainPrefab.tag = "northEast";
				Debug.Log(rainPrefab.tag);
				yield return new WaitForSeconds(2.0f);
			}
			if (!rainPrefab.CompareTag("centerEast") && _region == 5) {
				rainPrefab.Spawn( centerEast.GetComponent<CenterEast>().position, prefabRotation.rotation);
				rainPrefab.tag = "centerEast";
				Debug.Log(rainPrefab.tag);
				yield return new WaitForSeconds(2.0f);
			}
		
		}

	}
		                                  
}
