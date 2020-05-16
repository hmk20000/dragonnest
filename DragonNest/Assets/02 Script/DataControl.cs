using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataControl : MonoBehaviour {


    [SerializeField]
    Text GoldPoint;
    static int gold = 0;

    [SerializeField]
    Text ManaPoint;
    static int mana = 0;

    [SerializeField]
    Text ArmyPoint;
    static int army = 0;


    


    float time = 0;
    public SaveData data = new SaveData();

	void Start () {
        //저장 기능 리셋.
       PlayerPrefs.DeleteAll();


		loadData();


    }

	
	void Update () {

        GoldPoint.text = data.gold.ToString();
        ManaPoint.text = data.mana.ToString();
        ArmyPoint.text = data.army.ToString();



        //시간 경과 골드 생성 (저장 연습용)
        time += Time.deltaTime;
        if(time >= 1)
        {
            time--;
            data.gold++;
            saveData();
        }




	}


    string ObjectToJson(object obj){
        return JsonUtility.ToJson(obj);
    }


    T JsonToObject<T>(string jsonData){
        return JsonUtility.FromJson<T>(jsonData);
    }



    public void saveData(){
        string jsonData = ObjectToJson(data);
        PlayerPrefs.SetString("data",jsonData);


        //Debug.Log(jsonData);
    }



    public void loadData(){
        if(!PlayerPrefs.HasKey("data")){
            return;
        }
        string stringData = PlayerPrefs.GetString("data");
        data = JsonToObject<SaveData>(stringData);
    }


}
