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

    public void OnMusicalInfo(int musicalCode)
    {
        
        //서버에 게시물 조회 요청하기(/post/1)
        //HTTPRequest를 생성
        //post/1, GET, 완료되었을 때 호출되는 함수
        HTTPRrquester requester = new HTTPRrquester();

        //응답받아서 출력한다
        //http://192.168.1.90:8888/musicals/musicalinfo/1
        requester.url = "http://192.168.1.90:8888/musicals/musicalinfo/" + musicalCode;
        //뒤에 뮤지컬 넘버 숫자 받아서 그 내용만 출력
        //뮤지컬 이름에 맞춰서 코드 반영
        requester.requestType = RequestType.GET;
        if(onlyTitle)
        requester.onComplete = OnCompleteGetMusicalInfo1;
        else
        requester.onComplete = OnCompleteGetMusicalInfo2;

        //HTTP매니저에게 요청
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
        //서버에 게시물 조회 요청하기(/post/1)
        //HTTPRequest를 생성
        //post/1, GET, 완료되었을 때 호출되는 함수
        HTTPRrquester requester = new HTTPRrquester();
        
        //응답받아서 출력한다
        requester.url = "http://192.168.1.90:8888/musicals/"+musicalCode;
        //뒤에 뮤지컬 넘버 숫자 받아서 그 내용만 출력
        //뮤지컬 이름에 맞춰서 코드 반영
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetMusicalActorInfo;

        //HTTP매니저에게 요청
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

    public void OnMusicalCastJuc()//적벽3
    {
        HTTPRrquester requester = new HTTPRrquester();
        requester.url = "http://192.168.1.90:8888/musicals/musicalinfoai2";//AI정보 받아올 URL
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetMusicalCastInfoJuc;

        HTTPManager.Instance.SendRequest(requester);
    }
    //인트 배열로 요일 저장
    //요일 코드 대입 비교
    //해당 요일이 있는 자릿값(i+1)받아오기
    //요일 외의 내역 (날짜, 배우 받아오기)
    //이렇게 스트립 배열 생성
    //드롭다운 내역에 넣기
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
        //서버에 게시물 조회 요청하기(/post/1)
        //HTTPRequest를 생성
        //post/1, GET, 완료되었을 때 호출되는 함수
        HTTPRrquester requester = new HTTPRrquester();

        //응답받아서 출력한다
        requester.url = "http://192.168.1.90:8888/musicals/musicalgenre/" + genreCode;
        //뒤에 뮤지컬 넘버 숫자 받아서 그 내용만 출력
        //뮤지컬 이름에 맞춰서 코드 반영
        requester.requestType = RequestType.GET;
        /*if (requester.onComplete == OnCompleteGetMusicalGenreInfo)
            requester.onComplete += OnCompleteGetMusicalGenreInfo;
        else*/
        requester.onComplete = OnCompleteGetMusicalGenreInfo;

        //HTTP매니저에게 요청
        HTTPManager.Instance.SendRequest(requester);
    }
    public List<string> genreTitle = new List<string>();//다른 장르 친구들이 모이는 곳
    public string[] gtitle; //같은 장르 친구들이 모이는 곳
    public List<int> codeTitle=new List<int>();//다른 장르 친구들 모이는 곳
    public int[] ctitle; //같은 장르 친구들 모이는 곳
    
    private void OnCompleteGetMusicalGenreInfo(DownloadHandler handler)
    {

        // 불러온 정보
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
        // 각각 저장하기 MusicalGenreData D1 /D2 이런식으로
        // 리스트에 같은 장르 극들 넣어놓기
        // 다 끝나면 출력으로 불러오기
        InfoPopupManager.Instance.OnCreateInfo();
    }
    public int codeCount;
}
