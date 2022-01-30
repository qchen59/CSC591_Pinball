using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonScore : MonoBehaviour, IPointerClickHandler
{
    public GameObject score;
    private GameObject correct;
    public GameObject trivia;
    public GameObject yes;
    public GameObject no;
    public void OnPointerClick(PointerEventData eventData)
    {
        int levelNumber = score.GetComponent<score>().levelNumber;
        if (trivia.GetComponent<Trivia_Level>().correct[levelNumber] == 1 && this.gameObject.name.Equals("op1"))
        {
            score.GetComponent<score>().scores += 10;
            trivia.SetActive(false);
            yes.SetActive(true);

        }

        else if (trivia.GetComponent<Trivia_Level>().correct[levelNumber] == 2 && this.gameObject.name.Equals("op2"))
        {
            score.GetComponent<score>().scores += 10;
            trivia.SetActive(false);
            yes.SetActive(true);

        }

        else if (trivia.GetComponent<Trivia_Level>().correct[levelNumber] == 3 && this.gameObject.name.Equals("op3"))
        {
            score.GetComponent<score>().scores += 10;
            trivia.SetActive(false);
            yes.SetActive(true);

        }

        else if (trivia.GetComponent<Trivia_Level>().correct[levelNumber] == 4 && this.gameObject.name.Equals("op4"))
        {
            score.GetComponent<score>().scores += 10;
            trivia.SetActive(false);
            yes.SetActive(true);

        }
        else
        {
            score.GetComponent<score>().scores -= 10;

            trivia.SetActive(false);

            no.SetActive(true);
        }
    }
}
