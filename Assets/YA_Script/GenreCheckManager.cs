using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreCheckManager : MonoBehaviour
{
    public static GenreCheckManager Instance;

    public CkeckBox Ori;
    public CkeckBox Ricen;
    public CkeckBox Creat;
    public CkeckBox Num;
    public CkeckBox Kids;
    public CkeckBox song;
    public CkeckBox dd;

    public int[] input_GENRE = new int[7];

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
        if (Ori.trueB == true)
            input_GENRE[0] = 1;
        else input_GENRE[0] = 0;
        if (Ricen.trueB == true)
            input_GENRE[1] = 1;
        else input_GENRE[1] = 0;
        if (Creat.trueB == true)
            input_GENRE[2] = 1;
        else input_GENRE[2] = 0;
        if (Num.trueB == true)
            input_GENRE[3] = 1;
        else input_GENRE[3] = 0;
        if (Kids.trueB == true)
            input_GENRE[4] = 1;
        else input_GENRE[4] = 0;
        if (song.trueB == true)
            input_GENRE[5] = 1;
        else input_GENRE[5] = 0;
        if (dd.trueB == true)
            input_GENRE[6] = 1;
        else input_GENRE[6] = 0;

    }
}
