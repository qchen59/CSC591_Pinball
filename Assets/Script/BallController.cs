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
    private List<string> componentList = new List<string>() { "correct component 1", "correct component 2", "correct component 3", "incorrect component 1", "incorrect component 2", "incorrect component 3" };
    MeshFilter ballMesh;
    public bool changeComponent = false;

    void Start()
    {
        ball = GameObject.Find("Ball");
        // Assign the Rigidbody component
        rb = GetComponent<Rigidbody>();
        assignComponent();



    }

    void assignComponent()
    {
        // Random assign the component to the ball
        List<string> cl = pg.GetComponent<PinballGame>().componentList;
        System.Random rand = new System.Random();
        int componentIdx = rand.Next(1, cl.Count + 1);
        component = componentList[componentIdx];
        assignMesh();
    }

    void assignMesh()
    {
        ballMesh = ball.GetComponent<MeshFilter>();
        // Assign the specific mesh to the ball
        ballMesh.sharedMesh = Resources.Load<Mesh>(component + "Mesh");
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

}