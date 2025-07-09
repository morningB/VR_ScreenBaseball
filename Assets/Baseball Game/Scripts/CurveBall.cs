using UnityEngine;

public class Curveball : Ball
{
    protected override void Move()
    {
        Vector3 curvedDir = direction + ballData.curveDirection * Mathf.Sin(Time.time * ballData.speed) * ballData.curveStrength;
        curvedDir.Normalize();
        transform.position += curvedDir * ballData.speed * Time.deltaTime;
    }
}