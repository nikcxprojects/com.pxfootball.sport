using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("ball"))
        {
            return;
        }

        GameManager.Instance.RespawnBall();
    }

    private void OnDestroy()
    {
        UIManager.OnGameEnd = null;
    }
}
