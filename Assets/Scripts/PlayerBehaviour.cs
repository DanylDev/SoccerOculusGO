using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject ballTriggerGO;
    [SerializeField] private GameObject ballGO;

    #region Singleton

    public static PlayerBehaviour Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public bool canShoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ballTriggerGO.name)
        {
            PlayerGUI.Instance.ShowMessage("Press 'F' to shoot the ball", new Color32(57, 149, 245, 255));
            canShoot = true;
        }
    }

    public void AfterShoot()
    {
        PlayerGUI.Instance.HideMessage();
        canShoot = false;
        RemoveBallTrigger();
    }
    
    private void RemoveBallTrigger()
    {
        Destroy(ballTriggerGO);
    }
    
    private void Update()
    {
        if (ballTriggerGO != null)
        {
            ballTriggerGO.transform.position = ballGO.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ShootGameManager.Restart(true);
        }
    }
}