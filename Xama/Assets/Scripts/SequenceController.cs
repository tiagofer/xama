using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceController : MonoBehaviour {

	public GameObject instrument1;
	public GameObject instrument2;
	public GameObject instrument3;
	public GameObject instrument4;
	

	public GameObject cloud;

	private List<GameObject> sequenceList = new List<GameObject>();
	private List<string> playerList = new List<string>();

	private int _range;
	private float _posx = 3.0f;
	private int count = 0;
	public int sequenceTimer;
	public int sequencePlayer;
	
	void Start() {
		StartCoroutine(VerifyInput());
		sequenceTimer = 1;
		sequencePlayer = 0;
	}


	//verify users input
	IEnumerator VerifyInput() {

		while(true) {

		
			if (Input.GetMouseButtonDown(0)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit) && (hit.transform.CompareTag("north") ||
				                                      hit.transform.CompareTag("south") ||
				                                      hit.transform.CompareTag("northEast") ||
				                                      hit.transform.CompareTag("southEast") ||
				                                      hit.transform.CompareTag("centerEast"))){
					yield return StartCoroutine(CreateSequence()); //create sequence after touch cloud
					Debug.Log("Insira A Sequencia");
					yield return StartCoroutine(PlayerSequence()); //wait input of use
					CompareList();
					foreach (string obj in playerList) {
						Debug.Log(obj);
					}
				}
				yield return new WaitForSeconds(0.1f);
			}
			//StartCoroutine(CompareList());

//			if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)){
//				RaycastHit hit;
//				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
//
//				if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("cloud")){
//					StartCoroutine(CreateSequence()); //create sequence after touch cloud
//					StartCoroutine(PlayerSequence()); //wait input of user
//				}
//				yield return StartCoroutine(CompareList());;
//				}
			yield return null;
		}

    }

	IEnumerator CreateSequence() {
		sequenceList.Clear();
		_posx = 3.0f;
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
			//yield return new WaitForEndOfFrame();
		}
		foreach (GameObject obj in sequenceList) {
			Instantiate(obj, new Vector3(_posx,3.63f,-5.0f), new Quaternion(0.0f,0.0f,0.0f,0.0f));
			_posx+=1.5f;
		}
		yield return new WaitForSeconds(sequenceTimer);
	}

	IEnumerator PlayerSequence () {
		playerList.Clear();
		int count = 0;
		SendMessage("UpdateCorrect", count);
		while(count < 4 ) {
			if (Input.GetMouseButtonDown(0)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit) && (hit.transform.CompareTag("instrument1") || 
					                                      hit.transform.CompareTag("instrument2") || 
					                                      hit.transform.CompareTag("instrument3") || 
					                                      hit.transform.CompareTag("instrument4"))){
						playerList.Add(hit.transform.tag);
						Debug.Log(count);
						SendMessage("UpdateCorrect", (count + 1));
						count ++;
						yield return null;
					}
			} 
			yield return null;	
		}
		//yield return null;
	}

	void CompareList(){
		count = 0;
		if ((sequenceList.Count == playerList.Count) && (playerList.Count == 4)) {
			Debug.Log("entrou");
			for (int i = 0; i < sequenceList.Count; i++) {
				if (sequenceList[i].gameObject.CompareTag(playerList[i])) {
					count++;
					//SendMessage("UpdateCorrect", count);
					//Debug.Log(count);
					if (count == 4) {
						Debug.Log("parabens");
						SendMessage("UpdateScore");

					}
				}
			}
		}

	}
}
