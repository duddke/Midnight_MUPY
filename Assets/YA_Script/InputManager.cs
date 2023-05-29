using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    //입력받은 데이터를 관리 하는 곳

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private void Awake()
    {
            //인스턴스에 나를 넣고
            Instance = this;
    }

    void Update()
    {
        input_GENRE= GenreCheckManager.Instance.input_GENRE;
        input_DAY = DayCheckManager.Instance.input_Day;
        input_ACTOR = Actor_Dropdown.Instance.ActorList.GetComponentInChildren<Text>().text; ;
        input_Code = Title_Search.Instance.musicalCode;
    }

    // 검색버튼을 누를 경우 해당하는 정보를 위의 클래스 형태로 저장하기
    public InputField inputField_TITLE;
    public int[] input_GENRE = new int[5];
    public int[] input_DAY = new int[7];
    public string input_ACTOR;
    public int input_Code;
}
