using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointDowngradeHeight : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCountRemainAmountBallForWin;
    [SerializeField] Transform targetTransform;
    private int downgradeStep = 0;

    private void OnEnable()
    {
        textCountRemainAmountBallForWin.text = Convert.ToString(GameManager.Instance.AmountBallForWin);
        CarStorage.OnBallEnter += HandleBallEnter;
    }

    private void OnDisable()
    {
        CarStorage.OnBallEnter -= HandleBallEnter;
    }

    private void HandleBallEnter()
    {
        if (downgradeStep < GameManager.Instance.AmountBallForWin)
        {
            downgradeStep++;
            float newY = Mathf.Lerp(transform.position.y, targetTransform.position.y, downgradeStep / (float)GameManager.Instance.AmountBallForWin);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);          
        }
        textCountRemainAmountBallForWin.text = Convert.ToString(GameManager.Instance.AmountBallForWin - downgradeStep);    
    }
}
