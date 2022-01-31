using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardZoneController : MonoBehaviour
{
    public AudioSource discardSound;
    public GameObject pg;



    private void Start()
    {
        discardSound = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    // On trigger enter the discard zone
    private void OnTriggerEnter(Collider other)
    {
        GameObject colliBall = other.gameObject;
        if (colliBall.tag == "Ball")
        {
            discardSound.Play();
            // Discard the ball
            colliBall.SetActive(false);
            pg.GetComponent<PinballGame>().discard = true;
            pg.GetComponent<PinballGame>().discardComponent = colliBall.GetComponent<BallController>().component;
        }
    }
}
