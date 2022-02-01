using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

    private void Start()
    {
    }

    void Update()
    {
        //continuously rotates
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }


}
