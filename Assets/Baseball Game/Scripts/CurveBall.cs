using UnityEngine;

public class Curveball : Ball
{
    private float gravity = 9.81f;
    private Vector3 velocity;
    private Vector3 curveDir = Vector3.left;
    private float curveStrength = 0.3f;

    public override void Throw(Vector3 throwDirection)
    {
        velocity = throwDirection.normalized * ballData.speed;
    }

    protected override void Move()
    {
        // 중력 가속도 적용 (Y축 방향 아래로)
        velocity += Vector3.down * gravity * Time.deltaTime;

        // 커브 회전 가속도 (좌측으로 휘는 효과)
        Vector3 curvedVelocity = velocity + curveDir * curveStrength;

        // 위치 업데이트
        transform.position += curvedVelocity * Time.deltaTime;

        // 방향 업데이트
        direction = curvedVelocity.normalized;
    }

}