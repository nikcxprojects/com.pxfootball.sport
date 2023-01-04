using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform container;

    private void OnEnable() => UpdateBoard();

    public void UpdateBoard()
    {
        int[] scores = new int[container.childCount];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(2500, 6666);
        }

        var sortedScores = scores.OrderByDescending(i => i).ToArray();
        for(int i = 0; i < container.childCount; i++)
        {
            int index = i < 3 ? 0 : 1;
            Text leader = container.GetChild(i).GetChild(index).GetComponentInChildren<Text>();
            leader.text = string.Format("{0:0000}", sortedScores[i]);
        }
    }
}
