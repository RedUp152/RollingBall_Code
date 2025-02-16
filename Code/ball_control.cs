using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
public class ball_control : MonoBehaviour
{
    public Rigidbody rb;
    public Panels Panels;

    //Objects
    private List<GameObject> objectsWithTag = new List<GameObject>();
    private List<GameObject> objectsWithObstacleTag = new List<GameObject>();


    // Speeds
    public float ZSpeed = 7.7f;
    public float XSpeed = 11.0f;
    public float JumpForce = 7f;

    // Moving
    protected bool Left = false;
    protected bool Right = false;
    protected bool Jump = false;


    private void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;

        objectsWithTag.AddRange(GameObject.FindGameObjectsWithTag("Optimization"));
        foreach (GameObject gameobject in objectsWithTag)
        {
            gameobject.SetActive(false);
        }

        objectsWithObstacleTag.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));
        foreach (GameObject gameobject in objectsWithObstacleTag)
        {
            gameobject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    { 
        if(collision.collider.tag=="Obstacle"|collision.collider.tag=="Optimization"|collision.collider.tag=="Tower")
        {
            Panels.GameOver();
            // Debug.Log(collision.collider); //for technical works
        }
        if (collision.collider.tag == "Win")
        {
            Panels.Win();
        }
    }

    //Optimisation Script
    private void OnTriggerEnter(Collider other)
    {
        //Turning off Objects with "Optimized" tag
        if (other.tag == "optimisation_plane")
        {
            //Turning on Objects with "Optimized" tag
            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(true);
            }

            //Turning off Objects with "Obstacle" tag
            foreach (GameObject obj in objectsWithObstacleTag)
            {
                obj.SetActive(false);
            }
        }
    }

    void Update()
    {
        //Getting Keys
        if (Input.GetKey("left") | Input.GetKey("a"))
        {
            Left = true;
        }
        else
        {
            Left = false;
        }

        if (Input.GetKey("right") | Input.GetKey("d"))
        {
            Right = true;
        }
        else
        {
            Right = false;
        }

        if (Input.GetKey("up") | Input.GetKey("space") | Input.GetKey("w"))
        {
            if (transform.position.y > 1f)
            { 
                Jump = false; 
            }else
            {
                Jump = true;
            }
        }
        
    }
    void FixedUpdate() // Movement Script
    {
        rb.MovePosition(transform.position + Vector3.forward * -ZSpeed * Time.deltaTime);

        if (Left)
        {
            rb.AddForce(XSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Right)
        {
            rb.AddForce(-XSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Jump)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

            Jump = false;
        }

    }
} 