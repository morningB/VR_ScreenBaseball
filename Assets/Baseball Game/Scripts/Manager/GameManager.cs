using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<GameManager>();
            }
            return m_instance;
        }
    }
    private static GameManager m_instance;

    public UIManager uiManager;

    private int strikeCount;
    private int ballCount;
    private int outCount;
    private int chances;

    void Start()
    {
        strikeCount = 0;
        ballCount = 0;
        outCount = 0;
        chances = 1;

        // 초기 UI 상태 초기화
        uiManager.UpdateStrike(strikeCount);
        uiManager.UpdateBall(ballCount);
        uiManager.UpdateOut(outCount);
    }

    public void AddStrike()
    {
        strikeCount++;
        uiManager.UpdateStrike(strikeCount);

        if (strikeCount >= 3)
        {
            outCount++;
            strikeCount = 0;
            ballCount = 0;
            chances--;
            uiManager.UpdateOut(outCount);
            uiManager.ResetStrikeBall();

            if (chances < 0)
            {
                Debug.Log("게임 오버");
                // 게임 오버 처리 로직 추가 가능
            }
        }
    }

    public void AddBall()
    {
        ballCount++;
        uiManager.UpdateBall(ballCount);

        if (ballCount >= 4)
        {
            chances++;
            ballCount = 0;
            uiManager.ResetStrikeBall();
            // 기회 추가 처리 가능
        }
    }
}