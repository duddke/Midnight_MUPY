using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerchDefinition : MonoBehaviour
{
    public static SerchDefinition Instance;

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

    public string title;
    public int[] Genre;
    public List<string> GenreStr=new List<string>();
    public int[] Day;
    public List<string> DayStr = new List<string>();
    public string Actor;
    public int Code;


}
