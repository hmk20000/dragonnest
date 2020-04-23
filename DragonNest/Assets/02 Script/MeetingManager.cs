using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeetingManager : MonoBehaviour {

    // 조우 관리용 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    [SerializeField]
     GameObject Meet;
    [SerializeField]
     GameObject BG;
    [SerializeField]
     GameObject Charector;
    [SerializeField]
     Text Name;
    [SerializeField]
     GameObject ChoisBtn;
    [SerializeField]
    GameObject TextField;


    bool FadeOn = false;


    static  int LV1Count = 7;


    int MeetMin = 0; //랜덤 조우시, 몬스터 범위
    int MeetMax = 7;


    // 버튼 관리용 @@@@@@@@@@@@@@@@@@@@@@@@@@@
    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    GameObject NestBtn;
    int NowBtn = 0;
    int MaxBtn = 10;
    public GameObject MeetBtn;
    public List<GameObject> BtnList;
    

    void Start () {
        // 세이브 및 로드우선 호출 
       


        //  버튼 개수 체크
        if (BtnList.Count == 0)
            BtnList.Add(NestBtn);

        NowBtn = BtnList.Count;


        if (NowBtn < MaxBtn )
        {

                for( int i = NowBtn; i < MaxBtn; i++)
                {

                   var A =  Instantiate(MeetBtn);
                    A.transform.SetParent(Canvas.transform);


                    bool check = true;
                    while(check == true )
                    {
                        // 버튼 위치 랜덤 생성
                        A.transform.localPosition = new Vector3(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-350, 200), 0);


                        // 다른 버튼 안 가리게
                        check = false;
                        for (int j = 0; j < BtnList.Count; j++)
                        {
                            //거리 리턴 함수
                            if( Vector3.Distance(A.transform.localPosition , BtnList[j].transform.localPosition ) < 50)
                            {
                                check = true;   
                            }
                        }        

                    }

                DontDestroyOnLoad(A);
                BtnList.Add(A);


            }//for
        }//if


	}
	
	void Update () {
		
        if( FadeOn)
        {
            Meet.GetComponent<Image>().color        += new Color(0, 0, 0, 1f * Time.deltaTime);
            TextField.GetComponent<Image>().color   += new Color(0, 0, 0, 1f * Time.deltaTime);
            ChoisBtn.GetComponent<Image>().color    += new Color(0, 0, 0, 1f * Time.deltaTime);
            BG.GetComponent<Image>().color          += new Color(0, 0, 0, 1f * Time.deltaTime);
            
        }

        if (BG.GetComponent<Image>().color.a > 0.9) 
        {
            Charector.GetComponent<Image>().color   += new Color(0, 0, 0, 1f * Time.deltaTime);
            Name.color                              += new Color(0, 0, 0, 1f * Time.deltaTime);
        }



	}




    // 조우 버튼용 함수 
    public void Meeting( )
    {
        int mon = UnityEngine.Random.Range(MeetMin, MeetMax);


        SetMeeting(mon);

        //조우 화면 중앙
        Meet.transform.localPosition = new Vector3(0, -20, 0);

        FadeOn = true;


        
    }


    //
    public void SetMeeting(int _mon)
    {
        Monster _target = GetComponent<MonsterManager>().A[_mon];

        //조우 화면 변경  
        BG.GetComponent<Image>().sprite         = GetComponent<MonsterManager>().BGImg[_target.GetBackGroundNum()];
        Charector.GetComponent<Image>().sprite  = GetComponent<MonsterManager>().MonImg[_target.GetImageNum()];
        Charector.transform.localScale          = new Vector3(_target.GetSize(), _target.GetSize());
        Name.text                               = _target.GetName();
 



    }


    // 플레이어의 선택 후
    public void ChoiceButton()
    {


        //조우 바깥으로 이동
        Meet.transform.localPosition = new Vector3(1000, -20, 0);

        Meet.GetComponent<Image>().color        = new Color(0, 0, 0, 0);
        TextField.GetComponent<Image>().color   = new Color(0, 0, 0, 0);
        ChoisBtn.GetComponent<Image>().color    = new Color(0, 0, 0, 0);
        BG.GetComponent<Image>().color          = new Color(0, 0, 0, 0);
        Charector.GetComponent<Image>().color   = new Color(0, 0, 0, 0);
        Name.color                              = new Color(0, 0, 0, 0);



        SceneManager.LoadScene("Main");

    }
}

