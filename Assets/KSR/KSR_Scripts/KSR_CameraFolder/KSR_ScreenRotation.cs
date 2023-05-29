using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSR_ScreenRotation : MonoBehaviour
{
    private void Update()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
