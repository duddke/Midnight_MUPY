using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSR_OpenURL : MonoBehaviour
{
    bool banishing = true;
    bool elizarbet = true;
    bool wicked = true;
    bool chicago = true;
    bool billy = true;
    bool red = true;

    private void Update()
    {
        if (banishing == false)
        {
            OpenBanishing();
        }
        if (elizarbet == false)
        {
            OpenElizarbet();
        }
        if (wicked == false)
        {
            OpenWicked();
        }
        if (chicago == false)
        {
            OpenChicago();
        }
        if (billy == false)
        {
            OpenBilly();
        }
        if (red == false)
        {
            OpenRed();
        }

    }

    public void OpenBanishing()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=lON6bZJHXjE");
        banishing = true;
    }
    public void OpenElizarbet()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=hUAN7BghvZg");
        elizarbet = true;
    }
    public void OpenWicked()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=EoC_Z4hBDrg");
        wicked = true;
    }
    public void OpenChicago()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=G0ZuPjha-c8");
        chicago = true;
    }
    public void OpenBilly()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=nS5IW85mQbM");
        billy = true;
    }
    public void OpenRed()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=hK62VM2_rug");
        red = true;
    }


}
