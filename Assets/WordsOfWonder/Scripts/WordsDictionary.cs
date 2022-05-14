//using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordsDictionary : MonoBehaviour
{
    [SerializeField] private Word[] _words;

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
            throw new System.Exception("Все слова уже отгаданы");
        }

        Word word = notGuessedWords.OrderBy((x) => Random.value).First();
        Debug.Log(word.Tip);
    }

    public bool TryGuess(string word)
    {
        if (_wordsValue.Contains(word) == false
            || _guessedWords.Contains(word))
        {
            return false;
        }

        _guessedWords.Add(word);
        int index = System.Array.IndexOf(_wordsValue, word);
        _words[index].OpenWord();
        return true;
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
