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

        string name;
        int level = 0;      

        int BG = 0;         //이미지 넘버링 (enum 사용)

        int no = 0;      //이미지 넘버링 (enum 사용)
        float size = 1;     //이미지 크기 비율


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
        GOBLIN,
        ORK
    }



    Monster Pink = new Monster("딸기맛 핑크 슬라임",1, (int)Field .Forest  , (int)MonNo.PINK, 1);


    



}

