using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actor_Dropdown : MonoBehaviour
{
    public static Actor_Dropdown Instance;
    public Dropdown ActorList;
    /*string[] actor = new string[HTTPRrquester.];*/

    private void Awake()
    {
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        ActorList = GetComponent<Dropdown>();
    }

    public void Setui()
    {
        ActorList.options.Clear();
        ActorList.GetComponentInChildren<Text>().text = "";
        Dropdown.OptionData Data = new Dropdown.OptionData();
        Data.text = "전체선택";
        ActorList.options.Add(Data);
        for (int i = 0; i < UIManager.Instance.actor.Length; ++i)
        {
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = UIManager.Instance.actor[i];
            ActorList.options.Add(newData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
