using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        LevelLoader.Instance.LoadNextLevel();
    }
}
