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
    GameObject Owindow;


    public Button[] SkillBtn;
    int SkillNo = 99;


	void Start () {
        DataMNG.GetComponent<DataControl>().data.Skill[0] = 2;
        if( DataMNG.GetComponent<DataControl>().data.Skill[1] != 2 )
                DataMNG.GetComponent<DataControl>().data.Skill[1] = 1;
        

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
        for( int i = 0; i < 4; i++)
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
        SkillInformation.text = Skill_Information_Text[n];
        //SkillIcon.GetComponent<Image>().sprite = 
        //Cost.text = 

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


        switch(SkillNo)
        {
            case 0:  // 1 티어
                {
                        break;
                }
                
            case 1: // 2 티어
                {
                    //if (DataMNG.GetComponent<DataControl>().data.mana < 300)
                    //    return;
                    DataMNG.GetComponent<DataControl>().data.mana -= 300;


                    DataMNG.GetComponent<DataControl>().data.MonLvRange = 9;
                    DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 10;

                    DataMNG.GetComponent<DataControl>().data.Skill[1] = 2;
                    DataMNG.GetComponent<DataControl>().data.Skill[2] = 1;
                    break;
                }
                
            case 2: // 3 티어
                {
                    //if (DataMNG.GetComponent<DataControl>().data.mana < 500)
                    //    return;
                    DataMNG.GetComponent<DataControl>().data.mana -= 500;

                    DataMNG.GetComponent<DataControl>().data.MonLvRange = 11;
                    DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 15;

                    DataMNG.GetComponent<DataControl>().data.Skill[2] = 2;
                    DataMNG.GetComponent<DataControl>().data.Skill[3] = 1;
                    break;
                }
                
            case 3: // 4 티어
                {
                    //if (DataMNG.GetComponent<DataControl>().data.mana < 800)
                    //    return;
                    DataMNG.GetComponent<DataControl>().data.mana -= 800;


                    DataMNG.GetComponent<DataControl>().data.MonLvRange = 11;
                    DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 20;
                    DataMNG.GetComponent<DataControl>().data.Skill[3] = 2;
                    break;
                }
                
            case 4: // 비늘 강화 1
                {
                    DataMNG.GetComponent<DataControl>().data.army += 30;

                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    //3티어 활성화 체크 if(DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[5] = 1;
                    break;
                }
                
            case 5:// 비늘 강화 2
                {
                    DataMNG.GetComponent<DataControl>().data.army += 80;

                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 6:// 군사 지식 
                {

                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 7: //마나 친화력 1
                {


                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    
                    //3티어 활성화 체크 if(DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] == 2)
                        DataMNG.GetComponent<DataControl>().data.Skill[8] = 1;
                    break;
                }
                
            case 8: // 마나 친화력 2
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 9: // 지배자
                {


                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 10: // 마나 폭주
                {
                    DataMNG.GetComponent<DataControl>().data.army -= 200;
                    DataMNG.GetComponent<DataControl>().data.manaSupport += 0.8f;

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

                    break;
                }
                
            case 13: //녹생 상단
                {

                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                
            case 14: // 붉은 상단
                {
                    DataMNG.GetComponent<DataControl>().data.Skill[SkillNo] = 2;
                    break;
                }
                                
            case 15: // 시간 역행
                {



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

        BodySkillTreeOff();
        MagicSkillTreeOff();
        SKillInfoOff();


    }


    string[] Skill_Information_Text =
    {
        "티어1\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 1성 몬스터와 \n   조우 할 수 있다.", // 1 티어
        "티어2\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 2성 몬스터와 \n   조우 할 수 있다.", // 2 티어
        "티어3\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 3성 몬스터와 \n   조우 할 수 있다.", // 3 티어
        "티어4\n\n- 용의 레벨이다.\n- 일정 수준의 기술을\n   배울 수 있다.\n- 4성 몬스터와 \n   조우 할 수 있다.\n- 두려울 것이 없다.", // 4 티어
    };
}


