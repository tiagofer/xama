using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private int score;
	private int activate;
	public GameObject canvas;

	private int _countError;
	public int countError {
		get {return _countError;}
		set {_countError = value;}
	}

	private int _hit;
	public int hit {
		get {return _hit;}
		set {_hit = value;}
	}

	private float _playerRate = 11f;
	public float playerRate {
		
		get {return _playerRate;}
		set {_playerRate = value;}
	}

	void Start () {
		score = 0;
		_countError = 0;
		//count = 0;
	}

	public void UpdateScore() {
		score+=10;
		activate = 1;
		canvas.gameObject.GetComponent<CanvasControl>().UpdateTextScore(score);
		//SendMessage("UpdateTextScore", score);//remove sendmessage
	}

	public void UpdateCorrect(int count) {
		canvas.gameObject.GetComponent<CanvasControl>().UpdateCountCorrect(count);
		//SendMessage("UpdateCountCorrect", count);//remove sendmessage
	}
}
