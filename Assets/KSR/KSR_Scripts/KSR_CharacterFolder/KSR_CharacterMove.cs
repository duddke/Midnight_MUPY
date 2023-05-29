using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSR_CharacterMove : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5;
    public float finalSpeed = 0;
    Vector3 dir;

    public Joystick moveJoystick;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        //
        float h = moveJoystick.Horizontal;
        float v = moveJoystick.Vertical;
        dir = -transform.right * h - transform.forward * v;
        dir.Normalize();
        dir.y = -9.8f;
        if (Input.GetButton("Fire1")) finalSpeed = speed;
        else finalSpeed = 0;

        cc.Move(dir * finalSpeed * Time.deltaTime);

    }
}
