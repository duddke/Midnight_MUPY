using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCodeSwap : MonoBehaviour
{
    public static TitleCodeSwap Instance;

    private void Awake()
    {
        //만약에 인스턴스가 널이라면
        if (Instance == null)
        {
            //인스턴스에 나를 넣고
            Instance = this;
            //나를 씬이 전환이 되어도 파괴되지 않게 하겠다
            DontDestroyOnLoad(gameObject);
        }
        //그렇지 않으면
        else
            //나르 파괴하겠다
            Destroy(gameObject);
    }
    public int OnSwap(string title)
    {
        int code = 0;
        if (title== "엘리자벳")
            return code = 1;
        if (title == "베니싱")
            return code = 2;
        if (title == "적벽")
            return code = 3;
        if (title == "위키드")
            return code = 4;
        if (title == "빌리 엘리어트")
            return code = 5;
        if (title == "시카고")
            return code = 6;
        return code;
    }

    public int OnSwapDay(string title)
    {
        int code = 0;
        if (title == "월")
            return code = 1;
        if (title == "화")
            return code = 2;
        if (title == "수")
            return code = 3;
        if (title == "목")
            return code = 4;
        if (title == "금")
            return code = 5;
        if (title == "토")
            return code = 6;
        if (title == "일")
            return code = 7;
        return code;
    }
}
