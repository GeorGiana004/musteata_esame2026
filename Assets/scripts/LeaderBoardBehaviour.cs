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
    
    private string webUrl = "https://dreamlo.com/lb/6ac61aed8f40bb15a8d2a8f1/quote";

    void OnEnable()
    {
        // Appena si apre il pannello della classifica, scarica subito i dati online in automatico!
        StartCoroutine(GetRequest(webUrl));
    }

    void Update()
    {
        // Lasciamo anche la barra spaziatrice per ricaricare manualmente se serve
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GetRequest(webUrl));
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Errore nel download della classifica: " + webRequest.error);
                yield break;
            }

            string pageContent = webRequest.downloadHandler.text;

            PlayersData = pageContent.Split('\n');
            PlayersName.Clear();
            PlayerScore.Clear();

            for (int i = 0; i < PlayersData.Length; i++)
            {
                if (!string.IsNullOrEmpty(PlayersData[i]))
                {
                    string[] lineElements = PlayersData[i].Split(',');
                    
                    if (lineElements.Length >= 2)
                    {
                        string playerName = lineElements[0];
                        string score = lineElements[1];

                        PlayersName.Add(playerName);
                        PlayerScore.Add(score);
                    }
                }
            }

            RefreshUI();
        }
    }

    void RefreshUI()
    {
        foreach (Transform child in EntryGroup)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < PlayersName.Count; i++)
        {
            LeaderBoardentryBehavior currentEntry = Instantiate(EntryPrefab, EntryGroup);
            currentEntry.SetEntryValues((i + 1).ToString(), PlayersName[i], PlayerScore[i]);
        }
    }
}