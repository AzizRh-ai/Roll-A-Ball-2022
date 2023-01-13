using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        Player.OnScoreUpdate += UpScore;
    }

    private void OnDisable()
    {
        Player.OnScoreUpdate -= UpScore;
    }
    private void UpScore(int score)
    {
        scoreText.text = "Score :" + score.ToString();
    }
}
