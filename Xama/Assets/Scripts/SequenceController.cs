using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceController : MonoBehaviour {

	public GameObject instrument1;
	public GameObject instrument2;
	public GameObject instrument3;
	public GameObject instrument4;

	public GameObject player;

	public GameObject cloud;

	private List<GameObject> sequenceList = new List<GameObject>();
	private List<string> playerList = new List<string>();

	private int _range;
	private float _posx = -4.55f;
	private int count = 0;
	public float sequenceTimer;
	public int sequencePlayer;

	private string _regionSelect;
	public string regionSelect {

		get {return _regionSelect;}
		set {_regionSelect = value;}
	}

	void Start() {
		StartCoroutine(VerifyInput());
		sequenceTimer = 0.7f;


		sequencePlayer = 0;
	}

	IEnumerator VerifyInput() {

		while(true) {
			Debug.Log(player.gameObject.GetComponent<Player>().countError);
			if (Input.GetMouseButtonDown(0)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit) && (hit.transform.CompareTag("north") ||
				                                      hit.transform.CompareTag("south") ||
				                                      hit.transform.CompareTag("northEast") ||
				                                      hit.transform.CompareTag("southEast") ||
				                                      hit.transform.CompareTag("centerEast"))){
					_regionSelect = hit.transform.tag;
					//Debug.Log(_regionSelect);
					yield return StartCoroutine(CreateSequence()); //create sequence after touch cloud
					yield return StartCoroutine(PlayerSequence()); //wait input of use
					CompareList();
				}
				yield return new WaitForSeconds(0.01f);
			}
			yield return null;
		}

    }

	IEnumerator CreateSequence() {
		sequenceList.Clear();
		_posx = -4.55f;
		for (int i = 0; i < 4; i++) {
			_range = Random.Range(1,5);
			if (_range == 1) {
				sequenceList.Add(instrument1);
			}
			if (_range == 2) {
				sequenceList.Add(instrument2);
			}
			if (_range == 3) {
				sequenceList.Add(instrument3);
			}
			if (_range == 4) {
				sequenceList.Add(instrument4);
			}
		}
		foreach (GameObject obj in sequenceList) {
			Instantiate(obj, new Vector3(_posx,-2.97f,-5.0f), new Quaternion(0.0f,0.0f,0.0f,0.0f));
			_posx+=1.5f;
			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds(sequenceTimer);
	} 

	IEnumerator PlayerSequence () {
		playerList.Clear();
		int count = 0;
		player.gameObject.GetComponent<Player>().UpdateCorrect(count);
		while(count < 4 ) {
			if (Input.GetMouseButtonDown(0)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit) && (hit.transform.CompareTag("instrument1") || 
					                                      hit.transform.CompareTag("instrument2") || 
					                                      hit.transform.CompareTag("instrument3") || 
					                                      hit.transform.CompareTag("instrument4"))){
						playerList.Add(hit.transform.tag);
						player.gameObject.GetComponent<Player>().UpdateCorrect(count+1);
						count ++;
						yield return null;
					}
			} 
			yield return null;	
		}
	}

	void CompareList(){
		count = 0;
		if ((sequenceList.Count == playerList.Count) && (playerList.Count == 4)) {
			Debug.Log("entrou");
			for (int i = 0; i < sequenceList.Count; i++) {
				if (sequenceList[i].gameObject.CompareTag(playerList[i])) {
					count++;
					if (count == 4) {
						player.gameObject.GetComponent<Player>().UpdateScore();
						GetComponent<ControlRegion>().updateLevel(regionSelect);
					}
				}
			}
			if (count < 4) {
				player.gameObject.GetComponent<Player>().countError++;
				PlayerPrefs.SetInt("star", player.gameObject.GetComponent<Player>().countError);
				//Debug.Log(player.gameObject.GetComponent<Player>().countError);
			}
		}
	}
}
