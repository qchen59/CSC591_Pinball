using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedComponentController : MonoBehaviour
{
    public string component;
    public bool collected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collected) active();
    }

    void active()
    {

        this.gameObject.SetActive(true);
    }
}
