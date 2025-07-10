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
         ball.direction = Vector3.zero;
         // 배트 스윙 속도에 따라 반사력 보강
         Vector3 reflectedDir = Vector3.Reflect(ball.direction, transform.forward);
         
         ballRb.linearVelocity = reflectedDir.normalized * ballRb.linearVelocity.magnitude * swingSpeed;
         
         // 순간 힘도 추가해 튕김 강화
         ballRb.AddForce(reflectedDir.normalized * swingSpeed * 10f, ForceMode.Impulse);
      }
      //Debug.Log("히트");
   }
}
