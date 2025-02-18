using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    private PlayerData currentPlayerData;

    public CoinsManager Instance;
    public TMP_Text coinCounterText; // UI Text to show coin count

    private void Start()
    {
        currentPlayerData = PlayerDataInitializer.Instance.CurrentPlayerData;
        Debug.Log(currentPlayerData.Name);
        UpdateCoinCounter();
    }

    public void AddCoins(int value)
    {
        if (currentPlayerData != null)
        {
            currentPlayerData.Coins += value;
            UpdateCoinCounter();
        }
    }

    public void SavePlayerCoins()
    {
        if (currentPlayerData != null)
        {
            SaveSystem.SavePlayerData();
        }
    }

    public int GetCoins()
    {
        return currentPlayerData != null ? currentPlayerData.Coins : 0;
    }

    public void ResetCoins()
    {
        if (currentPlayerData != null)
        {
            currentPlayerData.Coins = 0;
            UpdateCoinCounter();
        }
    }

    private void UpdateCoinCounter()
    {
        if (coinCounterText != null)
        {
            coinCounterText.text = GetCoins().ToString();
        }
    }
}
