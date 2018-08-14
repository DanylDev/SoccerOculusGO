using UnityEngine;

public static class Score 
{
    #region HighScoreJuggle

    private static string highScoreJuggleKey = "HighScoreJuggle";

    public static int HighScoreJuggle
    {
        get { return RegGetCurrentHighScoreJuggle(); }
        private set { RegSetHighScoreJuggle(value); }
    }

    private static int RegGetCurrentHighScoreJuggle()
    {
        return PlayerPrefs.GetInt(highScoreJuggleKey);
    }

    private static void RegSetHighScoreJuggle(int value)
    {
        PlayerPrefs.SetInt(highScoreJuggleKey, value);
    }

    public static void ResetHighScoreJuggle()
    {
        HighScoreJuggle = 0;
    }
    
    #endregion
    
    #region HighScoreShoot

    private static string highScoreShootKey = "HighScoreShoot";

    public static int HighScoreShoot
    {
        get { return RegGetCurrentHighScoreShoot(); }
        private set { RegSetHighScoreShoot(value); }
    }

    private static int RegGetCurrentHighScoreShoot()
    {
        return PlayerPrefs.GetInt(highScoreShootKey);
    }

    private static void RegSetHighScoreShoot(int value)
    {
        PlayerPrefs.SetInt(highScoreShootKey, value);
    }

    public static void ResetHighScoreShoot()
    {
        HighScoreShoot = 0;
    }
    
    #endregion

    #region CurrentScoreJuggle

    private static int currentScoreJuggle;

    public static int CurrentScoreJuggle
    {
        get { return currentScoreJuggle; }
        set
        {
            currentScoreJuggle = value;

            if (currentScoreJuggle > HighScoreJuggle)
            {
                HighScoreJuggle = currentScoreJuggle;
            }
        }
    }

    #endregion
    
    #region CurrentScoreShoot

    private static int currentScoreShoot;

    public static int CurrentScoreShoot
    {
        get { return currentScoreShoot; }
        set
        {
            currentScoreShoot = value;

            if (currentScoreShoot > HighScoreShoot)
            {
                HighScoreShoot = currentScoreShoot;
            }
        }
    }

    #endregion
}