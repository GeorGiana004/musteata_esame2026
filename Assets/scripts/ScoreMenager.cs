using UnityEngine;
using TMPro; // Serve per usare TextMeshPro

public class ScoreManager : MonoBehaviour
{
    
    public TMP_InputField nameInputField;

    // Funzione da collegare al bottone "Submit Score"
    public void SaveScoreAndShowLeaderboard()
    {
        // 1. Prende il nome scritto dal giocatore (se è vuoto, usa "Player")
        string playerName = "Player";
        if (nameInputField != null && !string.IsNullOrEmpty(nameInputField.text))
        {
            playerName = nameInputField.text;
        }

        // 2. Prende il tempo che abbiamo salvato prima dal drago
        float finalTime = PlayerPrefs.GetFloat("LastPlayerScore", 0f);

        // 3. Salviamo il punteggio usando PlayerPrefs (metodo semplice per principianti)
        // Salviamo il tempo e il nome associati
        PlayerPrefs.SetString("SavedName", playerName);
        PlayerPrefs.SetFloat("SavedTime", finalTime);
        PlayerPrefs.Save();

        Debug.Log("Punteggio salvato! Nome: " + playerName + " - Tempo: " + finalTime);

      
    }
}