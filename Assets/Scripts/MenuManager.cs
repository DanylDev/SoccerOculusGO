using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreenGO;
    [SerializeField] private GameObject startScreenGO;
    [SerializeField] private GameObject hsScreenGO;
    
    private void Start()
    {
        ActivateMainScreen();
    }

    #region HighScores
    
    [SerializeField] private TextMeshProUGUI textJuggleHS;
    [SerializeField] private TextMeshProUGUI textShootHS;
    
    private void SetHighScores()
    {
        textJuggleHS.text = Score.HighScoreJuggle.ToString();
        textShootHS.text = Score.HighScoreShoot.ToString();
    }

    #endregion

    #region MenuFlow

    public void GoToStartScreen()
    {
        mainScreenGO.SetActive(false);
        hsScreenGO.SetActive(false);
        
        startScreenGO.SetActive(true);
    }

    #region StartScreenFlow

    public void GoToJuggleScene()
    {
        SceneManager.LoadScene("1_Stadium_Juggle");
    }
    
    public void GoToShootScene()
    {
        SceneManager.LoadScene("2_Stadium_Shoot");
    }

    #endregion
    
    public void GoToHSScreen()
    {
        // Fill numbers
        SetHighScores();
        
        // Enable/Disable menus
        startScreenGO.SetActive(false);
        mainScreenGO.SetActive(false);
        
        hsScreenGO.SetActive(true);
    }

    public void Exit()
    {
        // ToDO: Exit Logic
    }
    
    public void ActivateMainScreen()
    {
        hsScreenGO.SetActive(false);
        startScreenGO.SetActive(false);
        
        mainScreenGO.SetActive(true);
    }

    #endregion
    
}