using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class PlayerGUI : MonoBehaviour
{
    [SerializeField] protected Text scoreText;
    [SerializeField] protected Text highScoreText;
    
    [SerializeField] private TextMeshProUGUI messageText;
    
    #region Singleton

    public static PlayerGUI Instance;

    private void Awake()
    {
        Instance = this;
        UpdateScoreGUI();
        HideMessage();
    }

    #endregion
    
    public virtual void UpdateScoreGUI()
    {
        // This meant to be overridden
    }

    public void ShowMessage(string message, Color32 messageColor)
    {
        messageText.color = messageColor;
        messageText.text = message;
        messageText.gameObject.SetActive(true); 
    }

    public void HideMessage()
    {
        messageText.gameObject.SetActive(false);
        messageText.color = Color.white;
        messageText.text = string.Empty;
    }
}