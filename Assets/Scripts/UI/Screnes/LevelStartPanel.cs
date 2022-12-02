using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelStartPanel : MonoBehaviour, ILevelStartTrigger, IPointerDownHandler
{
    [SerializeField]
    private GameObject _startUI;
    [SerializeField]
    private GameObject _levelUI;

    public event Action OnLevelStart;

    public void OnPointerDown(PointerEventData eventData)
    {   
        _startUI.SetActive(false);
        OnLevelStart?.Invoke();
        _levelUI.SetActive(true);
    }
}
