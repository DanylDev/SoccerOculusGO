using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootBallBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject goalGateOneColliderGO;
    [SerializeField] private GameObject goalGateTwoColliderGO;

    [SerializeField] private GameObject ballCanvas;

    private float forceX = 0f;
    private float forceY = 5f;
    private float forceZ = 10f;

    private Rigidbody ballRB;

    private bool isLost;

    private void Awake()
    {
        ballRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerBehaviour.Instance.canShoot)
        {
            ballRB.AddForce(PlayerBehaviour.Instance.gameObject.GetComponent<Rigidbody>().velocity +
                            PlayerBehaviour.Instance.gameObject.transform.forward * 1000f);

            DetachFromPlayer();
            EnableBallCanvas(false);
            PlayerBehaviour.Instance.AfterShoot();
            
            ShootGameManager.Instance.StartLoseCountdown(5f, 5);
        }
    }

    private void DetachFromPlayer()
    {
        gameObject.transform.parent.transform.parent = ShootGameManager.Instance.playerAndBallEntity.transform;
    }

    private void EnableBallCanvas(bool value)
    {
        ballCanvas.SetActive(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == goalGateOneColliderGO.name || other.name == goalGateTwoColliderGO.name)
        {
            Score.CurrentScoreShoot++;

            ShootGameManager.Instance.StartWinCountdown(3f);
        }
    }
}