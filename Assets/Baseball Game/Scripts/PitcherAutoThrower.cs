using UnityEngine;
using UnityEngine.Assertions;

public class PitcherAutoThrower : MonoBehaviour
{
    public Pitcher pitcher;          // 투구 담당 스크립트
    public string[] ballTypes = { "Fastball", "CurveBall" };

    public float throwInterval = 3f;  // 투구 간격 (초)
    private float timer = 0f;

    private void Start()
    {
        Assert.IsNotNull(pitcher, "Pitcher reference is not assigned!");
    }
    private void Update()
    {
        ThrowDelayTime();
    }

    private void ThrowDelayTime()
    {
        timer += Time.deltaTime;

        if (timer >= throwInterval)
        {
            string randomBallType = ballTypes[Random.Range(0, ballTypes.Length)];
            pitcher.SpawnAndThrow(randomBallType);
            
            timer = 0f;
        }
    }
}