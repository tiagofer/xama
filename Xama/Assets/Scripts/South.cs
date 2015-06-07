using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class South : Region {

	//private float _rate;

	public South () {
		CONSUMPTION = 113.25f;
     	INDEXLOSS = 26.07f;
     	RATEPOPULATION = 0.14f;
		rateCalculate(CONSUMPTION,INDEXLOSS,RATEPOPULATION);
		position = new Vector3(-2.08f,-9.39f,-1.0f);
	}
}
