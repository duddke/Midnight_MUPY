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

        // ������
        if (Input.GetButtonDown("Fire1"))
        {
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject())
#else
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif   
            {
                //Ŭ�� ó��

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    // ray �� chair �� ������ setdestination �Լ��� chair �� �ڽ��� �������� �ѱ��
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
            // �����ϸ� Move �Լ� ����
            clickCheck = true;
            Move();
        }

        // destination ������ �Ÿ��� 0.1 �̸��̸� �ڸ��� ���� ������ �Ǵ�
        if (Vector3.Distance(transform.position, destination) < 0.1f) seatCheck = true;

        // �־����� �ڸ����� �Ͼ ������ �Ǵ�
        else seatCheck = false;

    }

    void SetDestination(Vector3 dest)
    {
        //�Ѱܹ��� ���� destination ������ ����
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