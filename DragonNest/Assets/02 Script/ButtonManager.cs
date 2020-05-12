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
    GameObject Owindow;


    public Button[] BodyBtn;


	void Start () {
        DataMNG.GetComponent<DataControl>().data.BodySkill[0] = 2;
        if( DataMNG.GetComponent<DataControl>().data.BodySkill[1] != 2 )
                DataMNG.GetComponent<DataControl>().data.BodySkill[1] = 1;
        

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

            Debug.Log(i + "번 상태: " +  DataMNG.GetComponent<DataControl>().data.BodySkill[i]);
            switch (DataMNG.GetComponent<DataControl>().data.BodySkill[i])
            {
                case 0:
                    {
                        BodyBtn[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f); ;
                        break;
                    }
                case 1:
                    {
                        BodyBtn[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
                        Debug.Log(i + "번 활성준비");
                        break;
                    }

                case 2:
                    {
                        BodyBtn[i].GetComponent<Image>().color = new Color(255, 0, 0,1);

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




    public void BodySkillChoice(int n)
    {
        if (DataMNG.GetComponent<DataControl>().data.BodySkill[n] == 1)
        {


            if (n < 3)
                DataMNG.GetComponent<DataControl>().data.BodySkill[n + 1] = 1;

            DataMNG.GetComponent<DataControl>().data.BodySkill[n] = 2;



            if(n == 1 ) // 피어 2
            {
                DataMNG.GetComponent<DataControl>().data.MonLvRange = 9;
                DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 10;
            }
           else if(n == 2 ) // 피어 3
            {
                DataMNG.GetComponent<DataControl>().data.MonLvRange = 11;
                DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 15;
            }
           else if(n == 3 ) // 피어 4
            {
                DataMNG.GetComponent<DataControl>().data.MonLvRange = 11;
                DataMNG.GetComponent<DataControl>().data.MaxBtnCount = 20;
            }









            DataMNG.GetComponent<DataControl>().saveData();

            BodySkillTreeOff();
        }


    }

}


