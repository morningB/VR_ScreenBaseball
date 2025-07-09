using UnityEngine;

public class Fastball : Ball
{
    protected override void Move()
    {
        transform.position += direction * ballData.speed * Time.deltaTime;
    }
}

