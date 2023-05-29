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
    // �����ں���
    public void OnClickSRPoster()
    {
        open[0] = true;
        Application.OpenURL("https://tickets.interpark.com/goods/22008801");
    }

    // ��Ͻ�
    public void OnClickYAPoster()
    {
        open[1] = true;
        Application.OpenURL("https://tickets.interpark.com/goods/22009711");
    }

    // ����
    public void OnClickPoster()
    {
        open[2] = true;
        Application.OpenURL("https://tickets.interpark.com/goods/21011991");
    }
}
