using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosterButt : MonoBehaviour
{
    bool[] open = new bool[3] { true, true, true };

    private void Update()
    {
        for(int i = 0; i < open.Length; i++)
        {
            if(open[i] == true)
            {
                open[i] = false;
            }
            if (open[i] == false)
            {
                open[i] = true;
            }
        }

    }
    // 郡府磊海胶
    public void OnClickSRPoster()
    {
        open[0] = true;
        Application.OpenURL("https://tickets.interpark.com/goods/22008801");
    }

    // 硅聪教
    public void OnClickYAPoster()
    {
        open[1] = true;
        Application.OpenURL("https://tickets.interpark.com/goods/22009711");
    }

    // 利寒
    public void OnClickPoster()
    {
        open[2] = true;
        Application.OpenURL("https://tickets.interpark.com/goods/21011991");
    }
}
