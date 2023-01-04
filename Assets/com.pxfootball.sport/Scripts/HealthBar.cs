using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int Count { get; set; }

    private void Awake()
    {
        Count = transform.childCount;
        Goal.OnCollided += () =>
        {
            Count--;
            UIManager.ShowPopup();

            if(Count <= 0)
            {
                GameManager.Instance.EndGame();
                return;
            }

            transform.GetChild(Count).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        };
    }

    private void OnDestroy()
    {
        Goal.OnCollided = null;
    }

    public void ResetMe()
    {
        Count = transform.childCount;
        for(int i = transform.childCount - 1; i > 0; i--)
        {
            transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }
    }
}
