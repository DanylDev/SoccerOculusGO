using UnityEngine;

public class ShootPlayerGUI : PlayerGUI
{
    public override void UpdateScoreGUI()
    {
        base.UpdateScoreGUI();
        
        scoreText.text = Score.CurrentScoreShoot.ToString();
        highScoreText.text = Score.HighScoreShoot.ToString();
    }
}