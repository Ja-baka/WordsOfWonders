using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class WordsDictionary : MonoBehaviour
{
    [SerializeField] private Word[] _words;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private Score _score;

    private string[] _wordsValue;
    private List<string> _guessedWords;

    public Word[] Words => _words;

    private void Start()
    {
        _wordsValue = new string[_words.Length];
        int index = 0;
        foreach (Word word in _words)
        {
            _wordsValue[index++] = word.Value;
        }

        _guessedWords = new List<string>();
    }

    public void ShowTip()
    {
        var notGuessedWords = _words.Where((w) 
            => _guessedWords.Contains(w.Value) == false);

        if (notGuessedWords.Any() == false)
        {
            _message.color = Color.red;
            _message.text = "Все слова уже отгаданы";
            return;
        }

        Word word = notGuessedWords.OrderBy((x) => Random.value).First();
        _message.color = Color.white;
        _message.text = $"Подсказка: {word.Tip}";
        _score.UsedTip();
    }

    public void TryGuess(string word)
    {
        if (_wordsValue.Contains(word) == false
            || _guessedWords.Contains(word))
        {
            _message.color = Color.red;
            _message.text = "Нет такого слова";
            _score.Miss();
            return;
        }

        _guessedWords.Add(word);
        int index = System.Array.IndexOf(_wordsValue, word);
        _words[index].OpenWord();
        _message.text = string.Empty;
        _score.Guess(word.Length);
    }

    public void ResetDictionary()
    {
        _guessedWords.Clear();
        for (int i = 0; i < _words.Length; i++)
        {
            _words[i].CloseWord();
        }
    }
}
