using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuggleBallBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject playerHeadGO;
    [SerializeField] private GameObject floorGO;
    
    private bool isLost;

    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == playerHeadGO.name && !isLost)
        {
            //+1 to score
            //Score.CurrentScoreJuggle++;
        }
        else if (other.name == floorGO.name)
        {
            //Lose
            PlayerGUI.Instance.ShowMessage("You lost! Press 'R' to Restart", new Color32(245, 57, 57, 255));
            isLost = true;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerHeadGO.name)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(_rb.velocity.x+Random.Range(-0.1f, 0.1f), 5, _rb.velocity.z+Random.Range(-0.1f, 0.1f));
            
            //+1 to score
            if (!isLost)
            {
                Score.CurrentScoreJuggle++;
            }
        }
    } 
}
