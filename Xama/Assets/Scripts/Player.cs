using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private int score;
	//private int count;

	void Start () {
		score = 0;
		//count = 0;
	}

	public void UpdateScore() {
		score+=10;
		SendMessage("UpdateTextScore", score);
	}

	public void UpdateCorrect(int count) {
		SendMessage("UpdateCountCorrect", count);
	}
}
