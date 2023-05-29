using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SerchSave : MonoBehaviour
{


    public void OnSerchClick()
    {
       
        SerchDefinition.Instance.title = InputManager.Instance.inputField_TITLE.text;
        SerchDefinition.Instance.Genre = InputManager.Instance.input_GENRE;
        SerchDefinition.Instance.Day = InputManager.Instance.input_DAY;
        SerchDefinition.Instance.Actor = InputManager.Instance.input_ACTOR;
        SerchDefinition.Instance.Code = InputManager.Instance.input_Code;
        //서치 비교로 키워드에 맞는 항목 출력하는 함수
        bool isExist = false;
        foreach (int num in SerchDefinition.Instance.Genre)
        {
            if (num == 1)
            {
                //장르를 하나라도 체크한 경우
                isExist = true;
                break;
            }       
        }

        if(isExist)
        {

            GenreCompare.Instance.OnCompare(SerchDefinition.Instance.Genre);
        }
        else
        {
            UIManager.Instance.onlyTitle = true;
            UIManager.Instance.OnMusicalInfo(TitleCodeSwap.Instance.OnSwap(UIManager.Instance.musicalTitle));
        }

        SceneManager.LoadScene("SyaResultSene");



    }

}
