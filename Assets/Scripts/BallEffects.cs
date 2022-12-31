using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BallEffects : MonoBehaviour
{
    private BallMovement _ballMovement;
    private void OnBallcollison(Collision2D BallPosition)
    {
        print(transform.position);
    }
    


    private void OnEnable()
    {
        _ballMovement = GetComponent<BallMovement>();
        _ballMovement.OnBallCollison += OnBallcollison;
    }
}



