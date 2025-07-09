using UnityEngine;

[CreateAssetMenu(fileName = "NewBallData", menuName = "Baseball/BallData")]
public class BallData : ScriptableObject
{
    public float speed = 30f;
    public float curveStrength = 0f;
    public Vector3 curveDirection = Vector3.zero;
}
