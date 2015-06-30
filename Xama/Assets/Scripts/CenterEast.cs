using UnityEngine;
using System.Collections;

public class CenterEast : Region {

	public CenterEast () {
	
		CONSUMPTION = 164.25f;
     	INDEXLOSS = 45.05f;
     	RATEPOPULATION = 0.09f;
		rateCalculate(CONSUMPTION,INDEXLOSS,RATEPOPULATION);
		position = new Vector3(-2.25f,-7.97f,-1.0f);
	}
}
