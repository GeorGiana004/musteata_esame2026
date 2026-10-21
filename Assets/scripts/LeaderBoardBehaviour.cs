using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderBoardBehaviour : MonoBehaviour
{
    public string[] PlayersData;
    public List<string> PlayersName = new List<string>();
    public List<string> PlayerScore = new List<string>();
    
    [Header("References:")]
    public LeaderBoardentryBehavior EntryPrefab;
    public Transform EntryGroup;

    public TMP_InputField PlayerNameInputField;

    void Start()
    {
        
    }

    void Update()
    {
        // Premendo la barra spaziatrice scarica la classifica
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GetRequest("https://dreamlo.com/lb/6ac61aed8f40bb15a8d2a8f1/quote"));
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Richiesta web e attesa della risposta
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            // Controllo errori
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    yield break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    yield break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }

            string pageContent = webRequest.downloadHandler.text;

            // Dividiamo i dati riga per riga
            PlayersData = pageContent.Split('\n');

            // Svuotiamo le liste prima di riempirle
            PlayersName.Clear();
            PlayerScore.Clear();

            for (int i = 0; i < PlayersData.Length; i++)
            {
                // Ignoriamo le righe vuote
                if (!string.IsNullOrEmpty(PlayersData[i]))
                {
                    string[] lineElements = PlayersData[i].Split(',');
                    
                    if (lineElements.Length >= 2)
                    {
                        // lineElements[0] è il nome, lineElements[1] è il punteggio
                        string playerName = lineElements[0];
                        string score = lineElements[1];

                        PlayersName.Add(playerName);
                        PlayerScore.Add(score);
                    }
                }
            }

            // Aggiorniamo la UI dopo aver elaborato i dati
            RefreshUI();
        }
    }

    void RefreshUI()
    {
        // 1. Rimuoviamo i vecchi elementi per evitare duplicati se premi Spazio più volte
        foreach (Transform child in EntryGroup)
        {
            Destroy(child.gameObject);
        }

        // 2. Creiamo le nuove righe in base ai dati salvati nelle liste
        for (int i = 0; i < PlayersName.Count; i++)
        {
            LeaderBoardentryBehavior currentEntry = Instantiate(EntryPrefab, EntryGroup);
            // La classifica parte da 1, quindi (i + 1)
            currentEntry.SetEntryValues((i + 1).ToString(), PlayersName[i], PlayerScore[i]);
        }
    }
}