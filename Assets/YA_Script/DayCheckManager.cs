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
