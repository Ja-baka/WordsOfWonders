using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D))]
public class Letter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<Letter> DragBegin;
    public event Action<Letter> MouseEnter;
    public event Action DragEnd;

    public char Charactor { get; private set; }

    private void Start()
    {
        TextMeshProUGUI tmpro = GetComponentInChildren<TextMeshProUGUI>();
        Charactor = tmpro.text[0];
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
        // This method should be empty
    }
}
