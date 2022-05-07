using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] private string _wordValue;
    [SerializeField] private GameObject[] _textCells;

    private TextMeshProUGUI[] _textes;

    public string WordValue => _wordValue;

    private void OnValidate()
    {
        _wordValue = _wordValue.ToLower();
    }

    private void Awake()
    {
        _textes = new TextMeshProUGUI[_textCells.Length];

        int index = 0;
        foreach (GameObject cell in _textCells)
        {
            var text = cell.GetComponentInChildren<TextMeshProUGUI>();
            _textes[index++] = text;
            text.enabled = false;
        }
    }

    public void OpenWord()
    {
        SetTextesEnabled(true);
    }

    public void CloseWord()
    {
        SetTextesEnabled(false);
    }

    private void SetTextesEnabled(bool enabled)
    {
        foreach (TextMeshProUGUI tmp in _textes)
        {
            tmp.enabled = enabled;
        }
    }
}
