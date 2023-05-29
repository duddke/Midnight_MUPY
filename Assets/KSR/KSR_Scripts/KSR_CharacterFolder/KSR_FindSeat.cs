using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KSR_FindSeat : MonoBehaviour
{
    public GameObject target;
    float speed;

    Vector3 destination;

    public bool isMove = false;
    bool check;
    public bool seatCheck;
    public bool clickCheck;

    public GameObject again;

    private void Start()
    {
        speed = GetComponent<KSR_CharacterMove>().finalSpeed;
        again.SetActive(false);
    }

    private void Update()
    {

        // 누르면
        if (Input.GetButtonDown("Fire1"))
        {
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject())
#else
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif   
            {
                //클릭 처리

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    // ray 가 chair 에 맞으면 setdestination 함수에 chair 의 자식의 포지션을 넘긴다
                    if (hit.collider.gameObject.name.Contains("Chair"))
                    {
                        SetDestination(hit.transform.GetChild(0).gameObject.transform.position);
                    }
                }
                check = true;
            }

        }
        if (check == true)
        {
            // 충족하면 Move 함수 실행
            clickCheck = true;
            Move();
        }

        // destination 까지의 거리가 0.1 미만이면 자리에 앉은 것으로 판단
        if (Vector3.Distance(transform.position, destination) < 0.1f) seatCheck = true;

        // 멀어지면 자리에서 일어난 것으로 판단
        else seatCheck = false;

    }

    void SetDestination(Vector3 dest)
    {
        //넘겨받은 값을 destination 변수에 대입
        destination = dest;
        isMove = true;
    }

    void Move()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * 5f);
            
            if (Vector3.Distance(destination, transform.position) < 0.1f && speed <= 0 && clickCheck == true)
            {
                transform.position = destination;
                again.SetActive(true);

                print(clickCheck);
            }
            //if (Vector3.Distance(destination, transform.position) <= 0.1f)
            //{
                
            //    return;
            //}
        }
        clickCheck = false;
    }
}