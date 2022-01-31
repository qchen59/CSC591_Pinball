using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;
using System.Collections.Generic;

public class PinballGame : MonoBehaviour
{

    public Text scoreText;
    public Text displayText;
    public Text levelText;
    public bool discard = false;
    public string discardComponent;
    public bool discardCorrect = false;
    public bool discardIncorrect = false;
    public bool collectCorrect = false;
    public bool collectIncorrect = false;

    public AudioSource correctSound;
    public AudioSource incorrectSound;
    public AudioSource BGM;
    public AudioSource plungerSound;

    public float plungerSpeed = 100;
    public GameObject score;

    public int currentLevel = 1;

    public List<string> correctComponent = new List<string>() { "correct component 1", "correct component 2", "correct component 3" };

    public List<string> collectedComponent = new List<string>();
    public List<string> componentList = new List<string>() { "correct component 1", "correct component 2", "correct component 3", "incorrect component 1", "incorrect component 2", "incorrect component 3" };
    public List<string> componentNames = new List<string>() { "correct component 1", "correct component 2", "correct component 3", "incorrect component 1", "incorrect component 2", "incorrect component 3" };


    public KeyCode newGameKey;
    public KeyCode plungerKey;

    private bool gameOver = false;
    private bool termOver = false;
    private GameObject ball;
    private GameObject plunger;
    private GameObject drain;

    // At the start of the game..
    void Start()
    {
        // Set the gameobject
        plunger = GameObject.Find("Plunger");
        levelText.text = "Level 1";
        drain = GameObject.Find("Drain");
        ball = GameObject.Find("Ball");
        ball.SetActive(false);
        correctSound = GetComponent<AudioSource>();
        incorrectSound = GetComponent<AudioSource>();
        plungerSound = GetComponent<AudioSource>();
        BGM = GetComponent<AudioSource>();
        BGM.loop = true;
        BGM.Play();
    }

    private void Update()
    {
        if (Input.GetKey(newGameKey) == true) NewGame();
        if (Input.GetKey(plungerKey) == true) Plunger();


        // detect ball going past flippers into "drain"
        if ((ball.activeSelf == true) && (ball.transform.position.z < drain.transform.position.z))
        {

            ball.SetActive(false);
            termOver = true;
            string ballComponent = ball.GetComponent<BallController>().component;
            componentList.Remove(ballComponent);
            if (correctComponent.Contains(ballComponent))
            {
                collectedComponent.Add(ballComponent);
                score.GetComponent<score>().scores = score.GetComponent<score>().scores + 10;
                collectCorrect = true;
                // active the collection display
                GameObject.Find(ballComponent + "collection").GetComponent<CollectedComponentController>().collected = true;
            } else
            {
                score.GetComponent<score>().scores = score.GetComponent<score>().scores - 10;
                collectIncorrect = true;
            }
        }

        if (discard)
        {
            termOver = true;
            discardBall();
        }

        // If a computer built successfully, or component list empty, game end
        if (CompareLists(collectedComponent, correctComponent) || componentList.Count == 0)
        {
            if (gameOver == false)
            {
                gameOver = true;
            }
        }

        if (termOver)
        {
            ball.GetComponent<BallController>().changeComponent = true;
        }
        SetText();
    }

    public bool CompareLists(List<string> list1, List<string> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }

    void FixedUpdate()
    {

    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetText()
    {
        if (termOver)
        {
            if (discardCorrect)
            {
                displayText.text = "You successfully dicard a incorrect component! Score + 10";
                discardCorrect = false;
                correctSound.Play();
            }
            if (discardIncorrect)
            {
                displayText.text = "You dicard a correct component. Score - 10";
                discardIncorrect = false;
                incorrectSound.Play();
            }
            if (collectCorrect)
            {
                displayText.text = "You successfully collect a correct component! Score + 10";
                collectCorrect = false;
                correctSound.Play();
            }
            if (collectIncorrect)
            {
                displayText.text = "You collect a correct component. Score - 10";
                collectIncorrect = false;
                incorrectSound.Play();
            }
        }
        if (gameOver)
        {
            displayText.text = "Level Over";
        }
        else displayText.text = "";
    }

    void NewGame()
    {
        gameOver = false;
        termOver = false;
        ball.SetActive(false);
        currentLevel += 1;
        levelText.text = "Level " + currentLevel;
        // TODO: Implement different level design
        // Change speed? More bumper/render?
        //score.GetComponent<score>().scores = 0;

    }

    void discardBall()
    {
        componentList.Remove(discardComponent);
        // Score --
        if (correctComponent.Contains(discardComponent))
        {
            score.GetComponent<score>().scores = score.GetComponent<score>().scores - 10;
            discardIncorrect = true;
        } else
        {
            score.GetComponent<score>().scores = score.GetComponent<score>().scores + 10;
            discardCorrect = true;
        }
        discard = false;

    }

    void Plunger()
    {
        termOver = false;
        if (ball.activeSelf == false)
        {
            ball.SetActive(true);

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            rb.AddForce(movement * plungerSpeed);

            // set ball position to location of plunger
            ball.transform.position = plunger.transform.position;
            plungerSound.Play();

        }
    }
}