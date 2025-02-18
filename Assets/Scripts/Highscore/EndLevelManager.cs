using UnityEngine;

public class EndLevelManager : MonoBehaviour
{

    public void EndLevel()
    {
        PlayerDataInitializer.Instance.SavePlayerData();

        // Display the top ranking
        Scenes.Credits();
    }
}