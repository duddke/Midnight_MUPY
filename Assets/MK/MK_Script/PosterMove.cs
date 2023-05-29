using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterMove : MonoBehaviour
{
    // 속도
    public float speed = 1;

    ButtonManager butt;

    RectTransform rect;

    float currentTime;

    // 각 지점의 RectTransform 가져오기
    RectTransform l_pos;
    RectTransform c_pos;
    RectTransform r_pos;

    int cnt = 0;

    private void Start()
    {
        rect = GetComponent<RectTransform>();

        l_pos = GameObject.Find("LeftPos").GetComponent<RectTransform>();
        c_pos = GameObject.Find("CenterPos").GetComponent<RectTransform>();
        r_pos = GameObject.Find("RightPos").GetComponent<RectTransform>();

        butt = GameObject.Find("MainButtManager").GetComponent<ButtonManager>();
    }

    private void FixedUpdate()
    {
        if (butt.left == true && butt.right == false)
        {
            if (transform.parent.name == "CenterPos")
            {
                MoveLeft(r_pos, speed * 2, 1);
            }
            if (transform.parent.name == "LeftPos")
            {
                MoveLeft(c_pos, speed * 2, 1);
            }
            if (transform.parent.name == "RightPos")
            {
                Teleport(l_pos, 3000, 5);
            }
        }
        if (butt.left == false && butt.right == false)
        {
            if (transform.parent.name == "CenterPos")
            {
                MoveLeft(r_pos, speed, 2);
            }
            if (transform.parent.name == "LeftPos")
            {
                MoveLeft(c_pos, speed, 2);
            }
            if (transform.parent.name == "RightPos")
            {
                Teleport(l_pos, 3000, 5);
            }
        }
        else if(butt.right && butt.left == false)
        {
            if (transform.parent.name == "CenterPos")
            {
                MoveRight(c_pos);

            }
            if (transform.parent.name == "LeftPos")
            {
                MoveRight(l_pos);
            }
            if (transform.parent.name == "RightPos")
            {
                currentTime = 0;
                Teleport(r_pos, 0, 6);
            }
        }
    }

    public void MoveRight(RectTransform rectTransform)
    {

        transform.position += Vector3.right * speed * Time.deltaTime;

        if (rect.anchoredPosition.x >= 0)
        {
            currentTime += Time.deltaTime;
            butt.right = false;
            rect.anchoredPosition = new Vector2(0, 0);

            if(currentTime > 2)
            {
                transform.SetParent(rectTransform);
                rect.anchoredPosition = new Vector3(0, 0);
                currentTime = 0;
            }
        }

    }

    public void MoveLeft(RectTransform rectTransform, float finSpeed, float time)
    {
        transform.position += Vector3.left * finSpeed * Time.deltaTime;

        if (rect.anchoredPosition.x <= -1500)
        {
            currentTime += Time.deltaTime;
            rect.anchoredPosition = new Vector2(-1500, 0);
            if (currentTime > time)
            {
                butt.left = false;
                transform.SetParent(rectTransform);
                rect.anchoredPosition = new Vector3(0, 0);
                currentTime = 0;
            }
        }

    }

    public void Teleport(RectTransform rectTransform, float a, float time)
    {
        currentTime += Time.deltaTime;
        rect.anchoredPosition = new Vector3(a, 0);
        if (currentTime > time)
        {
            butt.left = false;
            butt.right = false;
            transform.SetParent(l_pos);
            rect.anchoredPosition = new Vector3(0, 0);
            currentTime = 0;
        }
    }

}
