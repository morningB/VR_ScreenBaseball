using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<ScoreManager>();
            }
            return m_instance;
        }
    }
    private static ScoreManager m_instance;
    
    public int runnersOnBase {get; set;}
    public int score {get; set;}

    void Awake()
    {
        runnersOnBase = 0;
        score = 0;
    }

    public void PlayerAdvance()
    {
        runnersOnBase++;
        Debug.Log("주루수 1명 진출, 현재 주자 수: " + runnersOnBase);
        // 주자 위치 갱신, UI 업데이트 등 처리
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("점수 추가: " + points + ", 총점: " + score);
        // 점수 UI 갱신, 사운드 재생 등 처리
    }
}
