using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Trivia_Level : MonoBehaviour
{
    public Text question;
    public Button op1;
    public Button op2;
    public Button op3;
    public Button op4;

    public int levelNumber = 0;
    public GameObject score;
    private List<string> questionString = new List<string>() { "Which of the following devices is input device?", "Which of the following devices is processing device ?", "What is the full name of AMD?" };
    private List<string> op1String = new List<string>() { "Monitor", "Chipset", "American Micro Development"};
    private List<string> op2String = new List<string>() { "Printer", "Magnetic Devices","Adcance Micro Development"};
    private List<string> op3String = new List<string>() { "Mouse", "Random Access Memory","American Micro Devices"};
    private List<string> op4String = new List<string>() { "Projector", "Hard Disk Drive","Advanced Micro Devices"};

    public List<int> correctAnwsers = new List<int>() { 3, 1, 4 };

    private void Start()
    { 
}

// Update is called once per frame
void Update()
    {
        if (levelNumber == 0)
        {
            question.text = questionString[levelNumber];
            op1.GetComponentInChildren<TextMeshProUGUI>().text = op1String[levelNumber];
            op2.GetComponentInChildren<TextMeshProUGUI>().text = op2String[levelNumber];
            op3.GetComponentInChildren<TextMeshProUGUI>().text = op3String[levelNumber];
            op4.GetComponentInChildren<TextMeshProUGUI>().text = op4String[levelNumber];

            
        }
        
    }
}