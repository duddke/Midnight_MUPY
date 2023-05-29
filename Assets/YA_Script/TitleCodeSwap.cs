using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCodeSwap : MonoBehaviour
{
    public static TitleCodeSwap Instance;

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
    public int OnSwap(string title)
    {
        int code = 0;
        if (title== "�����ں�")
            return code = 1;
        if (title == "���Ͻ�")
            return code = 2;
        if (title == "����")
            return code = 3;
        if (title == "��Ű��")
            return code = 4;
        if (title == "���� ������Ʈ")
            return code = 5;
        if (title == "��ī��")
            return code = 6;
        return code;
    }

    public int OnSwapDay(string title)
    {
        int code = 0;
        if (title == "��")
            return code = 1;
        if (title == "ȭ")
            return code = 2;
        if (title == "��")
            return code = 3;
        if (title == "��")
            return code = 4;
        if (title == "��")
            return code = 5;
        if (title == "��")
            return code = 6;
        if (title == "��")
            return code = 7;
        return code;
    }
}
