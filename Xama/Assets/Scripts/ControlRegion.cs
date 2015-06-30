using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlRegion : MonoBehaviour {

	public GameObject north;
	public GameObject south;
	public GameObject centerEast;
	public GameObject southEast;
	public GameObject northEast;

	public GameObject rainPrefab;
	public GameObject canvas;

	private Transform _north;
	private Transform _northEast;
	private Transform _south;
	private Transform _southEast;
	private Transform _centerEast;

	public GameObject player;

	//calculate time to refresh waterlevel
	private float _actualTime;
	private float _gameTime;
	private float _totalGame;

	void Start() {
		_totalGame = 60.0f;
		StartCoroutine("RefreshWaterLevel");
		_north = north.gameObject.GetComponent<Transform>();
		_northEast = northEast.gameObject.GetComponent<Transform>();
		_south = south.gameObject.GetComponent<Transform>();
		_southEast = southEast.gameObject.GetComponent<Transform>();
		_centerEast = centerEast.gameObject.GetComponent<Transform>();

	}

	void Update() {
		_gameTime += Time.deltaTime;
		canvas.gameObject.GetComponent<CanvasControl>().UpdateTimer((int)_totalGame - (int)_gameTime);
	}

	IEnumerator RefreshWaterLevel() {

		while (true) {

			north.GetComponent<North>().updateWaterLevel();
			south.GetComponent<South>().updateWaterLevel();
			southEast.GetComponent<SouthEast>().updateWaterLevel();
			northEast.GetComponent<NorthEast>().updateWaterLevel();
			centerEast.GetComponent<CenterEast>().updateWaterLevel();

			canvas.gameObject.GetComponent<CanvasControl>().UpdateSliderNorth(north.GetComponent<North>().waterLevel);
			canvas.gameObject.GetComponent<CanvasControl>().UpdateSliderNorthEast(northEast.GetComponent<NorthEast>().waterLevel);
			canvas.gameObject.GetComponent<CanvasControl>().UpdateSliderSouth(south.GetComponent<South>().waterLevel);
			canvas.gameObject.GetComponent<CanvasControl>().UpdateSliderSouthEast(southEast.GetComponent<SouthEast>().waterLevel);
			canvas.gameObject.GetComponent<CanvasControl>().UpdateSliderCenterEast(centerEast.GetComponent<CenterEast>().waterLevel);

			if (north.GetComponent<North>().waterLevel <= 0 || 
			    northEast.GetComponent<NorthEast>().waterLevel <= 0 ||
			    south.GetComponent<South>().waterLevel == 0 ||
			    southEast.GetComponent<SouthEast>().waterLevel <= 0 ||
			    centerEast.GetComponent<CenterEast>().waterLevel <= 0) {
				Application.LoadLevel(3);
			}

			if (north.GetComponent<North>().waterLevel > 0 && 
			    northEast.GetComponent<NorthEast>().waterLevel > 0 &&
			    south.GetComponent<South>().waterLevel > 0 &&
			    southEast.GetComponent<SouthEast>().waterLevel > 0 &&
			    centerEast.GetComponent<CenterEast>().waterLevel > 0 &&
			    _gameTime >= _totalGame) {
				Application.LoadLevel(2);
			}

			yield return new WaitForSeconds(0.5f);
		}
	}

	public void updateLevel(string region) {

		if (region == "north") {
			north.GetComponent<North>().addWaterLevel(player.gameObject.GetComponent<Player>().playerRate);
			Instantiate(rainPrefab, new Vector3( _north.position.x, _north.position.y, -0.9f), _north.rotation);
		} else if (region == "south") {
			south.GetComponent<South>().addWaterLevel(player.gameObject.GetComponent<Player>().playerRate);
			Instantiate(rainPrefab, new Vector3( _south.position.x, _south.position.y, -0.9f), _north.rotation);
		} else if (region == "southEast") {
			southEast.GetComponent<SouthEast>().addWaterLevel(player.gameObject.GetComponent<Player>().playerRate);
			Instantiate(rainPrefab, new Vector3( _southEast.position.x, _southEast.position.y, -0.9f), _north.rotation);
		} else if (region == "northEast") {
			northEast.GetComponent<NorthEast>().addWaterLevel(player.gameObject.GetComponent<Player>().playerRate);
			Instantiate(rainPrefab, new Vector3( _northEast.position.x, _northEast.position.y, -0.9f), _north.rotation);
		} else if (region == "centerEast") {
			centerEast.GetComponent<CenterEast>().addWaterLevel(player.gameObject.GetComponent<Player>().playerRate);
			Instantiate(rainPrefab, new Vector3( _centerEast.position.x, _centerEast.position.y, -0.9f), _north.rotation);
		}
	}
		                                  
}
