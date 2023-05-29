using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��ư
// ���� ��ư
// : ��� �ִ� �����Ͱ� �������� �̵�, �����ʿ� �ִ� �����Ͱ� ����� �̵�, ���ʿ� �ִ� �����Ͱ� ���������� �̵�
// ����Ŀ �¿���
public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    // ������
    // ����

    public bool left = false;
    public bool right = false;
    public float currentTime;
    // ��� �ִ� �����Ͱ� �������� �̵�, �����ʿ� �ִ� �����Ͱ� ����� �̵�, ���ʿ� �ִ� �����Ͱ� ���������� �̵�
    public void OnClickLeft()
    {
        left = true;
        if (right)
        {
            right = false;
        }
    }    
    
    public void OnClickRight()
    {
        right = true;
        if (left)
        {
            left = false;
        }
    }
}
