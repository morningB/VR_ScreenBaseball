using UnityEngine;

public class Pitcher : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform batterTransform;

    [System.Serializable]
    public struct BallInfo
    {
        public string ballType;
        public GameObject prefab;
        public BallData data;
    }

    public BallInfo[] ballInfos;

    public void SpawnAndThrow(string ballType)
    {
        BallInfo? selected = null;
        foreach (var info in ballInfos)
        {
            if (info.ballType == ballType)
            {
                selected = info;
                break;
            }
        }
        if (selected == null) return;

        var ballGO = Instantiate(selected.Value.prefab, spawnPoint.position, Quaternion.identity);
        var ballScript = ballGO.GetComponent<Ball>();

        if (ballScript != null)
        {
            ballScript.Initialize(selected.Value.data);
            Vector3 throwDir = (batterTransform.position - spawnPoint.position).normalized;
            ballScript.Throw(throwDir);
        }
    }
}