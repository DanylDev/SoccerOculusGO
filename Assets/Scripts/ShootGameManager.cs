using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ShootGameManager : MonoBehaviour
{
    #region Singleton

    public static ShootGameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    [SerializeField] private GameObject playerAndBallEntityPrefab;
    [HideInInspector] public GameObject playerAndBallEntity;

    [SerializeField] private Transform[] playerAndBallPositions;

    private void Start()
    {
        SpawnPlayer(RandomSpawnTransform);
    }

    private void SpawnPlayer(Transform targetTransform)
    {
        if (playerAndBallEntity != null)
        {
            Destroy(playerAndBallEntity);
        }

        /*if (kickCoroutine != null)
        {
            StopCoroutine(kickCoroutine);
            kickCoroutine = null;
        }*/

        playerAndBallEntity = Instantiate(playerAndBallEntityPrefab);

        playerAndBallEntity.transform.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
    }

    #region GameFlowCoroutine

    private Coroutine kickCoroutine;

    public void StartLoseCountdown(float duration, int messageDuration)
    {
        kickCoroutine = StartCoroutine(LoseCountdown(duration, messageDuration));
    }

    private IEnumerator LoseCountdown(float duration, int messageDuration)
    {
        yield return new WaitForSeconds(duration);

        PlayerGUI.Instance.ShowMessage($"You lost! Press 'R' to restart\nReset time: {messageDuration}", new Color32(245, 61, 57, 255));
        
        while (messageDuration > 0)
        {
            messageDuration--;
            yield return new WaitForSeconds(1);
            PlayerGUI.Instance.ShowMessage($"You lost! Press 'R' to restart\nReset time: {messageDuration}", new Color32(245, 61, 57, 255));
        }

        yield return new WaitForSeconds(0.1f);
        Restart(true);
    }

    public void StartWinCountdown(float duration)
    {
        if (kickCoroutine != null)
        {
            StopCoroutine(kickCoroutine);
            kickCoroutine = null;
        }

        StartCoroutine(WinCountdown(3f));
    }

    private IEnumerator WinCountdown(float duration)
    {
        PlayerGUI.Instance.ShowMessage("Great!", new Color32(57, 242, 154, 255));
        yield return new WaitForSeconds(duration);

        Restart(false);
    }

    #endregion

    #region TransformRandomization

    private static int randSeed;
    private static int previousRandSeed;

    private Transform RandomSpawnTransform
    {
        get
        {
            do
            {
                randSeed = Random.Range(0, playerAndBallPositions.Length);
            } while (randSeed == previousRandSeed);

            // We do not want to randomize the same position
            previousRandSeed = randSeed;

            return playerAndBallPositions[randSeed];
        }
    }

    #endregion

    public static void Restart(bool resetScore)
    {
        if (resetScore)
        {
            Score.CurrentScoreJuggle = 0;
            Score.CurrentScoreShoot = 0;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}