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

    //�������� ��û
    //url(post/1), GET
    public void SendRequest(HTTPRrquester requester)
    {
        StartCoroutine(Send(requester));
        
    }

    IEnumerator Send(HTTPRrquester requester)
    {
        UnityWebRequest webRequest = null;
        //requestType�� ���� ȣ���� �ؾ���� �Ѵ�
        switch(requester.requestType)
        {
            case RequestType.POST://����
                break;
            case RequestType.GET:
                webRequest = UnityWebRequest.Get(requester.url);
                break;
            case RequestType.PUT: //����
                break;
            case RequestType.DELETE:
                break;
        }

        //��û�� ������ ������ ������ �� ������ ��ٸ���
        yield return webRequest.SendWebRequest(); //�� ������ �����ٴ� ������ ���� �ؿ� ģ���� ����

        // ���࿡ ���信 �����ߴٸ�
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            print(webRequest.downloadHandler.text);
            requester.onComplete(webRequest.downloadHandler);
            print("��ſϷ�");
        }
        // �׷��� �ʴٸ�
        else
        {
            // ���� ��� ����
            print("��Ž���"+webRequest.result+"\n"+webRequest.error);
        }
        yield return null;
    }
}
