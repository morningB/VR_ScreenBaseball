using UnityEngine;

public class BallZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Debug.Log("ball zone");
            GameManager.instance.AddBall();    // 볼 카운트 증가 요청
            ball.BallDestroy();
        }
    }
}
