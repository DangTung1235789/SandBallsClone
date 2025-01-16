using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BallsManager : MonoBehaviour
{
    [SerializeField] AwakeCircleClipper awakeCircleClipper;
    [SerializeField] Ball ballPrefab;
    [SerializeField] List<Transform> listPositionSpawnAtFirstTime;

    private void Awake()
    {
        awakeCircleClipper.SpawnBall += SpawnBallFirstTime;
    }

    private void OnDestroy()
    {
        awakeCircleClipper.SpawnBall -= SpawnBallFirstTime;
    }

    private void SpawnBallFirstTime()
    {
        StartCoroutine(SpawnBallWithDelay());
    }

    private IEnumerator SpawnBallWithDelay()
    {
        for (int i = 0; i < GameManager.Instance.AmountBallForSpawnAtFirstTime; i++)
        {
            int randomIndex = Random.Range(0, listPositionSpawnAtFirstTime.Count);
            Ball ball = Instantiate(ballPrefab, listPositionSpawnAtFirstTime[randomIndex].position, Quaternion.identity);
            ball.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForEndOfFrame();
            ball.GetComponent<Collider2D>().enabled = true;
        }
    }
}
