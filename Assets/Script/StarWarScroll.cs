using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarWarScroll : MonoBehaviour
{
    public float scrollSpeed = 20;
    public float textAppearHeight = 10;
    public GameObject Button1;
    public GameObject Button2;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;
        if (pos.y >= textAppearHeight) {
            Button1.SetActive(true);
            Button2.SetActive(true);

        }
    }
}
