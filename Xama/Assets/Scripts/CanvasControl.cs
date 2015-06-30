using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CanvasControl : MonoBehaviour {
	
	//gui sliders
	public Slider northBar;
	public Slider southBar;
	public Slider northEastBar;
	public Slider southEastBar;
	public Slider centerEastBar;

	public Text score;
	public Text updateTime;
	public Text countCorrect;

	public GameObject tenAnimator;

	private Animator animator;

	void Start() {
		animator = tenAnimator.GetComponent<Animator>();
	}

	public void UpdateSliderNorth (float northWater) {

		northBar.value = northWater;
		
	}
	public void UpdateSliderSouth (float southWater) {
 

		southBar.value = southWater;
		
	}
	public void UpdateSliderSouthEast (float southEastWater) {

		southEastBar.value = southEastWater;
		
	}
	public void UpdateSliderNorthEast (float northEastWater) {
		
		northEastBar.value = northEastWater;
		
	}
	public void UpdateSliderCenterEast (float centerEastWater) {

		centerEastBar.value = centerEastWater;		
	}

	public void UpdateTextScore(int score) {
		this.score.text = score.ToString();
		StartCoroutine(UpdatePlusAnimation());
		StopCoroutine(UpdatePlusAnimation());
	}


	public void UpdateCountCorrect(int count) {
		countCorrect.text = count.ToString();

	}

	public void UpdateTimer(int time) {
		updateTime.text = time.ToString();
	}

	IEnumerator UpdatePlusAnimation() {
		animator.SetInteger("activate",1);
		yield return new WaitForSeconds(1.0f);
		animator.SetInteger("activate",0);
		//yield return null;
	}
}
