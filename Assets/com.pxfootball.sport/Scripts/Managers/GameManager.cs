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

    //private void Start()
    //{
    //    Block.OnCollisionEnter += () =>
    //    {
    //        var hit = Instantiate(Resources.Load<AudioSource>("hit"));
    //        hit.mute = GameObject.Find("SFX Source").GetComponent<AudioSource>().mute;

    //        if(SettingsManager.VibraEnable)
    //        {
    //            Handheld.Vibrate();
    //        }
    //    };
    //}

    public void DestroyOld()
    {
        Destroy(LevelRef);
        Destroy(BallRef);
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