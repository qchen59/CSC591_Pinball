using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundController : MonoBehaviour
{
    // The rebound sound
    public AudioSource reboundSound;
    private Rigidbody rb;




    private void Start()
    {
        // Assign the Rigidbody component
        rb = GetComponent<Rigidbody>();
        reboundSound = GetComponent<AudioSource>();
    }

    // Before rendering each frame..
    void Update()
    {

    }

    // If on collision with the ball
    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Ball")
        {
            reboundSound.Play();
        }
    }
}
