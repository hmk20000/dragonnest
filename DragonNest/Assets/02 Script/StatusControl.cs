using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatusControl : MonoBehaviour {


    [SerializeField]
    Text GoldPoint;
    static int gold = 0;

    [SerializeField]
    Text ManaPoint;
    static int mana = 0;

    [SerializeField]
    Text ArmyPoint;
    static int army = 0;


	void Start () {
		
        //로딩시 골드, 마나, 군사 정보 대입해야함.



	}
	
	void Update () {

        GoldPoint.text = gold.ToString();
        ManaPoint.text = mana.ToString();
        ArmyPoint.text = army.ToString();

	}
}
