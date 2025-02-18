using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    #region atributos
    [SerializeField]
    private string name;
    [SerializeField]
    private int coins;
    #endregion

    #region propiedades
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
        }
    }
    #endregion

    public PlayerData(string name, int coins)
    {
        Name = name;
        Coins = coins;
    }

    // Method to convert PlayerData object to JSON string
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    // Method to create PlayerData object from JSON string
    public static PlayerData FromJson(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public void GetCoin(int valor)
    {
        coins += valor;
    }


}