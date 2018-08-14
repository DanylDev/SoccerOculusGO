using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    #region Singleton

    public static ScoreGUI Instance;

    private void Awake()
    {
        Instance = this;

        // ToDO: Bad, but working
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            UpdateJuggleScoreGUI();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            UpdateShootScoreGUI();
        }
    }

    #endregion

    public void UpdateJuggleScoreGUI()
    {
        scoreText.text = Score.CurrentScoreJuggle.ToString();
        highScoreText.text = Score.HighScoreJuggle.ToString();
    }
    
    public void UpdateShootScoreGUI()
    {
        scoreText.text = Score.CurrentScoreShoot.ToString();
        highScoreText.text = Score.HighScoreShoot.ToString();
    }
}