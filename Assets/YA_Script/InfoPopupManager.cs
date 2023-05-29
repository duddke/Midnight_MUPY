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
            //�ν��Ͻ��� ���� �ְ�
            Instance = this;
            //���� ���� ��ȯ�� �Ǿ �ı����� �ʰ� �ϰڴ�
            DontDestroyOnLoad(gameObject);
        }
        //�׷��� ������
        else
            //���� �ı��ϰڴ�
            Destroy(gameObject);
    }
    public int codeCount;
    public GameObject InfoPopupFactory;

    private void Update()
    {
        if (on)
        {
            //���� ����â���� �ؽ�Ʈ �Է��ϴ� �� ��������
            //PrintText.Instance.OnSavePrint(TitleCodeSwap.Instance.OnSwap(UIManager.Instance.musicalTitle));
            on = false;
        }
    }

    public List<GameObject> TextBox = new List<GameObject>();
    bool on;
    public void OnCreateInfo()
    {
        print(UIManager.Instance.musicalTitle);
        //�� �̸�
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
            //�帣
            /*if (uIManager.codeTitle.Count <= 0)
                for (int i = 0; i < 7; ++i)
                {
                    //����â �����
                    GameObject InfoPopup = Instantiate(InfoPopupFactory, GameObject.Find("Canvas").transform);
                    InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);
                    //���� ����â���� �ؽ�Ʈ �Է��ϴ� �� ��������
                    PrintText.Instance.OnSavePrint(uIManager.codeTitle[i]);
                }
            else*/

            for (int i = 0; i < UIManager.Instance.codeTitle.Count; ++i)
            {
                //����â �����
                GameObject InfoPopup = Instantiate(InfoPopupFactory, GameObject.Find("Canvas").transform);
                if(i==0)
                InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);
                if(i==1)
                InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100);
                if(i>=2)
                    InfoPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100 + 500*(-i+1));
                //���� ����â���� �ؽ�Ʈ �Է��ϴ� �� ��������
                TextBox.Add(InfoPopup);
            }
                PrintText.Instance.OnListSave(UIManager.Instance.codeTitle);
        }
        
    }
}
