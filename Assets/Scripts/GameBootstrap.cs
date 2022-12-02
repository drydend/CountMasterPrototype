using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField]
    private LevelLoader _levelLoader;
    [SerializeField]
    private SaveService _saveService;

    private void Awake()
    {
        DontDestroyOnLoad(Instantiate(_levelLoader));
        DontDestroyOnLoad(Instantiate(_saveService));
    }

    private void Start()
    {
        LevelLoader.Instance.LoadStartLevel();
    }
}
