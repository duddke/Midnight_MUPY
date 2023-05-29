using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KSR_CharacterRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    public float mx = 0;
   
    public Joystick rotateJoystick;
    public bool isMove;
    public GameObject target;
    public GameObject again;

    private void Start()
    {
        transform.LookAt(target.transform.position);
    }

    void Update()
    {
        isMove = GetComponent<KSR_FindSeat>().isMove;

        if (isMove)
        {

            RaycastHit hit;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - target.transform.position), Time.deltaTime * 3f);
            if (Input.GetButtonDown("Fire1") && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
#if UNITY_EDITOR
                if (!EventSystem.current.IsPointerOverGameObject())
#else
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
                {
                    if (hit.collider.gameObject.name.Contains("HallView"))
                    {
                        GetComponent<KSR_FindSeat>().isMove = false;
                        GetComponent<KSR_FindSeat>().clickCheck = false;
                        again.SetActive(false);

                        transform.position += new Vector3(0, 0, -1f);
                    }
                }
            }
        }

        else
        {
            float mouse_X = rotateJoystick.Horizontal;
            mx += mouse_X * rotSpeed * Time.deltaTime;

            transform.eulerAngles = new Vector3(0, mx, 0);

        }
    }
}
