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
    Text Name;


  



    void Start () {
		
	}
	
	void Update () {
		
	}




    // 조우 버튼용 함수 
    public void Meeting( int no)
    {

        switch(no)
        {
            case 0: //핑크
                SetMeeting(GetComponent<MonsterManager>().Pink);
                break;

            case 1: //옐로
                SetMeeting(GetComponent<MonsterManager>().Yellow);
                break;

            case 2: //블랙
                SetMeeting(GetComponent<MonsterManager>().Choco);
                break;

            case 3: //고블린
                SetMeeting(GetComponent<MonsterManager>().Goblin);
                break;

            case 4: //오크
                SetMeeting(GetComponent<MonsterManager>().Ork);
                break;
        }


        //조우 화면 중앙
        Meet.transform.localPosition = new Vector3(0, -20, 0);

    }

    public void SetMeeting(Monster _target)
    {
        //조우 화면 변경  
        BG.GetComponent<Image>().sprite = GetComponent<MonsterManager>().BGImg[_target.BG];
        Charector.GetComponent<Image>().sprite = GetComponent<MonsterManager>().MonImg[_target.no];
        Charector.transform.localScale = new Vector3(_target.size, _target.size, _target.size);
        Name.text = _target.name;



    }

    public void ChoiceButton()
    {
        //조우 화면 중앙
        Meet.transform.localPosition = new Vector3(1000, -20, 0);
    }
}

