using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuggleBallBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject playerHeadGO;
    [SerializeField] private GameObject floorGO;
    
    private bool isLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == playerHeadGO.name && !isLost)
        {
            //+1 to score
            Score.CurrentScoreJuggle++;
            PlayerGUI.Instance.UpdateScoreGUI();
        }
        else if (other.name == floorGO.name)
        {
            //Lose
            PlayerGUI.Instance.ShowMessage("You lost! Press 'R' to Restart", new Color32(245, 57, 57, 255));
            isLost = true;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Score.CurrentScoreJuggle = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
