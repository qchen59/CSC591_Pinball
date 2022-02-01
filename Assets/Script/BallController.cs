using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{

    public float speed;
    public GameObject pg;
    // Rigidbody component on the ball
    private Rigidbody rb;
    GameObject ball;
    // Current component name
    public string component = "";
    // List of component name
    private List<string> componentList = new List<string>() { "Monitor", "Mouse", "Keyboard" };
    MeshFilter ballMesh;
    public bool changeComponent = false;
    public GameObject score;
    public AudioSource bonusSound;
    public AudioSource discardSound;
    public int scoreIncrement = 10;
    Mesh Monitor;
    Mesh Keyboard;
    Mesh Mouse;
    GameObject mt;
    GameObject kb;
    GameObject ms;
    //Material[] mtm;
    //Material[] kbm;
    //Material[] mm;
    //MeshRenderer ballMeshRender;



    void Start()
    {
        ball = GameObject.Find("Ball");
        mt = GameObject.Find("Monitor");
        kb = GameObject.Find("Keyboard");
        ms = GameObject.Find("Mouse");
        mt.SetActive(false);
        ms.SetActive(false);
        kb.SetActive(false);
        Monitor = mt.GetComponent<MeshFilter>().mesh;
        Keyboard = kb.GetComponent<MeshFilter>().mesh;
        Mouse = ms.GetComponent<MeshFilter>().mesh;
        //mtm = mt.GetComponent<MeshRenderer>().materials;
        //kbm = kb.GetComponent<MeshRenderer>().materials;
        //mm = ms.GetComponent<MeshRenderer>().materials;
        // Assign the Rigidbody component
        rb = GetComponent<Rigidbody>();
        assignComponent();




    }

    void assignComponent()
    {
        // Random assign the component to the ball
        List<string> cl = pg.GetComponent<PinballGame>().componentList;
        System.Random rand = new System.Random();
        int componentIdx = rand.Next(0, cl.Count);
        Debug.Log(componentIdx);
        component = cl[componentIdx];
        assignMesh();
    }

    void assignMesh()
    {
        ballMesh = ball.GetComponent<MeshFilter>();
        //ballMeshRender = ball.GetComponent<MeshRenderer>();


        if (component == "Monitor")
        {
            ballMesh.mesh = Monitor;
            //ballMeshRender.materials = mtm;
        }
        if (component == "Keyboard")
        {
            Debug.Log(component);
            ballMesh.mesh = Keyboard;
            //ballMeshRender.materials = kbm;
        }
        if (component == "Mouse")
        {
            Debug.Log(component);
            ballMesh.mesh = Mouse;
            //ballMeshRender.materials = mm;
        }

    }

    private void Update()
    {
        // Change the component when the ball discard or collected.
        if (changeComponent)
        {
            assignComponent();
            changeComponent = false;
        }
    }

    // If on trigger enter the bonus object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            // Bonus dispear
            other.gameObject.SetActive(false);
            bonusSound.Play();
            pg.GetComponent<PinballGame>().bonus = true;
            //Add bonus score when hit the bonus
            score.GetComponent<score>().scores = score.GetComponent<score>().scores + scoreIncrement;
        }

        if (other.gameObject.tag == "Discard")
        {
            
            discardSound.Play();
            // Discard the ball
            this.gameObject.SetActive(false);
            pg.GetComponent<PinballGame>().discard = true;
            pg.GetComponent<PinballGame>().discardComponent = component;
        }
    }



}