using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintText : MonoBehaviour
{
    public static PrintText Instance;

    private void Awake()
    {
        Instance = this;
    }

    //장르에 따른 제목과 코드 리스트
    


    //회차정보
    //받는 정보보고 확인 후 진행
    private void Update()
    {

        
    }

    public void OnListSave(List<int> code)
    {
        for (int i = 0; i < code.Count; ++i)
            OnSavePrint(code[i]);
    }

    public void OnSavePrint(int code)
    {
        //리스트에 따라 인포 정보를 서버에서 불러dhrl

        //불러온 내용을 텍스트에 적용
            UIManager.Instance.OnMusicalInfo(code);

    }

    public void  OnPrint()
    {
        //극정보
        for (int i = 0; i < UIManager.Instance.m.Count; ++i)
        {
            GameObject textBox = InfoPopupManager.Instance.TextBox[i];
            TextImage text = textBox.GetComponent<TextImage>();
            text.Title.text = UIManager.Instance.m[i].MUSICAL_TITLE;
            text.Start_End.text = UIManager.Instance.m[i].MUSICAL_STARTDATE + " ~ " + UIManager.Instance.m[i].MUSICAL_FINISHDATE;
            text.Age.text = UIManager.Instance.m[i].MUSICAL_AGE + " 세 관람가";
            text.Genre.text = "장르 : " + UIManager.Instance.m[i].MUSICAL_GENRE;
            if (UIManager.Instance.m[i].MUSICAL_TITLE == "시카고")
            {
                OnDayJuc();
                OnActorJuc();
            }
        }
        
    }

    public List<int> dayCode = new List<int>();
    public void OnDayJuc()
    {
        dayCode.Clear();
        for (int i = 0; i < SerchDefinition.Instance.Day.Length; ++i)
        {
            if (SerchDefinition.Instance.Day[i] == 1)
            {
                dayCode.Add(i + 1);
                SerchDefinition.Instance.Day[i] = 0;
            }
        }
        UIManager.Instance.OnMusicalCastJuc();
    }

    //해당 요일의 자리
    public List<int> dayPlace=new List<int>();
    public string[] DropJuc;
    public void OnDayJucCompare()
    {
        for (int i = 0; i < dayCode.Count; ++i)
        {
            for (int j = 0; j < UIManager.Instance.day.Length; ++j)
            {
                if (dayCode[i] == UIManager.Instance.day[j])
                {
                    dayPlace.Add(j + 1);
                    break;
                }
            }
        }
        DropJuc = new string[dayPlace.Count];
        string s;
        for(int i=0; i< dayPlace.Count;++i)
        {
            s = UIManager.Instance.dayL[dayPlace[i]]+" "+
                UIManager.Instance.day[dayPlace[i]]+" "+
                UIManager.Instance.dayPeo1[dayPlace[i]]+ " " +
                UIManager.Instance.dayPeo2[dayPlace[i]]+ " " +
                UIManager.Instance.dayPeo3[dayPlace[i]]+ " " +
                UIManager.Instance.dayPeo4[dayPlace[i]];
            DropJuc[i] = s;
        }
        DropChangeJucDay();
    }

    public GameObject Event;
    public void DropChangeJucDay()
    {
        Event = GameObject.Find("EventSystem");
        Dropdown DayList = Event.GetComponent<InfoPopupManager>().InfoPopupFactory.GetComponentInChildren<Dropdown>();
        DayList.options.Clear();
        DayList.GetComponentInChildren<Text>().text = "";
        for (int i = 0; i < DropJuc.Length; ++i)
        {
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = DropJuc[i];
            DayList.options.Add(newData);
        }
    }

    public void OnActorJuc()
    {

    }

}
