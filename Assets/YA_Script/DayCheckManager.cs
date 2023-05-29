using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCheckManager : MonoBehaviour
{
    public static DayCheckManager Instance;

    public CkeckBox Mon;
    public CkeckBox Tue;
    public CkeckBox Wed;
    public CkeckBox Thu;
    public CkeckBox Fri;
    public CkeckBox Sat;
    public CkeckBox Sun;

    public int[] input_Day = new int[7];

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mon.trueB == true)
            input_Day[0] = 1;
        else input_Day[0] = 0;
        if (Tue.trueB == true)
            input_Day[1] = 1;
        else input_Day[1] = 0;
        if (Wed.trueB == true)
            input_Day[2] = 1;
        else input_Day[2] = 0;
        if (Thu.trueB == true)
            input_Day[3] = 1;
        else input_Day[3] = 0;
        if (Fri.trueB == true)
            input_Day[4] = 1;
        else input_Day[4] = 0;
        if (Sat.trueB == true)
            input_Day[5] = 1;
        else input_Day[5] = 0;
        if (Sun.trueB == true)
            input_Day[6] = 1;
        else input_Day[6] = 0;

    }
}
