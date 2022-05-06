using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Letter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private char _charactor;

    public event Action<Letter> DragBegin;
    public event Action<Letter> MouseEnter;
    public event Action DragEnd;

    public char Charactor => _charactor;

    private void Start()
    {
        TextMeshProUGUI tmpro = GetComponentInChildren<TextMeshProUGUI>();
        _charactor = tmpro.text[0];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragBegin?.Invoke(this);
    }

    private void OnMouseEnter()
    {
        MouseEnter?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragEnd?.Invoke();
    }

    public void OnDrag(PointerEventData eventData) 
    {
    }
}
