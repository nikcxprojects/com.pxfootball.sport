using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] bool IsBot;
    public static Action OnCollided { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("ball"))
        {
            return;
        }

        if(!IsBot)
        {
            OnCollided?.Invoke();
        }
    }

    private void OnDestroy()
    {
        UIManager.OnGameEnd = null;
    }
}
