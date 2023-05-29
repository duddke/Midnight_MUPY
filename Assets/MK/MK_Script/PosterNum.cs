using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterNum : MonoBehaviour
{
    public int cnt = 0;
    public int posterNum = 0;
    public bool posterInfo = true;

    // Update is called once per frame
    void Update()
    {
        switch (cnt)
        {
            // 郡府磊海胶
            case 0:
                posterNum = 1;
                posterInfo = true;
                print(posterNum);
                break;
           // 硅聪教
            case 1:
                posterNum = 2;
                posterInfo = true;
                print(posterNum);
                break;
            // 利寒
            case 2:
                posterNum = 3;
                posterInfo = true;
                print(posterNum);
                break;
        }
    }
}
