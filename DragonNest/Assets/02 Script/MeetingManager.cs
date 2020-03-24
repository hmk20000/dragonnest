using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetingManager : MonoBehaviour {

    [SerializeField]
    GameObject Meet;

    [SerializeField]
    GameObject BG;

    [SerializeField]
    GameObject Charector;



    [SerializeField]
    GameObject MeetMng;


  



    void Start () {
		
	}
	
	void Update () {
		
	}




    // 조우 버튼용 함수 
    public void Meeting( int no)
    {
        Meet.transform.localPosition = new Vector3(0,-20,0);

        //조우 화면 변경  
        BG.GetComponent<Image>().sprite         = MeetMng.GetComponent<MonsterManager>().BGImg  [(int)MonsterManager.Field.Forest];
        Charector.GetComponent<Image>().sprite  = MeetMng.GetComponent<MonsterManager>().MonImg [(int)MonsterManager.MonNo.ORK];


    }


    
}

