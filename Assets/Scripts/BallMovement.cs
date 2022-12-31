
using System;
using System.Collections;
using System.Collections.Generic;



using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float speedMultiplier = 1.02f;
    public float speed = 10f;
    private int startDir;
    private bool spacekeyState;
    private bool ballState;
    private Rigidbody2D rb;
    
    public delegate void BallCollison(Collision2D BallPosition);
    public event BallCollison OnBallCollison;
    public int Score = 0;
    public Text Scorepoints;
    public BrickSpawner Spawner;



    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        print("Press Space to Start");
    }
   

    private void Update()
    {
        if (myRigidbody2D.velocity == Vector2.zero)
        {
            spacekeyState = Input.GetKeyDown(KeyCode.Space);
            if (spacekeyState == true)
            {
                LaunchBall();
            } 
        }
        {
           Scorepoints.text = Score.ToString();
        }
        if (Spawner.Count == 0)
        {
            Spawner.RefillSpawn();
        }
    }


    


    private void ResetBall()
    {
        myRigidbody2D.velocity = Vector2.zero;
        myRigidbody2D.position = Vector2.zero;
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.CompareTag("Player"))
        {
            myRigidbody2D.velocity *= speedMultiplier;
        }
        if (col.gameObject.CompareTag("Brick"))
        {
            myRigidbody2D.velocity *= speedMultiplier;
            
            Score += 1;
            Spawner.Count -= 1;

        }
        
        
        if (col.gameObject.CompareTag("Finish"))
        {
            ResetBall();
            
        }

        OnBallCollison.Invoke(col);
        
    }
    
    

    private void LaunchBall()
    {
        startDir = Random.Range(0,4);
        switch (startDir)
        {
            case 0:
                myRigidbody2D.velocity = (Vector2.up + Vector2.left).normalized * speed;
                break;
            case 1:
                myRigidbody2D.velocity = (Vector2.down + Vector2.right).normalized * speed;
                break;
            case 2:
                myRigidbody2D.velocity = (Vector2.up + Vector2.right).normalized * speed;
                break;
            case 3:
                myRigidbody2D.velocity = (Vector2.down + Vector2.left).normalized * speed;
                break;
        }
    }

    
}
