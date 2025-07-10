using UnityEngine;
using UnityEngine.UI;

// UIManager.cs
public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<UIManager>();
            }
            return m_instance;
        }
    }
    private static UIManager m_instance;

    public Image[] StrikeImages;
    public Image[] BallImages;
    public Image[] OutImages;

    // 스트라이크는 노란색, 볼은 초록색, 아웃은 빨간색
    private readonly Color strikeActiveColor = Color.yellow;
    private readonly Color ballActiveColor = Color.green;
    private readonly Color outActiveColor = Color.red;
    private readonly Color inactiveColor = new Color(1f, 1f, 1f, 0.3f);

    public Text ScoreText;
    
    public void UpdateStrike(int count)
    {
        UpdateImagesBrightness(StrikeImages, count, strikeActiveColor);
    }

    public void UpdateBall(int count)
    {
        UpdateImagesBrightness(BallImages, count, ballActiveColor);
    }

    public void UpdateOut(int count)
    {
        UpdateImagesBrightness(OutImages, count, outActiveColor);
    }

    private void UpdateImagesBrightness(Image[] images, int activeCount, Color activeColor)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i < activeCount)
                images[i].color = new Color(activeColor.r, activeColor.g, activeColor.b, 1f); // 활성 시 지정색 + 완전불투명
            else
                images[i].color = inactiveColor; // 비활성은 희미하게 표시
        }
    }

    public void ResetStrikeBall()
    {
        UpdateStrike(0);
        UpdateBall(0);
    }
}