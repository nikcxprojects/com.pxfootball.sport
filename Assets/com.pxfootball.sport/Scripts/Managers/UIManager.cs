using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score ;

    private GameObject _last = null;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject options;
    [SerializeField] GameObject top;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject result;

    [Space(10)]
    [SerializeField] Text scoreText;

    public static Action OnGameEnd { get; set; }

    private void Awake()
    {
        OpenWindow(0);
    }

    public static void ShowPopup()
    {
        Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("main canvas").transform);
        OnGameEnd?.Invoke();
    }

    public void OpenMenu()
    {
        OpenWindow(0);
        game.SetActive(false);

        GameManager.Instance.DestroyOld();
    }

    public void StartGameOnClick()
    {
        score = 0;

        scoreText.text = $"{score}";
        GameManager.Instance.StartGame();

        OpenWindow(3);
    }

    public void OpenWindow(int windowIndex)
    {
        if(_last && windowIndex != 4)
        {
            _last.SetActive(false);
        }

        switch(windowIndex)
        {
            case 0: _last = menu; break;
            case 1: _last = options; break;
            case 2: _last = top; break;
            case 3: _last = game; break;
            case 4: _last = pause;break;
            case 5: _last = result; break;
        }

        _last.SetActive(true);
        Time.timeScale = windowIndex == 4 ? 0 : 1;
    }
}