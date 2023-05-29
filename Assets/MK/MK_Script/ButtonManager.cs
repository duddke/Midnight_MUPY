using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오른쪽 버튼
// 왼쪽 버튼
// : 가운데 있는 포스터가 왼쪽으로 이동, 오른쪽에 있던 포스터가 가운데로 이동, 왼쪽에 있던 포스터가 오른쪽으로 이동
// 스피커 온오프
public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    // 오른쪽
    // 왼쪽

    public bool left = false;
    public bool right = false;
    public float currentTime;
    // 가운데 있는 포스터가 왼쪽으로 이동, 오른쪽에 있던 포스터가 가운데로 이동, 왼쪽에 있던 포스터가 오른쪽으로 이동
    public void OnClickLeft()
    {
        left = true;
        if (right)
        {
            right = false;
        }
    }    
    
    public void OnClickRight()
    {
        right = true;
        if (left)
        {
            left = false;
        }
    }
}
