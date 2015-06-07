using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceController : MonoBehaviour {

	public GameObject instrument1;
	public GameObject instrument2;
	public GameObject instrument3;
	public GameObject instrument4;

	public List<GameObject> sequenceList = new List<GameObject>();
	private int _range;
	private float _posx = 3.0f;

	void Start() {
		StartCoroutine(VerifyInput());
		//SendMessage("RainPosition");
	}


	IEnumerator VerifyInput() {


//		if (Input.touchCount == 1) {
//			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//			Vector2 touchPos = new Vector2(wp.x,wp.y);
//
//			if (Collider == Physics2D.OverlapPoint(touchPos)){
//				Instantiate(instrument2, new Vector3(-3.0f,-6.3f,-1.0f), new Quaternion(0.0f,0.0f,0.0f,0.0f));
//			}
//		}
		while(true) {
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
					if (sequenceList.Count != 0) {
						sequenceList.Clear();
					}
					CreateSequence();
					yield return new WaitForSeconds(2.0f);
			}
		}

		for (int i = 0; i<Input.touchCount; i++){
			if (Input.GetTouch(i).phase == TouchPhase.Began){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				if (Physics.Raycast(ray, out hit)){
					
				}
		   }
		}
		yield return null;
	  }
    }

	void CreateSequence() {
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
		}
		foreach (GameObject obj in sequenceList) {
			Instantiate(obj, new Vector3(_posx,3.63f,-5.0f), new Quaternion(0.0f,0.0f,0.0f,0.0f));
			_posx+=1.5f;
		}
	}

		                            
}
