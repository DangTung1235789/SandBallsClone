using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 
public class BallsManager : MonoBehaviour
{
    [SerializeField] AwakeCircleClipper awakeCircleClipper;
    [SerializeField] Ball ballPrefab;
    [SerializeField] List<Transform> listPositionSpawnAtFirstTime;
    List<Ball> balls = new List<Ball>();

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
            ball.SetBallsManager(this);
            balls.Add(ball);
            ball.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForEndOfFrame();
            ball.GetComponent<Collider2D>().enabled = true;
        }
    }

    public Vector3 GetPositionSpawnAtFirstTime()
    {
        return listPositionSpawnAtFirstTime[1].position;
    }

    public List<Ball> GetBalls()
    {
        return balls;
    }

    public Ball GetLowestBall()
    {
        return GetBalls().Where(ball => ball != null).OrderBy(ball => ball.transform.position.y).FirstOrDefault();

    }

    public void DeleteBall(Ball ball)
    {
        balls.Remove(ball);
    }
}
