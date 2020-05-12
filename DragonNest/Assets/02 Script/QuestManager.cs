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
        if (DataMNG.GetComponent<DataControl>().data.gold +
            DataMNG.GetComponent<DataControl>().data.mana +
            DataMNG.GetComponent<DataControl>().data.army == 0)
        {
            DataMNG.GetComponent<DataControl>().data.QuestList[0] = 1;
            DataMNG.GetComponent<DataControl>().data.QuestList[1] = 1;
            DataMNG.GetComponent<DataControl>().data.QuestList[2] = 1;
        }


        for (int i = 0; i < DataMNG.GetComponent<DataControl>().data.QuestList.Length; i++)
        {
            if( DataMNG.GetComponent<DataControl>().data.QuestList[i] == 1)
            {
                var A = Instantiate(TextBox);
                A.transform.SetParent(QuestView.transform);

                A.text = QuestSet(i);
                //A.transform.localPosition = new Vector3(10, (Qcount * - 20) -10, 0);
            }

        }
		
	}
	
	void Update () {
		
	}


   string QuestSet (int n)
    {
        string re;

       // Debug.Log("퀘스트 세팅 넘버 " + n);
       // Debug.Log("맥스 넘버 " + QuestInfoMax[n]);

        re = string.Format(Qstroy[n], DataMNG.GetComponent<DataControl>().data.QuestInfoNow[n], QuestInfoMax[n]    );

        return re;
    }
}
