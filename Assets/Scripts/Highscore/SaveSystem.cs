using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public static class SaveSystem
{
    private static string filePath = Application.persistentDataPath + "/playerdata.json";

    public static void SavePlayerData()
    {
        PlayerData playerData = PlayerDataInitializer.Instance.CurrentPlayerData;
        Dictionary<string, PlayerData> playerDataDict = LoadPlayerDataDict();
        Debug.Log(playerData.Name);
        Debug.Log(playerDataDict);

        if (playerDataDict.ContainsKey(playerData.Name))
        {
            if (playerData.Coins > playerDataDict[playerData.Name].Coins)
            {
                playerDataDict[playerData.Name] = playerData;
            }          
        }
        else
        {
            playerDataDict.Add(playerData.Name, playerData);
        }

        SavePlayerDataDict(playerDataDict);
        foreach (var kvp in playerDataDict)
        {
            Debug.Log($"Key: {kvp.Key}, Name: {kvp.Value.Name}, Coin: {kvp.Value.Coins}");
        }
    }

    public static void SavePlayerDataDict(Dictionary<string, PlayerData> playerDataDict)
    {
        string json = JsonUtility.ToJson(new SerializationWrapper(playerDataDict));
        File.WriteAllText(filePath, json);
    }

    public static Dictionary<string, PlayerData> LoadPlayerDataDict()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SerializationWrapper wrapper = JsonUtility.FromJson<SerializationWrapper>(json);
            return wrapper.ToDictionary();
        }
        else
        {
            Debug.LogWarning("Save file not found");
            return new Dictionary<string, PlayerData>();
        }
    }

    public static PlayerData LoadPlayerData(string playerName)
    {
        Dictionary<string, PlayerData> playerDataDict = LoadPlayerDataDict();
        playerDataDict.TryGetValue(playerName, out PlayerData playerData);
        return playerData;
    }

    [Serializable]
    private class SerializationWrapper
    {
        public List<string> keys;
        public List<PlayerData> values;

        public SerializationWrapper(Dictionary<string, PlayerData> dictionary)
        {
            keys = new List<string>(dictionary.Keys);
            values = new List<PlayerData>(dictionary.Values);
        }

        public Dictionary<string, PlayerData> ToDictionary()
        {
            Dictionary<string, PlayerData> result = new Dictionary<string, PlayerData>();
            for (int i = 0; i < keys.Count; i++)
            {
                result.Add(keys[i], values[i]);
            }
            return result;
        }
    }
}