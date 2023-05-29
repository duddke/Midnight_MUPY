using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Search : MonoBehaviour
{
    public static Title_Search Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int musicalCode = 0;
    string title;

    public GameObject Genre01;
    public GameObject Genre02;
    public GameObject Genre03;
    public GameObject Genre04;
    public GameObject Genre05;
    public GameObject Genre06;
    public GameObject Genre07;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTitleSearch()
    {
        title = InputManager.Instance.inputField_TITLE.text;
        UIManager.Instance.OnMusicalInfo(TitleCodeSwap.Instance.OnSwap(title));
        if (title == "")
            OnCheck();
        else
        {
            musicalCode = TitleCodeSwap.Instance.OnSwap(title);
            OnCheck();
        }
        UIManager.Instance.OnMusicalActorInfo(musicalCode);
    }
    
    public void OffCheck()
    {
        Genre01.GetComponent<Toggle>().enabled = false;
        Genre02.GetComponent<Toggle>().enabled = false;
        Genre03.GetComponent<Toggle>().enabled = false;
        Genre04.GetComponent<Toggle>().enabled = false;
        Genre05.GetComponent<Toggle>().enabled = false;
        Genre06.GetComponent<Toggle>().enabled = false;
        Genre07.GetComponent<Toggle>().enabled = false;
        Color(Genre01.GetComponentInChildren<Image>());
        Color(Genre02.GetComponentInChildren<Image>());
        Color(Genre03.GetComponentInChildren<Image>());
        Color(Genre04.GetComponentInChildren<Image>());
        Color(Genre05.GetComponentInChildren<Image>());
        Color(Genre06.GetComponentInChildren<Image>());
        Color(Genre07.GetComponentInChildren<Image>());
    }
    public void OnCheck()
    {
        Genre01.GetComponent<Toggle>().enabled = true;
        Genre02.GetComponent<Toggle>().enabled = true;
        Genre03.GetComponent<Toggle>().enabled = true;
        Genre04.GetComponent<Toggle>().enabled = true;
        Genre05.GetComponent<Toggle>().enabled = true;
        Genre06.GetComponent<Toggle>().enabled = true;
        Genre07.GetComponent<Toggle>().enabled = true;
        OnColor(Genre01.GetComponentInChildren<Image>());
        OnColor(Genre02.GetComponentInChildren<Image>());
        OnColor(Genre03.GetComponentInChildren<Image>());
        OnColor(Genre04.GetComponentInChildren<Image>());
        OnColor(Genre05.GetComponentInChildren<Image>());
        OnColor(Genre06.GetComponentInChildren<Image>());
        OnColor(Genre07.GetComponentInChildren<Image>());
    }
    public void Color(Image image)
    {
        Color c = image.color;
        c.r = 0.5f;
        c.g = 0.5f;
        c.b = 0.5f;
        image.color = c;
    }
    public void OnColor(Image image)
    {
        Color c = image.color;
        c.r = 1;
        c.g = 1;
        c.b = 1;
        image.color = c;
    }
}
