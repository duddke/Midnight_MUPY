using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSR_CamRotate : MonoBehaviour
{
    public Transform target;
    public Transform origin;
    bool check;
    bool doubleCheck;
    public GameObject again;

    private void Start()
    {
        again.SetActive(false);
    }
    private void Update()
    {
        doubleCheck = GetComponent<KSR_CamMove>().check;

        if (Input.GetButtonDown("Fire1") && check == false)
        {
            check = true;
        }

        else if (Input.GetButtonDown("Fire1") && check == true)
        {
            check = false;
        }

        if (check == true)
        {
            if (doubleCheck == true)
            {
                Rotate();
                again.SetActive(true);
            }
        }

        else
        {
            Return();
            again.SetActive(false);

        }
    }
    void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), Time.deltaTime*10f);
    }
    void Return()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, origin.rotation, Time.deltaTime * 5f);
    }
}
