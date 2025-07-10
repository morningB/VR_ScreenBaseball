using UnityEngine;

public class HitZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Debug.Log("히트다 히트");
            //주루 하나씩 가기
            ScoreManager.instance.PlayerAdvance();
        }
    }
}
