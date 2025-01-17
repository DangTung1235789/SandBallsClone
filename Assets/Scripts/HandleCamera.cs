using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandleCamera : MonoBehaviour
{
    [SerializeField] BallsManager ballsManager; 
    [SerializeField] float smoothSpeed = 0.125f; 
    [SerializeField] public float OffsetY = 5f;
    [SerializeField] public bool FollowBall = false; 
    
    private void LateUpdate()
    {
        if (ballsManager == null || ballsManager.GetBalls() == null || ballsManager.GetBalls().Count == 0)
            return;

        if (FollowBall == false) return;

        Ball lowestBall = ballsManager.GetLowestBall();

        if (lowestBall != null)
        {
            float targetY = lowestBall.transform.position.y + OffsetY;

            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(currentPosition.x, targetY, currentPosition.z);

            transform.position = Vector3.Lerp(currentPosition, targetPosition, smoothSpeed);
        }
    }
}
