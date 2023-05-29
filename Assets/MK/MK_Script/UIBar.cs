using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Ȩ��ư ������ ��
// �˻� ��ư ������ ��
// ������ ��ư ������ ��
public class UIBar : MonoBehaviour
{
    public static UIBar instance = null;
    // ����ġ on / off
    public GameObject mainImage;
    public GameObject searchImage;
    public GameObject stageImage;
    public GameObject calenderImage;
    public GameObject musicImage;

    public GameObject eventSystem;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Screen.orientation = ScreenOrientation.Portrait;
            mainImage.SetActive(true);
            searchImage.SetActive(false);
            stageImage.SetActive(false);
            calenderImage.SetActive(false);
            musicImage.SetActive(false);
        }
        if(SceneManager.GetActiveScene().name == "SyaScene")
        {
            mainImage.SetActive(false);
            searchImage.SetActive(true);
            stageImage.SetActive(false);
            calenderImage.SetActive(false);
            musicImage.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "SelectScene")
        {
            Destroy(gameObject);
            Destroy(eventSystem);
        }
        if (SceneManager.GetActiveScene().name == "NumberScene")
        {
            Destroy(gameObject);
            Destroy(eventSystem);
        }

        if (SceneManager.GetActiveScene().name == "Calender")
        {
            mainImage.SetActive(false);
            searchImage.SetActive(false);
            stageImage.SetActive(false);
            calenderImage.SetActive(true);
            musicImage.SetActive(false);
        }
    }
    public void OnClickMain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // ������ Ŭ��
    public void OnClickSearch()
    {
        SceneManager.LoadScene("SyaScene");
    }

    // �Ҹ�
    public void OnClickStage()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void OnClickCalender()
    {
        SceneManager.LoadScene("Calender");
    }
    public void OnClickMusic()
    {
        SceneManager.LoadScene("NumberScene");
    }
}
