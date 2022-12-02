using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string LevelScenePrefix = "Level";
    private const int NumberOfLevels = 2;

    public static LevelLoader Instance { get; private set; }

    public int CurrentLevelNumber { get; private set; }

    public void LoadStartLevel()
    {
        CurrentLevelNumber = SaveService.Instance.GetLevelNumber();
        LoadCurrentLevel();
    }

    public void LoadNextLevel()
    {   
        CurrentLevelNumber++;
        SaveService.Instance.SaveLevelNumber(CurrentLevelNumber);

        LoadCurrentLevel();
    }

    public void RestartLevel()
    {
        LoadCurrentLevel();
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(LevelScenePrefix + (1 + ((CurrentLevelNumber -1) % NumberOfLevels)).ToString());
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