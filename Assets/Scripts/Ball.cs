using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    BallsManager ballsManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ground ground = collision.gameObject.GetComponent<Ground>();
        if(ground != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetBallsManager(BallsManager ballsManager)
    {
        this.ballsManager = ballsManager;
    }

    private void OnDestroy()
    {
        ballsManager.DeleteBall(this);
    }
}
