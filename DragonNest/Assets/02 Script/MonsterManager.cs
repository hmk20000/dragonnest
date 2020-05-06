using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster
{
    //생성자
    public Monster( string _name,   // 몬스터 이름
                    int _lv,        // 레벨
                    int _BackGroungNum,        // 배경 번호
                    int _ImageNum,     // 이미지 번호
                    float _size     // 크기 (비율)
                  ) 

    {
        name = _name;
        level = _lv;
        BG = _BackGroungNum;
        no = _ImageNum;
        size = _size;
    }

    readonly string name;
    readonly int level = 0;
    readonly int BG = 0;          //이미지 넘버링 (enum 사용)
    readonly int no = 0;          //이미지 넘버링 (enum 사용)
    readonly float size = 1;      //이미지 크기 비율


    public string GetName()         { return name; }
    public int GetLv()              { return level; }
    public int GetBackGroundNum()   { return BG; }
    public int GetImageNum()        { return no; }
    public float GetSize()          { return size; }
}

public class MonsterManager : MonoBehaviour {

    // --------------------------------------- 배경 정보 ---------------------------------------
    public Sprite[] BGImg;

    public enum Field
    {
        Town,
        Forest,
        IceCenter
    }

    // --------------------------------------- 몬스터 정보 ---------------------------------------
    public Sprite[] MonImg;

    public enum MonNo
    {
        SLIM,
        ZOMBIE,
        SKELETON,
        ICEWOLF,
        BENSH

    }




    //몬스터 배열
    public Monster[] A = {

     new Monster("무명초슬라임",          1, (int)Field.Forest, (int)MonNo.SLIM,    0.8f),
     new Monster("좀비",                  1, (int)Field.Forest, (int)MonNo.ZOMBIE,    1),
     new Monster("해골 병사",             1, (int)Field.Forest, (int)MonNo.SKELETON,    1),
     new Monster("아이스 울프",           1, (int)Field.IceCenter, (int)MonNo.ICEWOLF,    1),
     new Monster("벤시",                  1, (int)Field.Forest, (int)MonNo.BENSH,    0.9f),


    };





}

