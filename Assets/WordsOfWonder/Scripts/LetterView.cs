using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
public class LetterView : MonoBehaviour
{
    private WordBuilder _wordBuilder;
    private Image _background;

    private void Awake()
    {
        _wordBuilder = FindObjectOfType<WordBuilder>();
    }

    private void Start()
    {
        _background = GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        _wordBuilder.PickindEnded += PickindEnded;
    }

    private void OnDisable()
    {
        _wordBuilder.PickindEnded -= PickindEnded;
    }

    private void PickindEnded()
    {
        SetBackgroundAlpha(0f);
    }

    private void OnMouseEnter()
    {
        SetBackgroundAlpha(1f);
    }

    private void OnMouseExit()
    {
        if (_wordBuilder.IsPicking == false)
        {
            SetBackgroundAlpha(0f);
        }
    }

    public void Show()
    {
        SetBackgroundAlpha(1f);
    }

    private void SetBackgroundAlpha(float value)
    {
        Color tempColor = _background.color;
        tempColor.a = value;
        _background.color = tempColor;
    }
}
