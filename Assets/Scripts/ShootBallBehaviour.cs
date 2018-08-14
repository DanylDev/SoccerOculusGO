using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootBallBehaviour : MonoBehaviour
{
    private float force = 5f;
    private Rigidbody _rigidbody;

    private bool isLost;
    [SerializeField] private TextMeshProUGUI lostRestartText;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Score.CurrentScoreJuggle = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _rigidbody.AddForce(0, force, force, ForceMode.Impulse);
        }
    }
}