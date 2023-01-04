using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject LevelRef { get; set; }
    public GameObject BallRef { get; set; }

    private GameObject LevelPrefab { get; set; }
    private GameObject BallPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        LevelPrefab = Resources.Load<GameObject>("level");
        BallPrefab = Resources.Load<GameObject>("ball");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    public void DestroyOld()
    {
        Destroy(LevelRef);
        Destroy(BallRef);
    }

    public void RespawnBall()
    {
        Destroy(BallRef);
        BallRef = Instantiate(BallPrefab, EnvironmentRef);
    }

    public void StartGame()
    {
        DestroyOld();

        LevelRef = Instantiate(LevelPrefab, EnvironmentRef);
        BallRef = Instantiate(BallPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        DestroyOld();
        uiManager.OpenWindow(5);
    }
}