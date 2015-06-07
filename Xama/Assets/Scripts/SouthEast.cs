using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SouthEast : Region {

	public SouthEast () {

		CONSUMPTION = 197.75f;
     	INDEXLOSS = 33.25f;
     	RATEPOPULATION = 0.4f;
		rateCalculate(CONSUMPTION,INDEXLOSS,RATEPOPULATION);
		position = new Vector3(-2.31f,-7.74f,-1.0f);
	}		
}
