using UnityEngine;

public class HomerunZone : MonoBehaviour
{
    public void onTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Debug.Log("HomeRun!!!!");
            // 주루에 있는 사람 + 1만큼 점수 추가
            ScoreManager.instance.AddScore(ScoreManager.instance.runnersOnBase);
        }
    }
}
