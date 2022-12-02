using UnityEngine;

public class SaveService : MonoBehaviour
{
    private const string NumberOfCoinsKey = "COIN";
    private const string LevelNumberKey = "LEVEL_NUMBER";

    public static SaveService Instance { get; private set; }

    public void SaveLevelNumber(int levelNumber)
    {
        PlayerPrefs.SetInt(LevelNumberKey, levelNumber);
    }

    public int GetLevelNumber()
    {
        if (PlayerPrefs.HasKey(LevelNumberKey))
        {
            return PlayerPrefs.GetInt(LevelNumberKey);
        }

        SaveLevelNumber(1);
        return 1;
    }

    public void SaveCoins(int numberOfCoins)
    {
        PlayerPrefs.SetInt(NumberOfCoinsKey, numberOfCoins);
    }

    public int GetCoins()
    {
        if (PlayerPrefs.HasKey(NumberOfCoinsKey))
        {
            return PlayerPrefs.GetInt(NumberOfCoinsKey);
        }

        SaveCoins(0);
        return 0;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            throw new System.Exception("Save service ca be only one");
        }

        Instance = this;
    }
}