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
}
