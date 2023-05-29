using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSR_CamMove : MonoBehaviour
{
    Camera camera;

    public Transform origin;

    bool isMove;
    Vector3 destination;

    public bool check;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1") && check == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform.name.Contains("Chair"))
            {

                SetDestination(hit.point);
                check = true;

            }
            else check = false;
        }


        else if (Input.GetButtonDown("Fire1") && check == true)
        {
            check = false;
        }
        
        if(check) Move();
        
        else
        {
            transform.position = Vector3.Lerp(transform.position, origin.position, Time.deltaTime * 5f);
            
        }
    }

    void SetDestination(Vector3 dest)
    {
        destination = dest;
        isMove = true;
    }

    void Move()
    {
        if(isMove)
        {
            if(Vector3.Distance(destination,transform.position)<=0.1f)
            {
                isMove = false;
                return;
            }
            var dir = destination - transform.position;
            dir.Normalize();
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime*5f);
        }
    }
}
