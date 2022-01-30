using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{

    public int scores = 0;
    public int levelNumber = 0;
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score \n\n  " + scores.ToString();
    }
}
