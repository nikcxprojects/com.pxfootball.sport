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

            for(int i = 0; i < transform.childCount; i++)
            {
                int index = transform.GetChild(i).GetSiblingIndex();
                float alpha = index > Count ? 1 : 0;

                transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, alpha);
            }
        };
    }

    private void OnDestroy()
    {
        Goal.OnCollided = null;
    }
}
