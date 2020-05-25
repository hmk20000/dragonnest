using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ButtonManager : MonoBehaviour {

    [SerializeField]
    GameObject DataMNG;

    [SerializeField]
    GameObject Mwindow;

    [SerializeField]
    GameObject Bwindow;

    [SerializeField]
    GameObject Awindow;

    [SerializeField]
    GameObject Iwindow;
        [SerializeField]
            GameObject SkillIcon;
        [SerializeField]
            Text Cost;
        [SerializeField]
            Text SkillInformation;
        [SerializeField]
            Button SkillInfoOk;

    [SerializeField]
    GameObject Owindow;


    public Button[] SkillBtn;
    int SkillNo = 99;


	void Start () {
        if  ( DataMNG.GetComponent<DataControl>().data.Nowturn == 0 &&
        DataMNG.GetComponent<DataControl>().data.NowWave == 0 )
        {
            DataMNG.GetComponent<DataControl>().data.Skill[0] = 2;
            DataMNG.GetComponent<DataControl>().data.Skill[1] = 1;
            DataMNG.GetComponent<DataControl>().data.Skill[4] = 1;
            DataMNG.GetComponent<DataControl>().data.Skill[12] = 1;
            DataMNG.GetComponent<DataControl>().data.Skill[13] = 1;
            DataMNG.GetComponent<DataControl>().data.Skill[17] = 1;

        }
            

	}
	
	void Update () {
		
	}


    public void MagicSkillTreeOn()
    {
        Mwindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void MagicSkillTreeOff()
    {
        Mwindow.transform.localPosition = new Vector3(2000, 0, 0);

    }


    public void BodySkillTreeOn()
    {
        for( int i = 0; i < 20; i++)
        {


            switch (DataMNG.GetComponent<DataControl>().data.Skill[i])
            {
                case 0:
                    {
                        SkillBtn[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f); ;
                        break;
                    }
                case 1:
                    {
                        SkillBtn[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
                        Debug.Log(i + "번 활성준비");
                        break;
                    }

                case 2:
                    {
                        SkillBtn[i].GetComponent<Image>().color = new Color(1, 1, 0.2f ,1);

                        break;
                    }
            }//switch
        }




        Bwindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void BodySkillTreeOff()
    {
        Bwindow.transform.localPosition = new Vector3(2000, 0, 0);

    }


    public void ArmyListOn()
    {
        Awindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void ArmyListOff()
    {
        Awindow.transform.localPosition = new Vector3(2000, 0, 0);

    }



    public void OptionOn()
    {
        Owindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void OptionOff()
    {
        Owindow.transform.localPosition = new Vector3(2000, 0, 0);

    }


    public void YardScene()
    {
        SceneManager.LoadScene("Yard");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Main");
        
    }

    public void SkillInfoOn (int n)
    {
        SkillNo = n;
        //SkillIcon.GetComponent<Image>().sprite = 
        SkillInformation.text = Skill_Information_Text[n];
        if (DataMNG.GetComponent<DataControl>().data.Skill[n] != 1)
            SkillInfoOk.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        else
            SkillInfoOk.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        Cost.text = SkillCost[n].ToString();
        if( DataMNG.GetComponent<DataControl>().data.mana >= SkillCost[n])
        {
            Cost.color = new Color(0.2f, 0.2f, 1);
        }
        else
        {
            Cost.color = new Color(1, 0.2f, 0.2f);
        }


        
        Iwindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void SKillInfoOff()
    {
        Iwindow.transform.localPosition = new Vector3(0, -2000, 0);

    }



    public void SkillLevelUp ()
    {
        if (DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] != 1)
            return;

        //if (DataMNG.GetComponent<DataControl>().data.mana < SkillCost[ SkillNo]) return;
        //DataMNG.GetComponent<DataControl>().data.mana -= SkillCost[SkillNo];

        switch (SkillNo)
        {
            case 0:  // 1 티어
                {
                        break;
                }
                
            case 1: // 2 티어
                {

                            DataMNG.GetComponent<DataControl>().data.MonLvRange = 12;
                            DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 10;



                            DataMNG.GetComponent<DataControl>().data.Skill[1] = 2;
                            DataMNG.GetComponent<DataControl>().data.Skill[2] = 1;
                    DataMNG.GetComponent<DataControl>().data.Skill[18] = 1;
                    DataMNG.GetComponent<DataControl>().data.Skill[7] = 1;


                    if (DataMNG.GetComponent<DataControl>().data.Skill[13] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[14] = 1;


                    break;
                }
                
            case 2: // 3 티어
                {
                            DataMNG.GetComponent<DataControl>().data.MonLvRange = 16;
                            DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 15;

                            DataMNG.GetComponent<DataControl>().data.Skill[2] = 2;
                            DataMNG.GetComponent<DataControl>().data.Skill[3] = 1;

                    DataMNG.GetComponent<DataControl>().data.Skill[6] = 1;

                   //활성가능상태 체크
                    if (DataMNG.GetComponent<DataControl>().data.Skill[4] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[5] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[7] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[8] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[7] == 2 &&
                        DataMNG.GetComponent<DataControl>().data.Skill[17] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[11] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[17] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[19] = 1;
                        break;
                }
                
            case 3: // 4 티어
                {

                            DataMNG.GetComponent<DataControl>().data.MonLvRange = 20;
                            DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 20;

                            DataMNG.GetComponent<DataControl>().data.Skill[3] = 2;

                    if (DataMNG.GetComponent<DataControl>().data.Skill[5] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[16] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[6] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[9] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[8] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[10] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[12] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[15] = 1;

                    break;
                }
                
            case 4: // 비늘 강화 1
                {

                    DataMNG.GetComponent<DataControl>().data.army += 30;
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;

                    //3티어 활성화 체크 
                    if (DataMNG.GetComponent<DataControl>().data.Skill[2] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[5] = 1;
                    break;
                }
                
            case 5:// 비늘 강화 2
                {

                    DataMNG.GetComponent<DataControl>().data.army += 80;
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;


                    if(DataMNG.GetComponent<DataControl>().data.Skill[3] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[16] = 1;

                    break;
                }
                
            case 6:// 군사 지식 
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    DataMNG.GetComponent<DataControl>().data.goldSupport +=     -0.25f;



                    if (DataMNG.GetComponent<DataControl>().data.Skill[3] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[9] = 1;
                    break;
                }
                
            case 7: //마나 친화력 1
                {
                     DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    DataMNG.GetComponent<DataControl>().data.manaSupport += 0.3f;

                    if (DataMNG.GetComponent<DataControl>().data.Skill[2] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[8] = 1;
                    if (DataMNG.GetComponent<DataControl>().data.Skill[2] == 2 &&
                        DataMNG.GetComponent<DataControl>().data.Skill[17] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[11] = 1;
                    break;
                }
                
            case 8: // 마나 친화력 2
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    DataMNG.GetComponent<DataControl>().data.manaSupport += 0.3f;

                    if (DataMNG.GetComponent<DataControl>().data.Skill[3] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[10] = 1;
                    break;
                }
                
            case 9: // 지배자
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;

                    DataMNG.GetComponent<DataControl>().data.goldSupport += 0.5f;
                    DataMNG.GetComponent<DataControl>().data.powerSupport += 0.2f;

                    break;
                }
                
            case 10: // 마나 폭주
                {
                    DataMNG.GetComponent<DataControl>().data.army -= 200;
                    DataMNG.GetComponent<DataControl>().data.manaSupport += 0.5f;

                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 11: // 연금술 
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 12: // 천리안
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;

                    if (DataMNG.GetComponent<DataControl>().data.Skill[3] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[15] = 1;

                    break;
                }
                
            case 13: //녹생 상단
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    DataMNG.GetComponent<DataControl>().data.Green = true;

                    if (DataMNG.GetComponent<DataControl>().data.Skill[1] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[14] = 1;
                    break;
                }
                
            case 14: // 붉은 상단
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    DataMNG.GetComponent<DataControl>().data.Red = true;
                    break;
                }
                                
            case 15: // 시간 역행
                {
                    DataMNG.GetComponent<DataControl>().data.Nowturn--;
                    DataMNG.GetComponent<DataControl>().data.WaveInfo[DataMNG.GetComponent<DataControl>().data.NowWave]++;


                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                                
            case 16: // 용의 분노
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                                
            case 17: // 불법연금술 1
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;


                    if (DataMNG.GetComponent<DataControl>().data.Skill[2] == 2)
                    {
                        DataMNG.GetComponent<DataControl>().data.Skill[19] = 1;
                        if (DataMNG.GetComponent<DataControl>().data.Skill[7] == 2)
                            DataMNG.GetComponent<DataControl>().data.Skill[11] = 1;
                    }

                    break;
                }
                                
            case 18: //함정설치 
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;


                    break;
                }
                            
            case 19: // 불법연금술 2
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                                



            case 20:
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                                
            case 21:
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }


        }


        DataMNG.GetComponent<DataControl>().data.Nowturn++;
        DataMNG.GetComponent<DataControl>().saveData();
        MainScene();

    }


    string[] Skill_Information_Text =
    {
        "티어1\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 1성 몬스터와 \n   조우 할 수 있다.", // 1 티어
        "티어2\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 2성 몬스터와 \n   조우 할 수 있다.", // 2 티어
        "티어3\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 3성 몬스터와 \n   조우 할 수 있다.", // 3 티어
        "티어4\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 4성 몬스터와 \n   조우 할 수 있다.\n- 두려울 것이 없다.", // 4 티어
        "비늘 강화 1\n\n- 육체를 강화한다.\n- 전투력이 상승한다.\n", // 비늘강화 1
        "비늘 강화 2\n\n- 육체를 강화한다.\n- 전투력이 상승한다.\n", // 비늘강화 2
        "군사 지식\n\n- 군사유지비를 줄인다.\n", // 군사 지식
        "마나 친화력 1\n\n- 모든 방법으로 얻게되는\n  마나량이 상승한다.\n", // 마나 친화력 1
        "마나 친화력 2\n\n- 모든 방법으로 얻게되는\n  마나량이 상승한다.\n", // 마나 친화력 2
        "지배자\n\n- 군사 유지비가 증가한다.\n- 보유한 몬스터의\n  전투력이 증가한다.\n", // 지배자
        "마나 폭주\n\n- 용의 전투력이 감소한다.\n- 마나 습득량이\n  대폭 상승한다.\n", // 마나 폭주
        "연금술\n\n- 마나를 정제하여\n  골드로 변환한다.\n- 골드가 0일 때 필요한\n  만큼 마나가 소모된다.\n", // 연금술
        "천리안\n\n- 다가오는 적을\n  확인할 수 있다.\n- 남은 공세를 표시해준다.\n", // 천리안
        "녹색 상단\n\n- 몬스터를 판매할\n  수 있게 된다.\n- 전투가 끝난 후 찾아온다.\n", // 녹색 상단
        "붉은 상단\n\n- 몬스터를 랜덤 구매할\n  수 있게 된다.\n- 전투가 끝난 후 찾아온다.\n", // 붉은 상단
        "시간 역행\n\n- 적군의 공세를 한턴 늦춘다.\n- 턴 소모가 되지 않으며,\n  즉시 한번 적용된다.\n", // 시간 역행
        "용의 분노\n\n- 전투시 사용 가능\n- 이번 전투에 전투력이\n  오르지만 전투가 끝난 후\n  전투력이 감소한다.\n", // 용의 분노
        "금단 연금술 1\n\n- 전투시 사용 가능\n- 키메라 한마리를\n  군사에 넣는다. \n \n", // 불법 연금술 1
        "함정 설치\n\n- 전투시 사용 가능\n- 이번 공세를 미룬다. \n\n", // 함정 설치
        "금단 연금술 2\n\n- 전투시 사용 가능\n- 키메라 한마리를\n  군사에 넣는다. \n- 불법 연금술 1은 사라진다.\n", // 불법 연금술 2
    };

    int[] SkillCost =
    {
        0, // 티어 1
        200, // 티어 2
        0, // 티어 3
        0, // 티어 4
        0, // 비늘 강화 1

        0, // 비늘 강화 2
        0, // 군사 지식
        0, // 마나 친화력 1
        0, // 마나 친화력 2
        0, // 지배자 

        0, // 마나 폭주
        0, // 연금술
        0, // 천리안
        0, // 녹색 상단
        0, // 붉은 상단

        0, // 시간 역행
        0, // 용의 분노
        0, // 불법 연금술 1
        0, // 함정 설치
        0 // 불법 연금술 2

    };
}


