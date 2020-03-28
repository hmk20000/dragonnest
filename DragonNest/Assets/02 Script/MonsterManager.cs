using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster
{
    //생성자
    public Monster(string _name, int _lv, int _bg, int _image, float _size )
    {
        name = _name;
        level = _lv;
        BG = _bg;
        no = _image;
        size = _size;
    }

    public string name;
    public int level = 0;

    public int BG = 0;          //이미지 넘버링 (enum 사용)

    public int no = 0;          //이미지 넘버링 (enum 사용)
    public float size = 1;      //이미지 크기 비율


}

public class MonsterManager : MonoBehaviour {

    // --------------------------------------- 배경 정보 ---------------------------------------
    public Sprite[] BGImg;

    public enum Field
    {
        Forest = 0
    }

    // --------------------------------------- 몬스터 정보 ---------------------------------------
   public  Sprite[] MonImg;

   public enum MonNo
    {
        PINK ,
        YELLOW,
        CHOCO,
        GOBLIN,
        ORK
    }



    public Monster Pink    = new Monster("딸기맛 \n 핑크 슬라임",1, (int)Field .Forest  , (int)MonNo.PINK, 1);
    public Monster Yellow  = new Monster("바나나맛 \n 옐로우 슬라임",1, (int)Field .Forest  , (int)MonNo.YELLOW, 1);
    public Monster Choco   = new Monster("쪼꼬맛 \n 다크 슬라임",1, (int)Field .Forest  , (int)MonNo.CHOCO, 0.8f);
    public Monster Goblin  = new Monster("키위 \n 고블린",1, (int)Field .Forest  , (int)MonNo.GOBLIN, 1);
    public Monster Ork     = new Monster("숯불구이 \n 오크",1, (int)Field .Forest  , (int)MonNo.ORK, 1.5f);


    



}

