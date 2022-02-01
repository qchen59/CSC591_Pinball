using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;
using System.Collections.Generic;

public class PinballGame : MonoBehaviour
{

    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI displayText;
    //public Text levelText;
    public bool discard = false;
    public string discardComponent;
    //public bool discardCorrect = false;
    //public bool discardIncorrect = false;
    //public bool collectCorrect = false;
    //public bool collectIncorrect = false;
    public bool bonus = false;
    public AudioSource correctSound;
    public AudioSource incorrectSound;
    public AudioSource BGM;
    public AudioSource plungerSound;

    public float plungerSpeed = 300;
    public GameObject score;

    public int currentLevel = 1;


    public List<string> collectedComponent = new List<string>();
    public List<string> componentList = new List<string>() { "Monitor", "Mouse", "Keyboard" };
    public List<string> componentNames = new List<string>() { "Monitor", "Mouse", "Keyboard" };
    GameObject Monitor;
    GameObject Mouse;
    GameObject Keyboard;

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
        Monitor = GameObject.Find("Monitor");
        Mouse = GameObject.Find("Mouse");
        Keyboard = GameObject.Find("Keyboard");
        //levelText.text = "Level 1";
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


        //detect ball going past flippers into "drain"
        if ((ball.activeSelf == true) && (ball.transform.position.z < drain.transform.position.z))
        {

            ball.SetActive(false);
            termOver = true;
            string ballComponent = ball.GetComponent<BallController>().component;
            componentList.Remove(ballComponent);
            //if (correctComponent.Contains(ballComponent))
            //{
            //    collectedComponent.Add(ballComponent);
            //    score.GetComponent<score>().scores = score.GetComponent<score>().scores + 10;
            //    collectCorrect = true;
            //    // active the collection display
            //    GameObject.Find(ballComponent + "collection").GetComponent<CollectedComponentController>().collected = true;
            //}
            //else
            //{
            //    score.GetComponent<score>().scores = score.GetComponent<score>().scores - 10;
            //    collectIncorrect = true;
            //}
        }

        if (discard)
        {
            discardBall();
        }

        // If a computer built successfully, or component list empty, game end
        //CompareLists(collectedComponent, correctComponent) ||
        if ( componentList.Count == 0)
        {
            if (gameOver == false)
            {
                gameOver = true;
            }
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
        //if (termOver)
        //{
        //    if (discardCorrect)
        //    {
        //        displayText.text = "You successfully dicard a incorrect component! Score + 10";
        //        discardCorrect = false;
        //        correctSound.Play();
        //    }
        //    if (discardIncorrect)
        //    {
        //        displayText.text = "You dicard a correct component. Score - 10";
        //        discardIncorrect = false;
        //        incorrectSound.Play();
        //    }
        //    if (collectCorrect)
        //    {
        //        displayText.text = "You successfully collect a correct component! Score + 10";
        //        collectCorrect = false;
        //        correctSound.Play();
        //    }
        //    if (collectIncorrect)
        //    {
        //        displayText.text = "You collect a correct component. Score - 10";
        //        collectIncorrect = false;
        //        incorrectSound.Play();
        //    }
        //}
        if (bonus)
        {
            bonus = false;
            displayText.text = "You collect a new headset! Score + 10 ";
        }
        if (termOver)
        {
            bonus = false;
            displayText.text = "Congradulation, you collecct the " + ball.GetComponent<BallController>().component + "\n Press P to get a new component. ";
            if (ball.GetComponent<BallController>().component == "Monitor") Monitor.SetActive(true);
            if (ball.GetComponent<BallController>().component == "Mouse") Mouse.SetActive(true);
            if (ball.GetComponent<BallController>().component == "Keyboard") Keyboard.SetActive(true);

        }
        if (discard)
        {
            discard = false;
            displayText.text = "Oops! Alien took your " + discardComponent;
        }
        if (gameOver)
        {
            displayText.text = "You collected all components!";
        }
    }

    void NewGame()
    {
        gameOver = false;
        termOver = false;
        ball.SetActive(false);
        currentLevel += 1;
        //levelText.text = "Level " + currentLevel;
        // TODO: Implement different level design
        // Change speed? More bumper/render?
        //score.GetComponent<score>().scores = 0;

    }

    void discardBall()
    {
        componentList.Remove(discardComponent);
        // Score --
        score.GetComponent<score>().scores = score.GetComponent<score>().scores - 10;
        //if (correctComponent.Contains(discardComponent))
        //{
        //    score.GetComponent<score>().scores = score.GetComponent<score>().scores - 10;
        //    discardIncorrect = true;
        //} else
        //{
        //    score.GetComponent<score>().scores = score.GetComponent<score>().scores + 10;
        //    discardCorrect = true;
        //}

    }

    void Plunger()
    {
        if (termOver)
        {
            ball.GetComponent<BallController>().changeComponent = true;
        }

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