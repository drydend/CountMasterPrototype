using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float _maxDisplacement = 2f;
    [SerializeField]
    private float _sensitivity = 3f;

    private Vector2 _anchorPosition;
    private float _xDisplacements;
    private bool _isDraged;

    public float XDisplacement => _xDisplacements;

    private void Update()
    {
        if (_isDraged)
        {   
            _xDisplacements = GetXDisplacement(Input.mousePosition);
            _anchorPosition = Input.mousePosition;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _xDisplacements = 0f;
        _isDraged = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _anchorPosition = Input.mousePosition;
        _isDraged = true;
    }
    private float GetXDisplacement(Vector2 pointerCurrentPosition)
    {
        var directionToCurrentPosition = (pointerCurrentPosition - _anchorPosition);
        return Mathf.Clamp(directionToCurrentPosition.x, -_maxDisplacement, _maxDisplacement) * _sensitivity;
    }
}
