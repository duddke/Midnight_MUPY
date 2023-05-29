using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    //�Է¹��� �����͸� ���� �ϴ� ��

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private void Awake()
    {
            //�ν��Ͻ��� ���� �ְ�
            Instance = this;
    }

    void Update()
    {
        input_GENRE= GenreCheckManager.Instance.input_GENRE;
        input_DAY = DayCheckManager.Instance.input_Day;
        input_ACTOR = Actor_Dropdown.Instance.ActorList.GetComponentInChildren<Text>().text; ;
        input_Code = Title_Search.Instance.musicalCode;
    }

    // �˻���ư�� ���� ��� �ش��ϴ� ������ ���� Ŭ���� ���·� �����ϱ�
    public InputField inputField_TITLE;
    public int[] input_GENRE = new int[5];
    public int[] input_DAY = new int[7];
    public string input_ACTOR;
    public int input_Code;
}
