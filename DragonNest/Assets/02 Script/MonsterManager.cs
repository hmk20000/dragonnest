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
        Forest = 0
    }

    // --------------------------------------- 몬스터 정보 ---------------------------------------
    public Sprite[] MonImg;

    public enum MonNo
    {
        PINK, //0
        YELLOW,
        CHOCO,
        GOBLIN,
        ZOMBIE,
        MUMY, //5
        ORK,
        SKELETON

    }




    //몬스터 배열
    public Monster[] A = {

     new Monster("딸기맛\n슬라임",          1, (int)Field.Forest, (int)MonNo.PINK,    1),
     new Monster("바나나맛\n슬라임",        1, (int)Field.Forest, (int)MonNo.YELLOW,   1),
     new Monster("쪼꼬맛\n슬라임",          1, (int)Field.Forest, (int)MonNo.CHOCO,   0.8f),
     new Monster("키위\n고블린",            1, (int)Field.Forest, (int)MonNo.GOBLIN,     1),
     new Monster("수박\n좀비",              1, (int)Field.Forest, (int)MonNo.ZOMBIE,    1.5f),
     new Monster("미숫가루\n미이라",        1, (int)Field.Forest, (int)MonNo.MUMY,     1.5f),
        //황금 고블린 ++

     new Monster("숯불구이\n오크",          2, (int)Field.Forest, (int)MonNo.ORK, 1.5f),
     new Monster("사골\n스켈레톤",          2, (int)Field.Forest, (int)MonNo.SKELETON, 1.5f)

};


    //public Monster Pink    = new Monster("딸기맛\n핑크 슬라임",       1, (int)Field .Forest  , (int)MonNo.PINK, 1);
    //public Monster Yellow  = new Monster("바나나맛\n옐로우 슬라임",   1, (int)Field .Forest  , (int)MonNo.YELLOW, 1);
    //public Monster Choco   = new Monster("쪼꼬맛\n다크 슬라임",       1, (int)Field .Forest  , (int)MonNo.CHOCO, 0.8f);
    //public Monster Goblin  = new Monster("키위\n고블린",              1, (int)Field .Forest  , (int)MonNo.GOBLIN, 1);
    //public Monster Zombie  = new Monster("수박\n좀비" ,               1, (int)Field .Forest  , (int)MonNo.ZOMBIE, 1.5f);
    //public Monster Mumy    = new Monster("미숫가루\n미이라",          1, (int)Field.Forest   , (int)MonNo.MUMY, 1.5f);
    ////황금 고블린 ++

    //public Monster Ork     = new Monster("숯불구이\n오크",            2, (int)Field .Forest  , (int)MonNo.ORK, 1.5f);
    //public Monster Skeleton= new Monster("사골\n스켈레톤" ,           2, (int)Field .Forest  , (int)MonNo.SKELETON, 1.5f);






}

