using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _ui;
    public void Disable() 
    {
        _ui.SetActive(false);
    }

    public void Show()
    {
        _ui.SetActive(true);
    }
}