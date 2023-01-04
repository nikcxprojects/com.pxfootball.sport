using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int count;

    private void UpdateScore()
    {
        count += Random.Range(1, 3);
        GetComponent<Text>().text = $"{count}";
    }

    public void ResetMe()
    {
        if (IsInvoking(nameof(UpdateScore)))
        {
            CancelInvoke(nameof(UpdateScore));
        }

        count = 0;
        InvokeRepeating(nameof(UpdateScore), 0.0f, 2.0f);
    }
}
