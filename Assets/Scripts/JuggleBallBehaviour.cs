using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuggleBallBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject playerHeadGO;
    [SerializeField] private GameObject floorGO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == playerHeadGO.name && !isLost)
        {
            //+1 to score
            Score.CurrentScoreJuggle++;
            ScoreGUI.Instance.UpdateJuggleScoreGUI();
        }
        else if (other.name == floorGO.name)
        {
            //Lose
            lostRestartText.gameObject.SetActive(true);
            isLost = true;
        }
    }

    private bool isLost;
    [SerializeField] private TextMeshProUGUI lostRestartText;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Score.CurrentScoreJuggle = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
