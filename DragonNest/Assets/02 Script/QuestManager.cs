using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    [SerializeField]
    GameObject QuestView;
    [SerializeField]
    Text TextBox;
    [SerializeField]
    GameObject DataMNG;

    [SerializeField]
    GameObject QuestWindow;

    [SerializeField]
    Text Turn;


    int[] WaveInfo =
    {
        5,
        5,
        5,
        5,
        5,

        5,
        5,
        5,

        3,
        3,
        4

    };




    //int Qcount = 0;

    string[] Qstroy =
    {
        "동굴을 나가 조사하시오 {0}/{1}",
        "여러가지 실험중",
        "이렇게 하는게 맞는가 "

    };
     int[] QuestInfoMax =
    {
        5,
        1,
        1
    };


    int[] NextAttackTime =
    {
        2,
        5,
        8,
        3,
        3,
        3
    };


    void Start ()
    {
        // 게임 첫 시작시 생성되는 퀘스트
        if (DataMNG.GetComponent<DataControl>().data.gold +
            DataMNG.GetComponent<DataControl>().data.mana +
            DataMNG.GetComponent<DataControl>().data.army == 0)
        {
            DataMNG.GetComponent<DataControl>().data.QuestList[0] = 1;
            DataMNG.GetComponent<DataControl>().data.QuestList[1] = 1;
            DataMNG.GetComponent<DataControl>().data.QuestList[2] = 1;


            //DataMNG.GetComponent<DataControl>().data.QuestInfoNow[0] = 5;
        }

        // 활성화 시킬 퀘스트 체크
        for (int i = 0; i < DataMNG.GetComponent<DataControl>().data.QuestList.Length; i++)
        {
            if( DataMNG.GetComponent<DataControl>().data.QuestList[i] == 1)
            {
                var A = Instantiate(TextBox);
                A.transform.SetParent(QuestView.transform);

                A.text = QuestSet(i);
                
                

                if (DataMNG.GetComponent<DataControl>().data.QuestInfoNow[i]  >= QuestInfoMax[i] )
                {
  
                    StartCoroutine(  QuestClear1  ( A )  );
                    DataMNG.GetComponent<DataControl>().data.QuestList[i] = 3;

                }



            }

        }//for



    }
	
	void Update () {
        Turn.text = string.Format("다음 공세\n{0}/{1}", DataMNG.GetComponent<DataControl>().data.Nowturn, WaveInfo[DataMNG.GetComponent<DataControl>().data.NowWave]);
    }


   string QuestSet (int n)
    {
        string re;

        re = string.Format(Qstroy[n], DataMNG.GetComponent<DataControl>().data.QuestInfoNow[n], QuestInfoMax[n]    );

        return re;
    }

     IEnumerator QuestClear1 ( Text _obj)
    {

        yield return new WaitForSeconds(1f);

        for( int i = 0; i < 15; i++)
        {
            if( i % 2 == 0)
            {
                _obj.color = new Color(255, 255, 255, 1f);
                _obj.fontSize += 1;
            }
            else
            {
                _obj.color = new Color(255, 255, 255, 0.8f);
                _obj.fontSize -= 1;

            }


            yield return new WaitForSeconds(0.08f);
          
        }


        Destroy(_obj);
        QuestWindow.transform.localPosition = new Vector3(0, 0, 0);

        yield return null;
    }



    public void QuestReward( int n )
    {
        switch(n)
        {
            case 1:
                {

                    DataMNG.GetComponent<DataControl>().data.gold += 100;
                    break;
                }

            case 2:
                {

                    DataMNG.GetComponent<DataControl>().data.mana += 100;
                    break;
                }

            case 3:
                {

                    DataMNG.GetComponent<DataControl>().data.army += 50;
                    break;
                }

        }


        QuestWindow.transform.localPosition = new Vector3(-2000, 0, 0);

    }


}
