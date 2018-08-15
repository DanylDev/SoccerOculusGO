using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootBallBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject goalGateOneColliderGO;
    [SerializeField] private GameObject goalGateTwoColliderGO;

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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == goalGateOneColliderGO.name || other.name == goalGateTwoColliderGO.name)
        {
            Score.CurrentScoreShoot++;
        }
    }
}