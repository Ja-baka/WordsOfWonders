using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] private string _value;
    [SerializeField] private GameObject[] _textCells;
    [TextArea][SerializeField] private string _tip;

    private TextMeshProUGUI[] _textes;

    public string Value => _value;
    public string Tip => _tip;

    private void OnValidate()
    {
        _value = _value.ToLower();
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
        TextesEnabled = true;
    }

    public void CloseWord()
    {
        TextesEnabled = false;
    }

    private bool TextesEnabled
    {
        set
        {
            foreach (TextMeshProUGUI tmp in _textes)
            {
                tmp.enabled = value;
            }
        }
    }
}
