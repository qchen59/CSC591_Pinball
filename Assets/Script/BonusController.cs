using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public int scoreIncrement = 10;

    public AudioSource bonusSound;

    public GameObject score;



    private void Start()
    {
        bonusSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //continuously rotates
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }


    // If on trigger enter the bonus object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            // Bonus dispear
            this.gameObject.SetActive(false);
            bonusSound.Play();

            //Add bonus score when hit the bonus
            score.GetComponent<score>().scores = score.GetComponent<score>().scores + scoreIncrement;
        }
    }
}
