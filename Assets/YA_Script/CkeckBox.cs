using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CkeckBox : MonoBehaviour
{
    public bool trueB;
    // Start is called before the first frame update
    public void OnClickChack()
    {
        if(GetComponent<Toggle>().isOn==true)
        {
            trueB = true;
        }
        else
        {
            trueB = false;
        }
    }
}
