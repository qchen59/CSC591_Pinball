using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardZoneController : MonoBehaviour
{
    float countDown = 3.5f;
    bool forward = false;
    bool backward = false;
    bool change = false;



    private void Start()
    {
    }

    void Update()
    {
        if (countDown > 0f && !change && !backward) forward = true;
        if (countDown <= 0f && !change)
        {
            forward = false;
            change = true;
        }

        if(countDown <= 0f && change && !backward)
        {
            backward = true;
        }

        if (countDown > 3.5f && change && backward)
        {
            forward = true;
            backward = false;
            change = false;
        }

        if (forward)
        {
            transform.position += new Vector3(0.3f,0f,0f) * Time.deltaTime;
            countDown -= Time.deltaTime;
        }

        else if (backward)
        {
            transform.position += new Vector3(-0.3f, 0f, 0f) * Time.deltaTime;
            countDown += Time.deltaTime;
        }
    }


}
