using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] private string _value;
    [SerializeField] private GameObject[] _textCells;

    private TextMeshProUGUI[] _textes;

    public string Value => _value;

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

    public bool TextesEnabled
    {
        get
        {
            foreach (TextMeshProUGUI tmp in _textes)
{
                if (tmp.enabled == false)
                {
                    return false;
                }
            }
            return true;
        }
        private set
        {
            foreach (TextMeshProUGUI tmp in _textes)
            {
                tmp.enabled = value;
            }
        }
    }
}
