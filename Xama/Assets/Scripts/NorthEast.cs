using UnityEngine;
using System.Collections;

public class NorthEast : Region {

	public NorthEast () {

		CONSUMPTION = 111f;
     	INDEXLOSS = 41.45f;
     	RATEPOPULATION = 0.4f;
		rateCalculate(CONSUMPTION,INDEXLOSS,RATEPOPULATION);
		position = new Vector3(-0.7f,-6.86f,-1.0f);
	}
}
