using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoPopupManager : MonoBehaviour
{
    public static InfoPopupManager Instance;
    public bool createStart;

    private void Awake()
    {
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
    public int codeCount;
    public GameObject InfoPopupFactory;

    private void Update()
    {
        if (on)
        {
            //만든 정보창에서 텍스트 입력하는 곳 가져오기
            //PrintText.Instance.OnSavePrint(TitleCodeSwap.Instance.OnSwap(UIManager.Instance.musicalTitle));
            on = false;
        }
    }

    public List<GameObject> TextBox = new List<GameObject>();
    bool on;
    public void OnCreateInfo()
    {
        print(UIManager.Instance.musicalTitle);
        //극 이름
        if (UIManager.Instance.musicalTitle != "")
        {
            GameObject InfoPopup = Instantiate(InfoPopupFactory, GameObject.Find("Canvas").transform);
            InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);
            TextBox.Add(InfoPopup);
            if (SceneManager.GetActiveScene().name== "SyaResultSene")
            {
                on = true;
            }
        }
        else
        {
            //장르
            /*if (uIManager.codeTitle.Count <= 0)
                for (int i = 0; i < 7; ++i)
                {
                    //정보창 만들기
                    GameObject InfoPopup = Instantiate(InfoPopupFactory, GameObject.Find("Canvas").transform);
                    InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);
                    //만든 정보창에서 텍스트 입력하는 곳 가져오기
                    PrintText.Instance.OnSavePrint(uIManager.codeTitle[i]);
                }
            else*/

            for (int i = 0; i < UIManager.Instance.codeTitle.Count; ++i)
            {
                //정보창 만들기
                GameObject InfoPopup = Instantiate(InfoPopupFactory, GameObject.Find("Canvas").transform);
                if(i==0)
                InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);
                if(i==1)
                InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100);
                if(i>=2)
                    InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100 + 500*(-i+1));
                //만든 정보창에서 텍스트 입력하는 곳 가져오기
                TextBox.Add(InfoPopup);
            }
                PrintText.Instance.OnListSave(UIManager.Instance.codeTitle);
        }
        
    }
}
