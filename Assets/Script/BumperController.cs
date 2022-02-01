using UnityEngine;
using System.Collections;

public class BumperController : MonoBehaviour
{
    // The bumper sound
    public AudioSource bumperSound;




    private void Start()
    {
        bumperSound = GetComponent<AudioSource>();
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
            bumperSound.Play();
        }
    }
}