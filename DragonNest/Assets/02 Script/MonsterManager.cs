using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster
{
    //생성자
    public Monster(string _name,   // 몬스터 이름
                    int _lv,        // 레벨
                    int _BackGroungNum,        // 배경 번호
                    int _ImageNum,     // 이미지 번호
                    float _size,     // 크기 (비율)
                    string _story
                  ) 

    {
        name = _name;
        level = _lv;
        BG = _BackGroungNum;
        no = _ImageNum;
        size = _size;
        story = _story;
    }

    readonly string name;
    readonly int level = 0;
    readonly int BG = 0;          //이미지 넘버링 (enum 사용)
    readonly int no = 0;          //이미지 넘버링 (enum 사용)
    readonly float size = 1;      //이미지 크기 비율
    readonly string story = "";   //조우시 스토리 라인

    struct MeetInfo
    {
        string BtnText;

    }


    public string GetName()         { return name; }
    public int GetLv()              { return level; }
    public int GetBackGroundNum()   { return BG; }
    public int GetImageNum()        { return no; }
    public float GetSize()          { return size; }
    public string GetStory()          { return story; }

}

// 조우시 관련 대사
public class MeetInfo
{
    public MeetInfo(string _c1, string _c2, string _c3 ,
        int _1 ,string _1win, string _1lose,
        int _2 ,string _2win, string _2lose,
        int _3, string _3win, string _3lose   )

    {

        C1 = _c1;
        C2 = _c2;
        C3 = _c3;
        C1_1 = _1win;
        C1_2 = _1lose;
        C2_1 = _2win;
        C2_2 = _2lose;
        C3_1 = _3win;
        C3_2 = _3lose;

        Skill1 = _1;
        Skill2 = _2;
        Skill3 = _3;

    }


    //선택지 
    readonly string C1;
    readonly string C2;
    readonly string C3;

    //선택지 결과
    int Skill1;
    readonly string C1_1;  // 성공
    readonly string C1_2;  // 실패

    int Skill2;
    readonly string C2_1;
    readonly string C2_2;

    int Skill3;
    readonly string C3_1;
    readonly string C3_2;

    public string GetC1() { return C1; }
    public string GetC2() { return C2; }
    public string GetC3() { return C3; }

    public int GetSkill1() { return Skill1; }
    public int GetSkill2() { return Skill2; }
    public int GetSkill3() { return Skill3; }

    public string GetC1_win() { return C1_1; }
    public string GetC2_win() { return C2_1; }
    public string GetC3_win() { return C3_1; }

    public string GetC1_lose() { return C1_2; }
    public string GetC2_lose() { return C2_2; }
    public string GetC3_lose() { return C3_2; }

};


public class MonsterManager : MonoBehaviour {

    // --------------------------------------- 배경 정보 ---------------------------------------
    public Sprite[] BGImg;

    public enum Field
    {
        Town,
        Forest,
        IceCenter,
        Volcano
    }

    // --------------------------------------- 몬스터 정보 ---------------------------------------
    public Sprite[] MonImg;

    public enum MonNo
    {
        // lv1
        SLIM,
        ZOMBIE,
        SKELETON,
        ICEWOLF,
        EVEILEYE,

        //lv2
        TROLL,
        BERSERKER,
        TIKETTER,
        MAGE,

        //lv3
        BENSHEE,
        ICELION,

        //Lv4
        CAPTAIN

    }




    //몬스터 배열
    public Monster[] A = {
        // Lv 1
     new Monster("무명초슬라임",          1, (int)Field.Forest, (int)MonNo.SLIM,    0.8f , "오묘한 빛깔의 슬라임을 발견했다."),
     new Monster("좀비",                  1, (int)Field.Forest, (int)MonNo.ZOMBIE,    1 , "가래 끍는 소리와 심한 악취가 나는 좀비를 발견했다.\n느린 움직임으로 위협적이지는 않다. "),
     new Monster("해골 병사",             1, (int)Field.Forest, (int)MonNo.SKELETON,    1 , "가벼운 복장의 해골병사를 만났다. "),
     new Monster("아이스 울프",           1, (int)Field.IceCenter, (int)MonNo.ICEWOLF,    1,"얼음으로 이루어진 작은 생물체를 발견했다.\n호기심이 가득한 눈빛으로 이쪽을 바라보고 있다."),
     new Monster("이블 아이",               1, (int)Field.Volcano, (int)MonNo.EVEILEYE,    1,"기분 나쁘게 생긴 눈알이 공중에서 내려다 보고 있다."),


        // Lv 2
     new Monster("트롤",                    2, (int)Field.IceCenter, (int)MonNo.TROLL,    1,"나무가 부러지는 소리와 함께 거대한 덩치의 트롤이 나타났다."),
     new Monster("광전사",                  2, (int)Field.IceCenter, (int)MonNo.BERSERKER,    1,"어딘지 모르게 위험해 보이는 녀석이 다가온다."),
     new Monster("티켓터",                  2, (int)Field.IceCenter, (int)MonNo.TIKETTER,    1," \"반갑습니다. 무엇을 도와드릴까요?\"\n라고 물어오는 녀석의 표정이 마음에 안든다. "),
     new Monster("화염술사",                  2, (int)Field.Volcano, (int)MonNo.MAGE,    1," \" 드래곤이 어찌 이곳에...  \"\n라며 놀라는 인간족 마법사를 만났다. "),



        // Lv 3
     new Monster("벤시",                      3, (int)Field.Forest, (int)MonNo.BENSHEE,    0.9f, "어쩐지 한기가 돈다 싶었는데 \n 냉기를 품은 몬스터가 나타났다."),


        //Lv 4
     new Monster("캡틴\n크래블",                  4, (int)Field.IceCenter, (int)MonNo.CAPTAIN,    0.9f, "얼음 지역을 다스리는 캡틴 크래블을 만났다. \n  "),

    };



    //  string _c1, string _c2, string _c3 , 
    //   string _1win, string _1lose,   string _2win, string _2lose,    string _3win, string _3lose 
    public MeetInfo[] B =
    {
        new MeetInfo ( "공격한다. " , "마법을 쓴다. " , "후려친다.  " ,
                       0, "괜찮은 맛이었다. "  ,  "" ,
                       1,  "" , "동전만 남기고 모두 불타버렸다.  ",
                       2,  "아무일도 일어나지 않았다. " ,  "아무일도 일어나지 않았다.")
                    

    };


}

