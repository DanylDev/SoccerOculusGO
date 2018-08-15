using UnityEngine;

public class JugglePlayerGUI : PlayerGUI
{
    public override void UpdateScoreGUI()
    {
        base.UpdateScoreGUI();
        
        scoreText.text = Score.CurrentScoreJuggle.ToString();
        highScoreText.text = Score.HighScoreJuggle.ToString();
    }
}