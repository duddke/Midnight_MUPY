using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerchDefinition : MonoBehaviour
{
    public static SerchDefinition Instance;

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

    public string title;
    public int[] Genre;
    public List<string> GenreStr=new List<string>();
    public int[] Day;
    public List<string> DayStr = new List<string>();
    public string Actor;
    public int Code;


}
