using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool stop;
    private void Awake()
    {
        //���࿡ �ν��Ͻ��� ���̶��
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

    public void OnMusicalInfo(int musicalCode)
    {
        
        //������ �Խù� ��ȸ ��û�ϱ�(/post/1)
        //HTTPRequest�� ����
        //post/1, GET, �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        HTTPRrquester requester = new HTTPRrquester();

        //����޾Ƽ� ����Ѵ�
        //http://192.168.1.90:8888/musicals/musicalinfo/1
        requester.url = "http://192.168.1.90:8888/musicals/musicalinfo/" + musicalCode;
        //�ڿ� ������ �ѹ� ���� �޾Ƽ� �� ���븸 ���
        //������ �̸��� ���缭 �ڵ� �ݿ�
        requester.requestType = RequestType.GET;
        if(onlyTitle)
        requester.onComplete = OnCompleteGetMusicalInfo1;
        else
        requester.onComplete = OnCompleteGetMusicalInfo2;

        //HTTP�Ŵ������� ��û
        HTTPManager.Instance.SendRequest(requester);
    }

    public string musicalTitle;
    public string musicalStartDate;
    public string musicalFinishDate;
    public int musicalAge;
    public string musicalPhoto;
    public string musicalGenre;

    public bool printStart;
    public bool onlyTitle;
    public List<MusicalInfoListData> m=new List<MusicalInfoListData>();
    private void OnCompleteGetMusicalInfo1(DownloadHandler handler)
    {
         m.Clear();
        MusicalInfoData musicalInfoData = JsonUtility.FromJson<MusicalInfoData>(handler.text);
        musicalTitle= musicalInfoData.results[0].MUSICAL_TITLE;
        if (onlyTitle)
        {
         m.Clear();
            musicalAge = musicalInfoData.results[0].MUSICAL_AGE;
            InfoPopupManager.Instance.OnCreateInfo();
            for (int i = 0; i < 1; ++i)
                m.Add(musicalInfoData.results[i]);
            PrintText.Instance.OnPrint();
            onlyTitle = false;
        }
        /*print(handler.text);
        print(musicalData.results);
        print(musicalData.status);*/
    }

    private void OnCompleteGetMusicalInfo2(DownloadHandler handler)
    {
        MusicalInfoData musicalInfoData = JsonUtility.FromJson<MusicalInfoData>(handler.text);
        musicalTitle = musicalInfoData.results[0].MUSICAL_TITLE;
        if (SceneManager.GetActiveScene().name == "SyaResultSene")
        {
            for (int i = 0; i < musicalInfoData.results.Count; ++i)
                m.Add(musicalInfoData.results[i]);
            PrintText.Instance.OnPrint();
        }
    }

    public void OnMusicalActorInfo(int musicalCode)
    {
        //������ �Խù� ��ȸ ��û�ϱ�(/post/1)
        //HTTPRequest�� ����
        //post/1, GET, �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        HTTPRrquester requester = new HTTPRrquester();
        
        //����޾Ƽ� ����Ѵ�
        requester.url = "http://192.168.1.90:8888/musicals/"+musicalCode;
        //�ڿ� ������ �ѹ� ���� �޾Ƽ� �� ���븸 ���
        //������ �̸��� ���缭 �ڵ� �ݿ�
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetMusicalActorInfo;

        //HTTP�Ŵ������� ��û
        HTTPManager.Instance.SendRequest(requester);
    }
    public string[] actor;
    private void OnCompleteGetMusicalActorInfo(DownloadHandler handler)
    {
        MusicalData musicalData = JsonUtility.FromJson<MusicalData>(handler.text);
        actor = new string[musicalData.results.Count];
        for (int i = 0; i < musicalData.results.Count; ++i)
        { actor[i] = musicalData.results[i].MUSICAL_ACTOR_NAME.ToString(); }
        Actor_Dropdown.Instance.Setui();
        /*print(handler.text);
        print(musicalData.results);
        print(musicalData.status);*/
    }

    public void OnMusicalCastJuc()//����3
    {
        HTTPRrquester requester = new HTTPRrquester();
        requester.url = "http://192.168.1.90:8888/musicals/musicalinfoai2";//AI���� �޾ƿ� URL
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetMusicalCastInfoJuc;

        HTTPManager.Instance.SendRequest(requester);
    }
    //��Ʈ �迭�� ���� ����
    //���� �ڵ� ���� ��
    //�ش� ������ �ִ� �ڸ���(i+1)�޾ƿ���
    //���� ���� ���� (��¥, ��� �޾ƿ���)
    //�̷��� ��Ʈ�� �迭 ����
    //��Ӵٿ� ������ �ֱ�
    public int[] day;
    public string[] dayL;
    public string[] dayPeo1;
    public string[] dayPeo2;
    public string[] dayPeo3;
    public string[] dayPeo4;

    private void OnCompleteGetMusicalCastInfoJuc(DownloadHandler handler)
    {
        byte[] data = Encoding.Unicode.GetBytes(handler.text);
        string convertData = Encoding.Unicode.GetString(data);


        MusicalCastDataJuc musicalCastData = JsonUtility.FromJson<MusicalCastDataJuc>(handler.text);
        //MusicalCastDataJuc musicalCastData = JsonConvert.DeserializeObject<MusicalCastDataJuc>(handler.text);

        //MusicalCastListDataJuc mu = JsonUtility.FromJson<MusicalCastListDataJuc>(musicalCastData);
        print("XR"+musicalCastData.results);
        day = new int[musicalCastData.results.days.Count];
        for (int i = 0; i < musicalCastData.results.days.Count; ++i)
        {
            day[i] = TitleCodeSwap.Instance.OnSwapDay(musicalCastData.results.days[i]);
        }
        dayL = new string[musicalCastData.results.date.Count];
        for (int i = 0; i < musicalCastData.results.date.Count; ++i)
        {
            dayL[i] = musicalCastData.results.date[i];
        }
        dayPeo1 = new string[musicalCastData.results.Velma.Count];
        for (int i = 0; i < musicalCastData.results.Velma.Count; ++i)
        {
            dayPeo1[i] = musicalCastData.results.Velma[i];
        }
        dayPeo2 = new string[musicalCastData.results.Roxie.Count];
        for (int i = 0; i < musicalCastData.results.Roxie.Count; ++i)
        {
            dayPeo2[i] = musicalCastData.results.Roxie[i];
        }
        dayPeo3 = new string[musicalCastData.results.Billy.Count];
        for (int i = 0; i < musicalCastData.results.Billy.Count; ++i)
        {
            dayPeo3[i] = musicalCastData.results.Billy[i];
        }
        dayPeo4 = new string[musicalCastData.results.Mama.Count];
        for (int i = 0; i < musicalCastData.results.Mama.Count; ++i)
        {
            dayPeo4[i] = musicalCastData.results.Mama[i];
        }
        PrintText.Instance.OnDayJucCompare();
    }

    public void OnMusicalGenreInfo(int genreCode)
    {
        //������ �Խù� ��ȸ ��û�ϱ�(/post/1)
        //HTTPRequest�� ����
        //post/1, GET, �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        HTTPRrquester requester = new HTTPRrquester();

        //����޾Ƽ� ����Ѵ�
        requester.url = "http://192.168.1.90:8888/musicals/musicalgenre/" + genreCode;
        //�ڿ� ������ �ѹ� ���� �޾Ƽ� �� ���븸 ���
        //������ �̸��� ���缭 �ڵ� �ݿ�
        requester.requestType = RequestType.GET;
        /*if (requester.onComplete == OnCompleteGetMusicalGenreInfo)
            requester.onComplete += OnCompleteGetMusicalGenreInfo;
        else*/
        requester.onComplete = OnCompleteGetMusicalGenreInfo;

        //HTTP�Ŵ������� ��û
        HTTPManager.Instance.SendRequest(requester);
    }
    public List<string> genreTitle = new List<string>();//�ٸ� �帣 ģ������ ���̴� ��
    public string[] gtitle; //���� �帣 ģ������ ���̴� ��
    public List<int> codeTitle=new List<int>();//�ٸ� �帣 ģ���� ���̴� ��
    public int[] ctitle; //���� �帣 ģ���� ���̴� ��
    
    private void OnCompleteGetMusicalGenreInfo(DownloadHandler handler)
    {

        // �ҷ��� ����
        MusicalGenreData musicalData = JsonUtility.FromJson<MusicalGenreData>(handler.text);
        gtitle = new string[musicalData.results.Count];
        ctitle = new int[musicalData.results.Count];
        for (int i = 0; i < musicalData.results.Count; ++i)
        {
            string title = musicalData.results[i].MUSICAL_TITLE;
            gtitle[i] = title;
            ctitle[i] = TitleCodeSwap.Instance.OnSwap(title);
        }
        genreTitle.AddRange(gtitle);
        codeTitle.AddRange(ctitle);
        // ���� �����ϱ� MusicalGenreData D1 /D2 �̷�������
        // ����Ʈ�� ���� �帣 �ص� �־����
        // �� ������ ������� �ҷ�����
        InfoPopupManager.Instance.OnCreateInfo();
    }
    public int codeCount;
}
