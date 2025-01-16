using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStorage : MonoBehaviour
{
    [SerializeField] int maxBallInStorage = 7;
    int currentAmountBallInStorage = 0;

    private Queue<Ball> ballQueue = new Queue<Ball>();

    public static Action OnBallEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>(); 

        if (ball != null)
        {
            currentAmountBallInStorage++;
            if(currentAmountBallInStorage >= maxBallInStorage)
            {
                Ball ballDestroy = ballQueue.Dequeue();
                Destroy(ballDestroy.gameObject); 
            }
            else
            {
                ballQueue.Enqueue(ball);
            }

            OnBallEnter?.Invoke();
        }
    }
}
