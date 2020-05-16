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
     GameObject MeetBG;
    [SerializeField]
     GameObject Charector;
    [SerializeField]
     Text Name;
    [SerializeField]
     GameObject NextBtn;
    [SerializeField]
    GameObject TextField;
    [SerializeField]
    Text StoryText;


    [SerializeField]
    GameObject FadeBlack;
    [SerializeField]
    Text FadeBlackText;
    bool BlackOn = false;

    bool FadeOn = false; // 조우창 패이드



    [SerializeField]
    GameObject ButtonField;
    [SerializeField]
    GameObject choice1;
    [SerializeField]
    GameObject choice2;
    [SerializeField]
    GameObject choice3;
    [SerializeField]
    Text C1;
    [SerializeField]
    Text C2;
    [SerializeField]
    Text C3;
    [SerializeField]
    Sprite use;
    [SerializeField]
    Sprite unuse;
    bool CBtn1 = true;
    bool CBtn2 = true;
    bool CBtn3 = true;

    // 버튼 관리용 @@@@@@@@@@@@@@@@@@@@@@@@@@@
    [SerializeField]
    GameObject CanvasBG;
    [SerializeField]
    Button NestBtn;
    int NowBtn = 0;
    int MaxBtn = 0;
    
    public Button MeetBtn;
    int IngBtn = 99;



    void Start () {
        // 세이브 및 로드우선 호출 

        if (DataMNG.GetComponent<DataControl>().data.BtnCount == 0)  //  첫 생성 동굴버튼
        {

            DataMNG.GetComponent<DataControl>().data.BtnPos.Add(NestBtn.transform.localPosition);


        }
        else // 로드시 
        {
            for( int i = 0; i < DataMNG.GetComponent<DataControl>().data.BtnCount; i++)
            {
                Button A = Instantiate(MeetBtn);
                A.name = i.ToString();
                A.transform.SetParent(CanvasBG.transform);
                A.transform.localPosition = DataMNG.GetComponent<DataControl>().data.BtnPos[i + 1]; // 홈버튼이 배열 0번에 저장되있음

                int _i = i;
                Debug.Log("로드시 순회 확인 " + i  + " 몬스터 번호 :" + _i);
                A.onClick.AddListener(  delegate () { Meeting(_i); }   );


                if(DataMNG.GetComponent<DataControl>().data.BtnSetMonster[i] == 99)
                {
                    A.GetComponent<Image>().color += new Color(0, 0, 0, -0.7f);
                }
            }


            NowBtn = DataMNG.GetComponent<DataControl>().data.BtnCount;
        }//로드시 

        MaxBtn = DataMNG.GetComponent<DataControl>().data.MaxBtnCount;

        

        // 현재 버튼 수 < 총 버튼수    ==>> 새 버튼이 필요할 때 
        if (NowBtn < MaxBtn )
        {

            for( int i = NowBtn; i < MaxBtn; i++)
            {
                Debug.Log("버튼 생성");
                // 버튼 생성
                var A =  Instantiate(MeetBtn);
                    A.name = i.ToString();

                //버튼 위치 조절 
                A.transform.SetParent(CanvasBG.transform);
                bool check = true;
                while(check == true )
                {
                    // 버튼 위치 랜덤 생성
                    A.transform.localPosition = new Vector3(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-350, 200), 0);


                    // 다른 버튼 안 가리게
                    check = false;
                    for (int j = 0; j < DataMNG.GetComponent<DataControl>().data.BtnCount +1 ; j++)
                    {
                        //거리 리턴 함수
                        if( Vector3.Distance(A.transform.localPosition , DataMNG.GetComponent<DataControl>().data.BtnPos[j] ) < 50)
                        {
                            check = true;   
                        }
                    }        

                }//while


                // 몬스터 조우 리스트 랜덤 설정 
                while(true)
                {
                    int index = 0;
                    if (DataMNG.GetComponent<DataControl>().data.LV1Count == 0)
                    {
                        index = 5;
                        if(DataMNG.GetComponent<DataControl>().data.LV2Count == 0)
                        {
                            index = 9;
                            if (DataMNG.GetComponent<DataControl>().data.LV3Count == 0)
                                index = 10;
                        }
                    }


                    int dumy = UnityEngine.Random.Range(index, DataMNG.GetComponent<DataControl>().data.MonLvRange -1);

                    if(DataMNG.GetComponent<DataControl>().data.LV1Count > 0  &&
                        GetComponent<MonsterManager>().A[dumy].GetLv() == 1  )
                    {
                        DataMNG.GetComponent<DataControl>().data.BtnSetMonster[i] = dumy;
                        DataMNG.GetComponent<DataControl>().data.LV1Count--;
                        break;
                    }

                    if (DataMNG.GetComponent<DataControl>().data.LV2Count > 0 &&
                        GetComponent<MonsterManager>().A[dumy].GetLv() == 2)
                    {
                        DataMNG.GetComponent<DataControl>().data.BtnSetMonster[i] = dumy;
                        DataMNG.GetComponent<DataControl>().data.LV2Count--;
                        break;
                    }
                    
                    if (DataMNG.GetComponent<DataControl>().data.LV3Count > 0 &&
                        GetComponent<MonsterManager>().A[dumy].GetLv() == 3)
                    {
                        DataMNG.GetComponent<DataControl>().data.BtnSetMonster[i] = dumy;
                        DataMNG.GetComponent<DataControl>().data.LV3Count--;
                        break;
                    }
                    
                    if (DataMNG.GetComponent<DataControl>().data.LV4Count > 0 &&
                        GetComponent<MonsterManager>().A[dumy].GetLv() == 4)
                    {
                        DataMNG.GetComponent<DataControl>().data.BtnSetMonster[i] = dumy;
                        DataMNG.GetComponent<DataControl>().data.LV4Count--;
                        break;
                    }


                }


                int _i = i;
                A.onClick.AddListener(delegate () { Meeting(_i); });




                DataMNG.GetComponent<DataControl>().data.BtnPos.Add(A.transform.localPosition);
                DataMNG.GetComponent<DataControl>().data.BtnCount++;
                    

            }//for


            NowBtn = MaxBtn;
        }//if




	}
	
	void Update () {
		

        // 조우화면 페이드
        if( FadeOn)
        {
            Meet.GetComponent<Image>().color        += new Color(0, 0, 0, 3f * Time.deltaTime);
            TextField.GetComponent<Image>().color   += new Color(0, 0, 0, 3f * Time.deltaTime);
            MeetBG.GetComponent<Image>().color          += new Color(0, 0, 0, 3f * Time.deltaTime);
            
            if (MeetBG.GetComponent<Image>().color.a > 0.9) 
            {
                Charector.GetComponent<Image>().color   += new Color(0, 0, 0, 0.6f * Time.deltaTime);
                Name.color                              += new Color(0, 0, 0, 0.6f * Time.deltaTime);

                if (Name.color.a >= 0.99)
                {
                    FadeOn = false;

                    StartCoroutine(     Story(  GetComponent<MonsterManager>().A[ DataMNG.GetComponent<DataControl>().data.BtnSetMonster[IngBtn]  ].GetStory()  )  );

                }
            }
        }


        //블랙 커튼 
        if(BlackOn )
        {
            FadeBlack.GetComponent<Image>().color += new Color(0, 0, 0, 2f * Time.deltaTime);
            if (FadeBlack.GetComponent<Image>().color.a > 0.9f) 
                FadeBlackText.color += new Color(0, 0, 0, 1f * Time.deltaTime);


            if( FadeBlackText.color.a > 0.9)
            {
                if (Input.GetMouseButtonDown(0))
                    SceneChange();
            }
        }




	}

    // 분리 진행용 함수 (코루틴)
    IEnumerator Story(string _story)
    {


        for ( int i = 0; i < _story.Length + 1; i++)
        {
            if(Input.GetMouseButton(0))
            {
    
                i = _story.Length  ;

            }

            StoryText.text = _story.Substring(0, i);

            yield return new WaitForSeconds(0.08f);


        }

        NextBtn.GetComponent<Text>().color += new Color(0,0,0, 1);

        yield return null;
    }



    // 조우 버튼용 함수 
    public void Meeting(int n)
    {
        int mon = DataMNG.GetComponent<DataControl>().data.BtnSetMonster[n];

        if (mon == 99) return;

        IngBtn = n;

        Debug.Log("버튼 번호 : " + n + "  몬스터 번호 : " + mon + " @@@ 스토리호출 : " + IngBtn);
 

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
        MeetBG.GetComponent<Image>().sprite         = GetComponent<MonsterManager>().BGImg[_target.GetBackGroundNum()];
        Charector.GetComponent<Image>().sprite  = GetComponent<MonsterManager>().MonImg[_target.GetImageNum()];
        Charector.transform.localScale          = new Vector3(_target.GetSize(), _target.GetSize());
        Name.text                               = _target.GetName();
 



    }


    // 스킬 트리 생성 전 프로토 타입  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  삭제 예정
    bool skill1 = true;
    bool skill2 = true;
    bool skill3 = false;





    //스토리 이후 플레이어 선택권 보여주는 버튼
    public void StoryNextButton()
    {

        C1.text = GetComponent<MonsterManager>().B[0].GetC1();
        if(skill1 == true)  //    [ GetComponent<MonsterManager>().B[   IngBtn   ]  .GetSkill1()  ] 의 습득 체크
        {

        }
        else
        {
            CBtn1 = false;
            choice1.GetComponent<Image>().sprite = unuse;

        }



        C2.text = GetComponent<MonsterManager>().B[0].GetC2();
        if (skill2 == true)  
        {

        }
        else
        {
            CBtn2 = false;
            choice2.GetComponent<Image>().sprite = unuse;

        }



        C3.text = GetComponent<MonsterManager>().B[0].GetC3();
        if (skill3 == true) 
        {

        }
        else
        {
            CBtn3 = false;
            choice3.GetComponent<Image>().sprite = unuse;

        }

      


        ButtonField.transform.localPosition = new Vector3(0, -365, 0);
    }


    // 조우 때  플레이어의 3지선택 선택
    public void ChoiceButton( int n)
    {
        switch(n)
        {
            case 1:
                {
                    if (CBtn1 == false) return;
                    FadeBlackText.text =  GetComponent<MonsterManager>().B[0].GetC1_win();
                    break;
                }




            case 2:
                {
                    if (CBtn2 == false) return;
                    FadeBlackText.text = GetComponent<MonsterManager>().B[0].GetC2_lose();
                    break;
                }




            case 3:
                {
                    if (CBtn3 == false) return;
                    FadeBlackText.text = GetComponent<MonsterManager>().B[0].GetC3_win();
                    break;
                }


        }







        DataMNG.GetComponent<DataControl>().data.BtnSetMonster[IngBtn] = 99;
        if (DataMNG.GetComponent<DataControl>().data.QuestList[0] == 1)
            DataMNG.GetComponent<DataControl>().data.QuestInfoNow[0]++;
            

        DataMNG.GetComponent<DataControl>().saveData();


        FadeBlack.transform.localPosition = new Vector3(0, 0, 0);
        BlackOn = true;
    }

    public void SceneChange()
    {

        SceneManager.LoadScene("Main");


    }


}

