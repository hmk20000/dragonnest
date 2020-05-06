using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public int gold;
    public int mana;
    public int army;




    public List<Vector3> BtnPos;
    public int [] BtnSetMonster = new int [20];
    public int BtnCount = 0;

    public int LV1Count = 7;
    public int LV2Count = 6;
    public int LV3Count = 4;
    public int LV4Count = 3;
    public int MonLvRange = 5; //랜덤 함수에 -1 있음
}
