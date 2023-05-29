using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



//게시물정보
#region MusicalInfo
[Serializable]
public class MusicalInfoData
{
    public int status;
    public string message;
    public List<MusicalInfoListData> results;
}

[Serializable]
public class MusicalInfoListData
{
    public string MUSICAL_TITLE;
    public string MUSICAL_STARTDATE;
    public string MUSICAL_FINISHDATE;
    public int MUSICAL_AGE;
    public string MUSICAL_PHOTO;
    public string MUSICAL_GENRE;
}
#endregion


#region MusicalActor
[Serializable]
public class MusicalData
{
    public int status;
    public string message;
    public List<MusicalListData> results;
}

[Serializable]
public class MusicalListData
{
    public string MUSICAL_TITLE;
    public string MUSICAL_ACTOR_NAME;
}
#endregion


#region MusicalCast
[Serializable]
public class MusicalCastDataJuc
{
    public int status;
    public string message;
    
    public MusicalCastListDataJuc results;
}

[Serializable]
public class MusicalCastListDataJuc
{
    /*public string[] 날짜;
    public string[] 요일;
    public string[] 시간;
    public string[] 조조;
    public string[] 장비;
    public string[] 도창;
    public string[] 주유;*/
    /* public string[] 날짜;
     public string[] 요일;
     public string[] 시간;
     public string[] 빌마;
     public string[] 록시;
     public string[] 빌리;
     public string[] 마마;*/
    public List<string> date;
    public List<string> days;
    public List<string> time;
    public List<string> Velma;
    public List<string> Roxie;
    public List<string> Billy;
    public List<string> Mama;

    //시간
    //역할1출연배우
    //역할2출연배우
    //역할3 출연배우
}
#endregion

#region MusicalGenre
[Serializable]
public class MusicalGenreData
{
    public int status;
    public string message;
    public List<MusicalGenreListData> results;
}
[Serializable]
public class MusicalGenreListData
{
    public string MUSICAL_TITLE;
    public string MUSICAL_STARTDATE;
    public string MUSICAL_FINISHDATE;
    public string MUSICAL_PHOTO;
    public string MUSICAL_GENRE;
}
#endregion

public enum RequestType
{
    POST,
    GET,
    PUT,
    DELETE
}

public class HTTPRrquester : MonoBehaviour
{
    //url
    public string url;
    //요청타입 (GET POST PUT DELETE)
    public RequestType requestType;

    //PostData
    public string postData;//(body)

    //응답이 왔을 때 호출해줄 함수 (Action)
    //(Action) 함수를 담을 수 있는 자료형
    public Action<DownloadHandler> onComplete;
    
    //반환자료형이 void이고 매개변수가 없는 함수를 넣을 수 있다

}
