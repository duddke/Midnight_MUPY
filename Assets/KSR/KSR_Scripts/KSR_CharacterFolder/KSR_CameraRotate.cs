using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSR_CameraRotate : MonoBehaviour
{
    public float rotSpeed = 200.0f;

    public float mx = 0;
    public float my = 0;

    public Joystick rotateJoystick;

    bool isMove;

    private void Start()
    {
        mx = transform.eulerAngles.y;
        my = -transform.eulerAngles.x;

    }

    void Update()
    {
        isMove = GetComponentInParent<KSR_FindSeat>().isMove;
        if (isMove == false)
        {

            float mouse_X = rotateJoystick.Horizontal;
            float mouse_Y = rotateJoystick.Vertical;

            mx += mouse_X * rotSpeed * Time.deltaTime;
            my += mouse_Y * rotSpeed * Time.deltaTime;

            my = Mathf.Clamp(my, -90f, 90f);

            transform.eulerAngles = new Vector3(-my, mx, 0);
        }
    }
}