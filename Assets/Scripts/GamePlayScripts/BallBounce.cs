using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    public BallMovement ballMovement;
    public ScoreManager scoreManager;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.x;

        float positionY;
        if(collision.gameObject.name == "Player 1")
        {
            positionY = 1;
        }
        else
        {
            positionY = -1;
        }

        float positinX = (ballPosition.x - racketPosition.x) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector3(positinX, positionY));


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "Top Border")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if(collision.gameObject.name == "Bottom Border")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());

        }
    }

}
