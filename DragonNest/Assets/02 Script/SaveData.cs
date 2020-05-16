using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int gold;
    public int mana;
    public int army;




    public List<Vector3> BtnPos;
    public int[] BtnSetMonster = new int[20];
    public int BtnCount = 0;
    public int MaxBtnCount = 5;

    public int LV1Count = 7;
    public int LV2Count = 6;3
    public int LV3Count = 4;
    public int LV4Count = 3;
    public int MonLvRange = 5; //랜덤 함수에 -1 있음

    public int[] QuestList = new int[30];  //  0 : 비활성    1: 활성  2: 클리어  3 : 클리어 후 비활성화
    public int[] QuestInfoNow = new int[30];

    public int Nowturn = 0;
    public int NowWave = 0;


    public int[] BodySkill = new int[5];  //예시 스킬  0: 비활성 1:활성가능 2:활성화
    


}