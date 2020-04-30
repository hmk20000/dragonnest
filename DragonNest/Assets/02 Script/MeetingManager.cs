using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeetingManager : MonoBehaviour {
    [SerializeField]
    GameObject DataMNG;

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
    bool BackCurtain = false;


    static  int LV1Count = 7;


    int MeetMin = 0; //랜덤 조우시, 몬스터 범위
    int MeetMax = 7;


    // 버튼 관리용 @@@@@@@@@@@@@@@@@@@@@@@@@@@
    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    GameObject NestBtn;
    int NowBtn = 0;
    int MaxBtn = 5;
    
    public GameObject MeetBtn;
    public List<GameObject> BtnList;



    void Start () {
        // 세이브 및 로드우선 호출 

        //DataMNG.GetComponent<DataControl>().data.MeetBtnCount;



        
        if (DataMNG.GetComponent<DataControl>().data.MeetBtnCount == 0)  //  첫 생성 동굴버튼
        {
            Debug.Log("Nest 버튼 정보 입력 성공");


            //prefs 저장 
            //DataMNG.GetComponent<DataControl>().data.BtnPos += NestBtn.transform.localPosition.x.ToString();
            //DataMNG.GetComponent<DataControl>().data.BtnPos += "x";
            //DataMNG.GetComponent<DataControl>().data.BtnPos += NestBtn.transform.localPosition.y.ToString();
            //DataMNG.GetComponent<DataControl>().data.BtnPos += "y";
            //DataMNG.GetComponent<DataControl>().data.BtnPos += 1;
            //DataMNG.GetComponent<DataControl>().data.BtnPos += "!";
            //DataMNG.GetComponent<DataControl>().data.MeetBtnCount++;


        }
        else // 로드시 
        {
            string dumy = DataMNG.GetComponent<DataControl>().data.BtnPos;

            int index = 0;
            for (int i = 0; i < DataMNG.GetComponent<DataControl>().data.MeetBtnCount; i++)
            {

                var A = Instantiate(MeetBtn);
                A.transform.SetParent(Canvas.transform);

                    float x = 0;
                    float y = 0;

                //pos 재설정
                for(int j = index;  j< dumy.Length ;  j++ )
                {
                    


                    if(dumy[j] == 'X')
                    {
                        x = Convert.ToSingle(  dumy.Substring(index, j-index) );

                        Debug.Log(j + "번째 x: " + x);

                        index = j + 1;
                    }

                    else if(dumy[j] == 'Y')
                    {
                        y = Convert.ToSingle(  dumy.Substring(index, j-index) );

                        Debug.Log(j + "번째 y: " + y );

                        index = j + 1;
                    }

                    else if ( dumy[j] == '!')
                    {
                        A.transform.localPosition = new Vector3(x, y);
                        index = j + 1;
                        break;
                    }

                }  //pos 설정


                BtnList.Add(A);


            }//for



            NowBtn = DataMNG.GetComponent<DataControl>().data.MeetBtnCount;
            MaxBtn = DataMNG.GetComponent<DataControl>().data.MeetBtnCount;
        }//로드시 


        

        // 현재 버튼 수 < 총 버튼수    ==>> 새 버튼이 필요할 때 
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

                BtnList.Add(A);
                DataMNG.GetComponent<DataControl>().data.BtnPos += A.transform.localPosition.x.ToString();
                DataMNG.GetComponent<DataControl>().data.BtnPos += "X";
                DataMNG.GetComponent<DataControl>().data.BtnPos += A.transform.localPosition.y.ToString();
                DataMNG.GetComponent<DataControl>().data.BtnPos += "Y";
                DataMNG.GetComponent<DataControl>().data.BtnPos += 1;
                DataMNG.GetComponent<DataControl>().data.BtnPos += "!";

                DataMNG.GetComponent<DataControl>().data.MeetBtnCount++;


            }//for
        }//if


	}
	
	void Update () {
		

        // 조우화면 페이드
        if( FadeOn)
        {
            Meet.GetComponent<Image>().color        += new Color(0, 0, 0, 1f * Time.deltaTime);
            TextField.GetComponent<Image>().color   += new Color(0, 0, 0, 1f * Time.deltaTime);
            ChoisBtn.GetComponent<Image>().color    += new Color(0, 0, 0, 1f * Time.deltaTime);
            BG.GetComponent<Image>().color          += new Color(0, 0, 0, 1f * Time.deltaTime);
            
            if (BG.GetComponent<Image>().color.a > 0.9) 
            {
                Charector.GetComponent<Image>().color   += new Color(0, 0, 0, 1f * Time.deltaTime);
                Name.color                              += new Color(0, 0, 0, 1f * Time.deltaTime);

                if (Name.color.a == 1)
                    FadeOn = false;
            }
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


    // 조우화면 조정용
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

