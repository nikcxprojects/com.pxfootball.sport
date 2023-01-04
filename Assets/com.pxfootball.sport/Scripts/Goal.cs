using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] bool IsBot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("ball"))
        {
            return;
        }

        //UIManager.CheckResult(true);
    }

    private void OnDestroy()
    {
        UIManager.OnGameEnd = null;
    }
}
