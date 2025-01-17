using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStorage : MonoBehaviour
{
    [SerializeField] ButtonNextUI btnNextLevel;
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
                if (ballQueue.Count == 0) return;

                Ball ballDestroy = ballQueue.Dequeue();
                Destroy(ballDestroy.gameObject); 
            }
            else
            {
                ballQueue.Enqueue(ball);
            }

            CheckWin();
            OnBallEnter?.Invoke();
        }
    }

    private void CheckWin()
    {
        if(currentAmountBallInStorage == GameManager.Instance.AmountBallForWin)
        {
            btnNextLevel.gameObject.SetActive(true);
        }
    }
}
