using UnityEngine;

public class StrikeZone : MonoBehaviour
{
    
    public delegate void StrikeEvent(Ball ball);
    public event StrikeEvent OnStrike;
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Debug.Log("스트라이크 존 진입 감지");
            GameManager.instance.AddStrike();
            // 필요하면 공 파괴 또는 상태 변경 처리
            ball.BallDestroy();
            
        }
    }
}
