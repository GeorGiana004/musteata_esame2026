using UnityEngine;
using TMPro;

public class LeaderBoardentryBehavior : MonoBehaviour
{
    public TMP_Text RankText;
    public TMP_Text PlayerNameText;
    public TMP_Text ScoreText;

    public void SetEntryValues(string rankValue, string PlayerNameValue, string scoreValue)
    {
        RankText.text = rankValue;
        PlayerNameText.text = PlayerNameValue;
        ScoreText.text = scoreValue;
    }

}