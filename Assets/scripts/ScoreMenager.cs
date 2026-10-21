using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject postScorePanel;   
    public GameObject leaderboardPanel; 

    // Il codice pubblico di Dreamlo preso dal tuo link
    private string publicCode = "6ac61aed8f40bb15a8d2a8f1";

    public void SaveScoreAndShowLeaderboard()
    {
        // 1. Prende il nome inserito o usa "Player" come fallback
        string playerName = "Player";
        if (nameInputField != null && !string.IsNullOrEmpty(nameInputField.text))
        {
            playerName = nameInputField.text;
        }

        // 2. Prende il tempo registrato dal drago
        float finalTime = PlayerPrefs.GetFloat("LastPlayerScore", 0f);

        // 3. Manda il punteggio online su Dreamlo
        StartCoroutine(UploadScoreToDreamlo(playerName, finalTime));

        // 4. Spegne il pannello del nome e accende la classifica
        if (postScorePanel != null) postScorePanel.SetActive(false);
        if (leaderboardPanel != null) leaderboardPanel.SetActive(true);
    }

    // Funzione che comunica con Dreamlo per registrare il punteggio
    IEnumerator UploadScoreToDreamlo(string name, float score)
    {
        // Moltiplichiamo per 100 per mantenere i decimali del tempo
        int scoreInt = Mathf.RoundToInt(score * 100f); 
        string url = "https://dreamlo.com/lb/" + publicCode + "/add/" + UnityWebRequest.EscapeURL(name) + "/" + scoreInt;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Punteggio inviato a Dreamlo con successo!");
            }
            else
            {
                Debug.Log("Errore nell'invio del punteggio: " + www.error);
            }
        }
    }
}