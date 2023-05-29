using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



//�Խù�����
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
    /*public string[] ��¥;
    public string[] ����;
    public string[] �ð�;
    public string[] ����;
    public string[] ���;
    public string[] ��â;
    public string[] ����;*/
    /* public string[] ��¥;
     public string[] ����;
     public string[] �ð�;
     public string[] ����;
     public string[] �Ͻ�;
     public string[] ����;
     public string[] ����;*/
    public List<string> date;
    public List<string> days;
    public List<string> time;
    public List<string> Velma;
    public List<string> Roxie;
    public List<string> Billy;
    public List<string> Mama;

    //�ð�
    //����1�⿬���
    //����2�⿬���
    //����3 �⿬���
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
    //��ûŸ�� (GET POST PUT DELETE)
    public RequestType requestType;

    //PostData
    public string postData;//(body)

    //������ ���� �� ȣ������ �Լ� (Action)
    //(Action) �Լ��� ���� �� �ִ� �ڷ���
    public Action<DownloadHandler> onComplete;
    
    //��ȯ�ڷ����� void�̰� �Ű������� ���� �Լ��� ���� �� �ִ�

}
