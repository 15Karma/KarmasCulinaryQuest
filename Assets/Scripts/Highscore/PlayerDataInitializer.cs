using TMPro;
using UnityEngine;

public class PlayerDataInitializer : MonoBehaviour
{

    public TMP_InputField nameInput;

    public static PlayerDataInitializer Instance { get; private set; }

    public PlayerData CurrentPlayerData { get; private set; }

    public void InitializePlayerData()
    {     
        string playerName = nameInput.text;
        
        PlayerData playerData = new PlayerData(playerName, 0);            
        SetPlayerData(playerData);

        // You can now use playerData or perform additional logic if needed
        SaveSystem.SavePlayerData();
        Debug.Log("Player Name: " + playerData.Name);
        Debug.Log("Player Coins: " + playerData.Coins);
    }

  
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("bi");
    }

    public void SetPlayerData(PlayerData playerData)
    {
        CurrentPlayerData = playerData;
    }

    public void SavePlayerData()
    {
        if (CurrentPlayerData != null)
        {
            SaveSystem.SavePlayerData();
            Debug.Log("Player Name: " + this.CurrentPlayerData.Name);
            Debug.Log("Player Coins: " + this.CurrentPlayerData.Coins);
        }
    }

    public void LoadPlayerData(string playerName)
    {
        CurrentPlayerData = SaveSystem.LoadPlayerData(playerName);
    }

    public string GetPlayerName()
    {
        return CurrentPlayerData?.Name;
    }

    public int GetPlayerCoins()
    {
        return CurrentPlayerData?.Coins ?? 0;
    }

}
