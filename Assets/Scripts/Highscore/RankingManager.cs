using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingManager : MonoBehaviour
{
    public TMP_Text rankingText;

    private void Start()
    {
        DisplayTopRanking();
    }

    public void DisplayTopRanking()
    {
        Dictionary<string, PlayerData> playerDataDict = SaveSystem.LoadPlayerDataDict();

        // Convert dictionary values to a list
        List<PlayerData> playerDataList = new List<PlayerData>(playerDataDict.Values);

        // Sort the list by coins in descending order and take the top 5 players
        playerDataList.Sort((a, b) => b.Coins.CompareTo(a.Coins));
        List<PlayerData> topPlayers = playerDataList.GetRange(0, Mathf.Min(5, playerDataList.Count));

        rankingText.text = ""; // Clear the existing text

        for (int i = 0; i < topPlayers.Count; i++)
        {
            rankingText.text += $"{i + 1}. {topPlayers[i].Name} ---- {topPlayers[i].Coins} \n";
        }
    }
}