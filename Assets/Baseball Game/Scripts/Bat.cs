using UnityEngine;

public class Bat : MonoBehaviour, IHittable
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnHit(Vector3 incomingDirection, Ball ball)
    {
        float swingSpeed = rb != null ? rb.linearVelocity.magnitude : 0f;

        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.useGravity = true;
            // 반사 방향 계산 (배트 전방 대신 충돌 노멀이나 공-배트 방향 사용 권장)
            Vector3 normal = (ball.transform.position - transform.position).normalized;
            Vector3 reflectedDir = Vector3.Reflect(incomingDirection.normalized, normal);

            // 공 방향 업데이트
            ball.direction = reflectedDir.normalized;

            // 반사 속도 적용, 스윙 속도 곱함
            ballRb.linearVelocity = reflectedDir.normalized * ballRb.linearVelocity.magnitude * swingSpeed;

            // 순간 힘 추가로 튕김 강화
            ballRb.AddForce(reflectedDir.normalized * swingSpeed * 10f, ForceMode.Impulse);
        }
        //Debug.Log("Hit registered");
    }
}