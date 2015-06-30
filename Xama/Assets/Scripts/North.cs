using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class North : Region {

	public North(){
		 CONSUMPTION = 173.75f ;
		 INDEXLOSS = 56.3f;
		 RATEPOPULATION = 0.09f;
		 rateCalculate(CONSUMPTION,INDEXLOSS,RATEPOPULATION);
		 position = new Vector3(-3.0f,-6.3f,-1.0f);
	}
}