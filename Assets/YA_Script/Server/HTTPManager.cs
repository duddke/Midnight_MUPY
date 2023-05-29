using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class HTTPManager : MonoBehaviour
{
    public static HTTPManager Instance;
    public bool compare;

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

    //서버에게 요청
    //url(post/1), GET
    public void SendRequest(HTTPRrquester requester)
    {
        StartCoroutine(Send(requester));
        
    }

    IEnumerator Send(HTTPRrquester requester)
    {
        UnityWebRequest webRequest = null;
        //requestType에 따라서 호출을 해야줘야 한다
        switch(requester.requestType)
        {
            case RequestType.POST://생성
                break;
            case RequestType.GET:
                webRequest = UnityWebRequest.Get(requester.url);
                break;
            case RequestType.PUT: //수정
                break;
            case RequestType.DELETE:
                break;
        }

        //요청을 서버에 보내고 응답이 올 때까지 기다린다
        yield return webRequest.SendWebRequest(); //이 정보를 보내겟다 응답이 오면 밑에 친구들 실행

        // 만약에 응답에 성공했다면
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            print(webRequest.downloadHandler.text);
            requester.onComplete(webRequest.downloadHandler);
            print("통신완료");
        }
        // 그렇지 않다면
        else
        {
            // 서버 통신 실패
            print("통신실패"+webRequest.result+"\n"+webRequest.error);
        }
        yield return null;
    }
}
